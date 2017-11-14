// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text;

namespace Peregrine
{
    internal static class PG
    {
        public static readonly UTF8Encoding UTF8
            = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
    }

    internal enum MessageType : byte
    {
        AuthenticationRequest = (byte)'R',
        BackendKeyData = (byte)'K',
        BindComplete = (byte)'2',
        CloseComplete = (byte)'3',
        CommandComplete = (byte)'C',
        CopyData = (byte)'d',
        CopyDone = (byte)'c',
        CopyBothResponse = (byte)'W',
        CopyInResponse = (byte)'G',
        CopyOutResponse = (byte)'H',
        DataRow = (byte)'D',
        EmptyQueryResponse = (byte)'I',
        ErrorResponse = (byte)'E',
        FunctionCall = (byte)'F',
        FunctionCallResponse = (byte)'V',
        NoData = (byte)'n',
        NoticeResponse = (byte)'N',
        NotificationResponse = (byte)'A',
        ParameterDescription = (byte)'t',
        ParameterStatus = (byte)'S',
        ParseComplete = (byte)'1',
        PasswordPacket = (byte)' ',
        PortalSuspended = (byte)'s',
        ReadyForQuery = (byte)'Z',
        RowDescription = (byte)'T'
    }

    internal enum FormatCode : short
    {
        Text = 0,
        Binary = 1
    }

    internal enum AuthenticationRequestType
    {
        AuthenticationOk = 0,
        AuthenticationKerberosV4 = 1,
        AuthenticationKerberosV5 = 2,
        AuthenticationCleartextPassword = 3,
        AuthenticationCryptPassword = 4,
        AuthenticationMD5Password = 5,
        AuthenticationSCMCredential = 6,
        AuthenticationGSS = 7,
        AuthenticationGSSContinue = 8,
        AuthenticationSSPI = 9
    }

    internal enum ErrorFieldTypeCode : byte
    {
        Done = 0,
        Severity = (byte)'S',
        Code = (byte)'C',
        Message = (byte)'M',
        Detail = (byte)'D',
        Hint = (byte)'H',
        Position = (byte)'P',
        InternalPosition = (byte)'p',
        InternalQuery = (byte)'q',
        Where = (byte)'W',
        SchemaName = (byte)'s',
        TableName = (byte)'t',
        ColumnName = (byte)'c',
        DataTypeName = (byte)'d',
        ConstraintName = (byte)'n',
        File = (byte)'F',
        Line = (byte)'L',
        Routine = (byte)'R'
    }
}
