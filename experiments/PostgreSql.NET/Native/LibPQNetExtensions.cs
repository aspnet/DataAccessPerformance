using System.Linq;
using System.Text;

namespace PostgreSql.Native
{
    public unsafe partial class Libpq
    {
        public static PgResult PQexecParams(PgConn conn, string commandText, string[] parameters)
        {
            // Because all parameters are of type string, we can omit the parameter information.
            // If we wanted to use other types (int, bool, ...) we would need to provide them.
            return MarshalStringArrayToBufferFor(parameters, buffer => PQexecParams(conn, commandText, parameters.Length, null, buffer, null, null, 0));
        }

        public static PgResult PQexecPrepared(PgConn conn, string stmtName, string[] parameters)
        {
            return MarshalStringArrayToBufferFor(parameters, buffer => PQexecPrepared(conn, stmtName, parameters.Length, buffer, null, null, 0));
        }
        
        internal unsafe delegate TResult PointerAction<TResult>(byte** ptr);

        internal static TResult MarshalStringArrayToBufferFor<TResult>(string[] parameters, PointerAction<TResult> action)
        {
            var allParameterBytes = parameters.Select(s => Encoding.UTF8.GetBytes(s)).ToArray();
            var bufferSize = allParameterBytes.Sum(x => x.Length + 1); // +1 as each string is NULL terminated

            // byteArray is automatically released once the method has returned
            byte* buffer = stackalloc byte[bufferSize];
            var i = 0;
            foreach (var parameterBytes in allParameterBytes)
            {
                fixed (byte* bytes = parameterBytes)
                {
                    for (var b = 0; b < parameterBytes.Length; b++)
                    {
                        buffer[i++] = bytes[b];
                    }

                    buffer[i++] = 0;
                }
            }

            return action(&buffer);
        }
    }
}
