// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Peregrine
{
    internal class WriteBuffer
    {
        private const int DefaultBufferSize = 1024;

        private readonly AwaitableSocket _awaitableSocket;

        private readonly byte[] _buffer = new byte[DefaultBufferSize];

        private int _position;
        private int _messageOffset;

        public WriteBuffer(AwaitableSocket awaitableSocket)
        {
            _awaitableSocket = awaitableSocket;
        }

        public WriteBuffer StartMessage(char type)
        {
            WriteByte((byte)type);

            return StartMessage();
        }

        public WriteBuffer StartMessage()
        {
            _messageOffset = _position;
            _position += sizeof(int);

            return this;
        }

        public WriteBuffer EndMessage()
        {
            WriteInt(_messageOffset, _position - _messageOffset);

            return this;
        }

        public WriteBuffer WriteByte(byte b)
        {
            _buffer[_position++] = b;

            return this;
        }

        public WriteBuffer WriteBytes(byte[] bytes)
        {
            Buffer.BlockCopy(bytes, 0, _buffer, _position, bytes.Length);

            _position += bytes.Length;

            return this;
        }

        public WriteBuffer WriteNull() => WriteByte(0);

        public WriteBuffer WriteShort(short s)
        {
            _buffer[_position] = (byte)(s >> 8);
            _buffer[_position + 1] = (byte)s;

            _position += sizeof(short);

            return this;
        }

        public WriteBuffer WriteInt(int i)
        {
            WriteInt(_position, i);

            _position += sizeof(int);

            return this;
        }

        private void WriteInt(int position, int i)
        {
            _buffer[position] = (byte)(i >> 24);
            _buffer[position + 1] = (byte)(i >> 16);
            _buffer[position + 2] = (byte)(i >> 8);
            _buffer[position + 3] = (byte)i;
        }

        public WriteBuffer WriteString(string s)
        {
            _position += PG.UTF8.GetBytes(s, 0, s.Length, _buffer, _position);

            return WriteNull();
        }

        public AwaitableSocket FlushAsync()
        {
            _awaitableSocket.SetBuffer(_buffer, 0, _position);
            _position = 0;

            return _awaitableSocket.SendAsync();
        }
    }
}
