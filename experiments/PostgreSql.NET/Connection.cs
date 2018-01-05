using System;
using System.Collections.Generic;
using PostgreSql.Native;
using static PostgreSql.Native.Libpq;

namespace PostgreSql
{
    public class Connection : IDisposable
    {
        private readonly PgConn _pgConn;
        private readonly Database _factory;
        private PgResult _lastResult;
        private Dictionary<string, int> _fields;
        private Dictionary<string, string> _preparedQueries;

        internal Connection(PgConn pgConn, Database factory)
        {
            _pgConn = pgConn;
            _factory = factory;
        }

        public PgResult LastResult
        {
            get { return _lastResult; }
            private set { ClearLastResult(); _lastResult = value; }
        }

        private void ClearLastResult()
        {
            if (_lastResult == null)
            {
                return;
            }

            PQclear(_lastResult);
            _lastResult = null;
            _fields = null;
        }

        private void ComputeFields()
        {
            if (_fields == null)
            {
                for (var i = 0; i < Fields; i++)
                {
                    _fields.Add(Name(i), i);
                }
            }
        }

        public void Exec(string commandText)
        {
            LastResult = PQexec(_pgConn, commandText);
        }

        public void ExecParams(string commandText, string[] commandParams)
        {
            LastResult = PQexecParams(_pgConn, commandText, commandParams);
        }

        public void Prepare(string statementName, string commandText, int parameters = 0)
        {
            if (_preparedQueries == null)
            {
                _preparedQueries = new Dictionary<string, string>();
            }

            if (_preparedQueries.TryGetValue(statementName, out var preparedCommandText) && commandText == preparedCommandText)
            {
                // Query already prepared for this connection
                return;
            }
            else
            {
                _preparedQueries[statementName] = commandText;
            }

            PQprepare(_pgConn, statementName, commandText, parameters, null);
        }

        public void ExecPrepared(string statementName, string[] commandParameters = null)
        {
            LastResult = PQexecPrepared(_pgConn, statementName, commandParameters ?? Array.Empty<string>());
        }

        public int Rows => PQntuples(LastResult);
        public int Fields => PQnfields(LastResult);

        public string Name(int index)
        {
            return PQfname(LastResult, index);
        }

        public int Index(string fieldName)
        {
            ComputeFields();

            if (!_fields.TryGetValue(fieldName, out int index))
            {
                throw new Exception($"Unknown field '{fieldName}' in results.");
            }

            return index;
        }

        public string Value(int row, int field)
        {
            return PQgetvalue(LastResult, row, field);
        }

        public string Value(int row, string name)
        {
            return Value(row, Index(name));
        }

        public bool IsNull(int row, int index)
        {
            return PQgetisnull(LastResult, row, index) == 1;
        }

        public bool IsNull(int row, string name)
        {
            return PQgetisnull(LastResult, row, Index(name)) == 1;
        }

        public ExecStatusType ExecStatus => PQresultStatus(LastResult);
        public string ErrorMessage => PQresultErrorMessage(LastResult);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Get rid of managed resources
            }

            ClearLastResult();

            // Prepared queries are reused while the connection is living

            // If the finalizer was called or we couldn't return it to the pool, release the unmanaged resources
            if (!disposing || !_factory.Return(this))
            {
                // Get rid of unmanaged resources

                PQfinish(_pgConn);
            }
        }

        ~Connection()
        {
            Dispose(false);
        }
    }
}
