// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Buffers.Binary;

namespace Peregrine
{
    public class ReadBuffer
    {
        private const int DefaultBufferSize = 8192;

        private readonly AwaitableSocket _awaitableSocket;

        private readonly Memory<byte> _buffer = new Memory<byte>(new byte[DefaultBufferSize]);

        private int _position;

        internal ReadBuffer(AwaitableSocket awaitableSocket)
        {
            _awaitableSocket = awaitableSocket;
        }

        internal MessageType ReadMessage()
        {
            var messageType = (MessageType)ReadByte();

            // Skip length
            _position += sizeof(int);

            return messageType;
        }

        internal (MessageType Type, int Length) ReadMessageWithLength()
        {
            var messageType = (MessageType)ReadByte();
            var length = ReadInt() - 4;

            return (messageType, length);
        }

        internal string ReadErrorMessage()
        {
            string message = null;

            read:

            var code = (ErrorFieldTypeCode)ReadByte();

            switch (code)
            {
                case ErrorFieldTypeCode.Done:
                    break;
                case ErrorFieldTypeCode.Message:
                    message = ReadNullTerminatedString();
                    break;
                default:
                    ReadNullTerminatedString();
                    goto read;
            }

            return message;
        }

        public byte ReadByte()
            => _buffer.Span[_position++];

        public byte[] ReadBytes(int length)
        {
            var bs = new byte[length];

            var span = _buffer.Span;
            for (var i = 0; i < length; i++)
                bs[i] = span[_position++];

            return bs;
        }

        public void SkipShort()
        {
            _position += sizeof(short);
        }

        public short ReadShort()
        {
            var result = BinaryPrimitives.ReadInt16BigEndian(_buffer.Span.Slice(_position, 2));
            _position += sizeof(short);
            return result;
        }

        public ushort ReadUShort()
        {
            var result = BinaryPrimitives.ReadUInt16BigEndian(_buffer.Span.Slice(_position, 2));
            _position += sizeof(short);
            return result;
        }

        public int ReadInt()
        {
            var result = BinaryPrimitives.ReadInt32BigEndian(_buffer.Span.Slice(_position, 4));
            _position += sizeof(int);
            return result;
        }

        public uint ReadUInt()
        {
            var result = BinaryPrimitives.ReadUInt32BigEndian(_buffer.Span.Slice(_position, 4));
            _position += sizeof(int);
            return result;
        }

        public string ReadNullTerminatedString()
        {
            var start = _position;
            var span = _buffer.Span;

            while (span[_position++] != 0
                   && _position < _buffer.Length)

            {
            }

            var s = PG.UTF8.GetString(span.Slice(start, _position - start - 1));

            return s;
        }

        public string ReadString(int length)
        {
            var result = PG.UTF8.GetString(_buffer.Span.Slice(_position, length));
            _position += length;
            return result;
        }

        public AwaitableSocket ReceiveAsync()
        {
            _awaitableSocket.SetBuffer(_buffer);
            _position = 0;

            return _awaitableSocket.ReceiveAsync();
        }
    }
}
