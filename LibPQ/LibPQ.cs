using System;
using System.Runtime.InteropServices;

namespace LibPQNet
{
    public static class LibPQ
    {
        [DllImport("libpq", EntryPoint = "PQconnectdb", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PQconnectdb(String conninfo);
        // PGconn *PQconnectdb(const char *conninfo);

        [DllImport("libpq", EntryPoint = "PQfinish", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PQfinish(IntPtr conn);
        // void PQfinish(PGconn *conn);

        [DllImport("libpq", EntryPoint = "PQexec", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PQexec(IntPtr conn, String command);
        // PGresult *PQexec(PGconn *conn, const char *command);

        [DllImport("libpq", EntryPoint = "PQprepare", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PQprepare(IntPtr conn, String stmtName, String query, uint nParams, uint[] paramTypes);
        //PGresult* PQprepare(PGconn* conn,
        //        const char* stmtName,
        //        const char* query,
        //        int nParams,
        //        const Oid* paramTypes);

        [DllImport("libpq", EntryPoint = "PQexecPrepared", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PQexecPrepared(IntPtr conn, String stmtName, uint nParams, String[] paramValues, uint[] paramLengths, uint[] paramFormats, uint resultFormat);
        //PGresult* PQexecPrepared(PGconn* conn,
        //             const char* stmtName,
        //             int nParams,
        //             const char* const * paramValues,
        //             const int* paramLengths,
        //             const int* paramFormats,
        //             int resultFormat);

        [DllImport("libpq", EntryPoint = "PQclear", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PQclear(IntPtr res);
        //void PQclear(PGresult* res);

        [DllImport("libpq", EntryPoint = "PQresultStatus", CallingConvention = CallingConvention.Cdecl)]
        public static extern ExecStatusType PQresultStatus(IntPtr res);
        // ExecStatusType PQresultStatus(const PGresult *res);

        [DllImport("libpq", EntryPoint = "PQgetvalue", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr PQgetvalue(IntPtr res, uint row_number, uint column_number);
        //char* PQgetvalue(const PGresult* res,
        //     int row_number,
        //     int column_number);

        [DllImport("libpq", EntryPoint = "PQntuples", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint PQntuples(IntPtr res);
        // int PQntuples(const PGresult *res);

        [DllImport("libpq", EntryPoint = "PQnfields", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint PQnfields(IntPtr res);
        // int PQnfields(const PGresult* res);

    }


    public enum ExecStatusType
    {
        PGRES_EMPTY_QUERY = 0,      /* empty query string was executed */
        PGRES_COMMAND_OK,           /* a query command that doesn't return 
                                         * anything was executed properly by the 
                                         * backend */
        PGRES_TUPLES_OK,            /* a query command that returns tuples was 
                                         * executed properly by the backend, PGresult 
                                         * contains the result tuples */
        PGRES_COPY_OUT,             /* Copy Out data transfer in progress */
        PGRES_COPY_IN,              /* Copy In data transfer in progress */
        PGRES_BAD_RESPONSE,         /* an unexpected response was recv'd from the 
                                         * backend */
        PGRES_NONFATAL_ERROR,       /* notice or warning message */
        PGRES_FATAL_ERROR,          /* query failed */
        PGRES_COPY_BOTH,            /* Copy In/Out data transfer in progress */
        PGRES_SINGLE_TUPLE          /* single tuple from larger resultset */
    }
}