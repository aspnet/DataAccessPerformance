// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Security.Cryptography;
using System.Text;

namespace Peregrine
{
    internal static class Hashing
    {
        public static byte[] CreateMD5(string password, string username, byte[] salt)
        {
            using (var md5 = MD5.Create())
            {
                var passwordBytes = PG.UTF8.GetBytes(password);
                var usernameBytes = PG.UTF8.GetBytes(username);

                var buffer = new byte[passwordBytes.Length + usernameBytes.Length];

                passwordBytes.CopyTo(buffer, 0);
                usernameBytes.CopyTo(buffer, passwordBytes.Length);

                var hash = md5.ComputeHash(buffer);

                var stringBuilder = new StringBuilder();

                for (var i = 0; i < hash.Length; i++)
                {
                    stringBuilder.Append(hash[i].ToString("x2"));
                }

                var preHashBytes = PG.UTF8.GetBytes(stringBuilder.ToString());

                buffer = new byte[preHashBytes.Length + 4];

                Array.Copy(salt, 0, buffer, preHashBytes.Length, 4);

                preHashBytes.CopyTo(buffer, 0);

                stringBuilder = new StringBuilder("md5");

                hash = md5.ComputeHash(buffer);

                for (var i = 0; i < hash.Length; i++)
                {
                    stringBuilder.Append(hash[i].ToString("x2"));
                }

                var resultString = stringBuilder.ToString();
                var resultBytes = new byte[Encoding.UTF8.GetByteCount(resultString) + 1];

                Encoding.UTF8.GetBytes(resultString, 0, resultString.Length, resultBytes, 0);

                resultBytes[resultBytes.Length - 1] = 0;

                return resultBytes;
            }
        }
    }
}
