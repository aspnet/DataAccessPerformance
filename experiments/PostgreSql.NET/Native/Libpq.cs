using System;
using System.Runtime.InteropServices;
using System.Security;

namespace PostgreSql.Native
{
    public unsafe partial class Libpq
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQconnectStart")]
            internal static extern global::System.IntPtr PQconnectStart([MarshalAs(UnmanagedType.LPStr)] string conninfo);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQconnectStartParams")]
            internal static extern global::System.IntPtr PQconnectStartParams(sbyte** keywords, sbyte** values, int expand_dbname);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQconnectPoll")]
            internal static extern PostgresPollingStatusType PQconnectPoll(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQconnectdb")]
            internal static extern global::System.IntPtr PQconnectdb([MarshalAs(UnmanagedType.LPStr)] string conninfo);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQconnectdbParams")]
            internal static extern global::System.IntPtr PQconnectdbParams(sbyte** keywords, sbyte** values, int expand_dbname);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsetdbLogin")]
            internal static extern global::System.IntPtr PQsetdbLogin([MarshalAs(UnmanagedType.LPStr)] string pghost, [MarshalAs(UnmanagedType.LPStr)] string pgport, [MarshalAs(UnmanagedType.LPStr)] string pgoptions, [MarshalAs(UnmanagedType.LPStr)] string pgtty, [MarshalAs(UnmanagedType.LPStr)] string dbName, [MarshalAs(UnmanagedType.LPStr)] string login, [MarshalAs(UnmanagedType.LPStr)] string pwd);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQfinish")]
            internal static extern void PQfinish(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQconndefaults")]
            internal static extern global::System.IntPtr PQconndefaults();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQconninfoParse")]
            internal static extern global::System.IntPtr PQconninfoParse([MarshalAs(UnmanagedType.LPStr)] string conninfo, sbyte** errmsg);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQconninfo")]
            internal static extern global::System.IntPtr PQconninfo(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQconninfoFree")]
            internal static extern void PQconninfoFree(global::System.IntPtr connOptions);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQresetStart")]
            internal static extern int PQresetStart(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQresetPoll")]
            internal static extern PostgresPollingStatusType PQresetPoll(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQreset")]
            internal static extern void PQreset(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQgetCancel")]
            internal static extern global::System.IntPtr PQgetCancel(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQfreeCancel")]
            internal static extern void PQfreeCancel(global::System.IntPtr cancel);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQcancel")]
            internal static extern int PQcancel(global::System.IntPtr cancel, sbyte* errbuf, int errbufsize);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQrequestCancel")]
            internal static extern int PQrequestCancel(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQdb")]
            internal static extern sbyte* PQdb(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQuser")]
            internal static extern sbyte* PQuser(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQpass")]
            internal static extern sbyte* PQpass(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQhost")]
            internal static extern sbyte* PQhost(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQport")]
            internal static extern sbyte* PQport(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQtty")]
            internal static extern sbyte* PQtty(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQoptions")]
            internal static extern sbyte* PQoptions(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQstatus")]
            internal static extern ConnStatusType PQstatus(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQtransactionStatus")]
            internal static extern PGTransactionStatusType PQtransactionStatus(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQparameterStatus")]
            internal static extern global::System.IntPtr PQparameterStatus(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string paramName);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQprotocolVersion")]
            internal static extern int PQprotocolVersion(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQserverVersion")]
            internal static extern int PQserverVersion(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQerrorMessage")]
            internal static extern IntPtr PQerrorMessage(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsocket")]
            internal static extern int PQsocket(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQbackendPID")]
            internal static extern int PQbackendPID(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQconnectionNeedsPassword")]
            internal static extern int PQconnectionNeedsPassword(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQconnectionUsedPassword")]
            internal static extern int PQconnectionUsedPassword(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQclientEncoding")]
            internal static extern int PQclientEncoding(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsetClientEncoding")]
            internal static extern int PQsetClientEncoding(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string encoding);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsslInUse")]
            internal static extern int PQsslInUse(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsslStruct")]
            internal static extern global::System.IntPtr PQsslStruct(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string struct_name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsslAttribute")]
            internal static extern global::System.IntPtr PQsslAttribute(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string attribute_name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsslAttributeNames")]
            internal static extern sbyte** PQsslAttributeNames(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQgetssl")]
            internal static extern global::System.IntPtr PQgetssl(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQinitSSL")]
            internal static extern void PQinitSSL(int do_init);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQinitOpenSSL")]
            internal static extern void PQinitOpenSSL(int do_ssl, int do_crypto);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsetErrorVerbosity")]
            internal static extern PGVerbosity PQsetErrorVerbosity(global::System.IntPtr conn, PGVerbosity verbosity);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsetErrorContextVisibility")]
            internal static extern PGContextVisibility PQsetErrorContextVisibility(global::System.IntPtr conn, PGContextVisibility show_context);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQtrace")]
            internal static extern void PQtrace(global::System.IntPtr conn, global::System.IntPtr debug_port);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQuntrace")]
            internal static extern void PQuntrace(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsetNoticeReceiver")]
            internal static extern global::System.IntPtr PQsetNoticeReceiver(global::System.IntPtr conn, global::System.IntPtr proc, global::System.IntPtr arg);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsetNoticeProcessor")]
            internal static extern global::System.IntPtr PQsetNoticeProcessor(global::System.IntPtr conn, global::System.IntPtr proc, global::System.IntPtr arg);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQregisterThreadLock")]
            internal static extern global::System.IntPtr PQregisterThreadLock(global::System.IntPtr newhandler);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQexec")]
            internal static extern global::System.IntPtr PQexec(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string query);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "PQexecParams")]
            internal static extern global::System.IntPtr PQexecParams(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string command, int nParams, uint[] paramTypes, byte** paramValues, int[] paramLengths, int[] paramFormats, int resultFormat);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQprepare")]
            internal static extern global::System.IntPtr PQprepare(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string stmtName, [MarshalAs(UnmanagedType.LPStr)] string query, int nParams, uint[] paramTypes);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQexecPrepared")]
            internal static extern global::System.IntPtr PQexecPrepared(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string stmtName, int nParams, byte** paramValues, int[] paramLengths, int[] paramFormats, int resultFormat);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsendQuery")]
            internal static extern int PQsendQuery(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string query);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsendQueryParams")]
            internal static extern int PQsendQueryParams(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string command, int nParams, uint[] paramTypes, sbyte** paramValues, int[] paramLengths, int[] paramFormats, int resultFormat);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsendPrepare")]
            internal static extern int PQsendPrepare(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string stmtName, [MarshalAs(UnmanagedType.LPStr)] string query, int nParams, uint[] paramTypes);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsendQueryPrepared")]
            internal static extern int PQsendQueryPrepared(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string stmtName, int nParams, sbyte** paramValues, int[] paramLengths, int[] paramFormats, int resultFormat);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsetSingleRowMode")]
            internal static extern int PQsetSingleRowMode(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQgetResult")]
            internal static extern global::System.IntPtr PQgetResult(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQisBusy")]
            internal static extern int PQisBusy(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQconsumeInput")]
            internal static extern int PQconsumeInput(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQnotifies")]
            internal static extern global::System.IntPtr PQnotifies(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQputCopyData")]
            internal static extern int PQputCopyData(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string buffer, int nbytes);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQputCopyEnd")]
            internal static extern int PQputCopyEnd(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string errormsg);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQgetCopyData")]
            internal static extern int PQgetCopyData(global::System.IntPtr conn, sbyte** buffer, int async);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQgetline")]
            internal static extern int PQgetline(global::System.IntPtr conn, sbyte* @string, int length);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQputline")]
            internal static extern int PQputline(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string @string);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQgetlineAsync")]
            internal static extern int PQgetlineAsync(global::System.IntPtr conn, sbyte* buffer, int bufsize);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQputnbytes")]
            internal static extern int PQputnbytes(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string buffer, int nbytes);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQendcopy")]
            internal static extern int PQendcopy(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsetnonblocking")]
            internal static extern int PQsetnonblocking(global::System.IntPtr conn, int arg);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQisnonblocking")]
            internal static extern int PQisnonblocking(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQisthreadsafe")]
            internal static extern int PQisthreadsafe();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQping")]
            internal static extern PGPing PQping([MarshalAs(UnmanagedType.LPStr)] string conninfo);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQpingParams")]
            internal static extern PGPing PQpingParams(sbyte** keywords, sbyte** values, int expand_dbname);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQflush")]
            internal static extern int PQflush(global::System.IntPtr conn);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQfn")]
            internal static extern global::System.IntPtr PQfn(global::System.IntPtr conn, int fnid, int[] result_buf, int[] result_len, int result_is_int, global::System.IntPtr args, int nargs);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQresultStatus")]
            internal static extern ExecStatusType PQresultStatus(global::System.IntPtr res);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQresStatus")]
            internal static extern IntPtr PQresStatus(ExecStatusType status);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQresultErrorMessage")]
            internal static extern IntPtr PQresultErrorMessage(global::System.IntPtr res);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQresultVerboseErrorMessage")]
            internal static extern IntPtr PQresultVerboseErrorMessage(global::System.IntPtr res, PGVerbosity verbosity, PGContextVisibility show_context);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQresultErrorField")]
            internal static extern sbyte* PQresultErrorField(global::System.IntPtr res, int fieldcode);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQntuples")]
            internal static extern int PQntuples(global::System.IntPtr res);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQnfields")]
            internal static extern int PQnfields(global::System.IntPtr res);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQbinaryTuples")]
            internal static extern int PQbinaryTuples(global::System.IntPtr res);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQfname")]
            internal static extern IntPtr PQfname(global::System.IntPtr res, int field_num);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQfnumber")]
            internal static extern int PQfnumber(global::System.IntPtr res, [MarshalAs(UnmanagedType.LPStr)] string field_name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQftable")]
            internal static extern uint PQftable(global::System.IntPtr res, int field_num);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQftablecol")]
            internal static extern int PQftablecol(global::System.IntPtr res, int field_num);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQfformat")]
            internal static extern int PQfformat(global::System.IntPtr res, int field_num);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQftype")]
            internal static extern uint PQftype(global::System.IntPtr res, int field_num);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQfsize")]
            internal static extern int PQfsize(global::System.IntPtr res, int field_num);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQfmod")]
            internal static extern int PQfmod(global::System.IntPtr res, int field_num);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQcmdStatus")]
            internal static extern sbyte* PQcmdStatus(global::System.IntPtr res);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQoidStatus")]
            internal static extern sbyte* PQoidStatus(global::System.IntPtr res);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQoidValue")]
            internal static extern uint PQoidValue(global::System.IntPtr res);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQcmdTuples")]
            internal static extern sbyte* PQcmdTuples(global::System.IntPtr res);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQgetvalue")]
            internal static extern IntPtr PQgetvalue(global::System.IntPtr res, int tup_num, int field_num);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQgetlength")]
            internal static extern int PQgetlength(global::System.IntPtr res, int tup_num, int field_num);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQgetisnull")]
            internal static extern int PQgetisnull(global::System.IntPtr res, int tup_num, int field_num);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQnparams")]
            internal static extern int PQnparams(global::System.IntPtr res);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQparamtype")]
            internal static extern uint PQparamtype(global::System.IntPtr res, int param_num);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQdescribePrepared")]
            internal static extern global::System.IntPtr PQdescribePrepared(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string stmt);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQdescribePortal")]
            internal static extern global::System.IntPtr PQdescribePortal(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string portal);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsendDescribePrepared")]
            internal static extern int PQsendDescribePrepared(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string stmt);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsendDescribePortal")]
            internal static extern int PQsendDescribePortal(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string portal);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQclear")]
            internal static extern void PQclear(global::System.IntPtr res);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQfreemem")]
            internal static extern void PQfreemem(global::System.IntPtr ptr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQmakeEmptyPGresult")]
            internal static extern global::System.IntPtr PQmakeEmptyPGresult(global::System.IntPtr conn, ExecStatusType status);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQcopyResult")]
            internal static extern global::System.IntPtr PQcopyResult(global::System.IntPtr src, int flags);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsetResultAttrs")]
            internal static extern int PQsetResultAttrs(global::System.IntPtr res, int numAttributes, global::System.IntPtr attDescs);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQresultAlloc")]
            internal static extern global::System.IntPtr PQresultAlloc(global::System.IntPtr res, ulong nBytes);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQsetvalue")]
            internal static extern int PQsetvalue(global::System.IntPtr res, int tup_num, int field_num, sbyte* value, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQescapeStringConn")]
            internal static extern ulong PQescapeStringConn(global::System.IntPtr conn, sbyte[] to, [MarshalAs(UnmanagedType.LPStr)] string from, ulong length, int[] error);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQescapeLiteral")]
            internal static extern sbyte* PQescapeLiteral(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string str, ulong len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQescapeIdentifier")]
            internal static extern sbyte* PQescapeIdentifier(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string str, ulong len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQescapeByteaConn")]
            internal static extern byte* PQescapeByteaConn(global::System.IntPtr conn, byte* from, ulong from_length, ulong* to_length);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQunescapeBytea")]
            internal static extern byte* PQunescapeBytea(byte* strtext, ulong* retbuflen);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQescapeString")]
            internal static extern ulong PQescapeString(sbyte* to, [MarshalAs(UnmanagedType.LPStr)] string from, ulong length);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQescapeBytea")]
            internal static extern byte* PQescapeBytea(byte* from, ulong from_length, ulong* to_length);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQprint")]
            internal static extern void PQprint(global::System.IntPtr fout, global::System.IntPtr res, global::System.IntPtr ps);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQdisplayTuples")]
            internal static extern void PQdisplayTuples(global::System.IntPtr res, global::System.IntPtr fp, int fillAlign, [MarshalAs(UnmanagedType.LPStr)] string fieldSep, int printHeader, int quiet);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQprintTuples")]
            internal static extern void PQprintTuples(global::System.IntPtr res, global::System.IntPtr fout, int printAttName, int terseOutput, int width);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="lo_open")]
            internal static extern int LoOpen(global::System.IntPtr conn, uint lobjId, int mode);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="lo_close")]
            internal static extern int LoClose(global::System.IntPtr conn, int fd);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="lo_read")]
            internal static extern int LoRead(global::System.IntPtr conn, int fd, sbyte* buf, ulong len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="lo_write")]
            internal static extern int LoWrite(global::System.IntPtr conn, int fd, [MarshalAs(UnmanagedType.LPStr)] string buf, ulong len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="lo_lseek")]
            internal static extern int LoLseek(global::System.IntPtr conn, int fd, int offset, int whence);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="lo_lseek64")]
            internal static extern long LoLseek64(global::System.IntPtr conn, int fd, long offset, int whence);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="lo_creat")]
            internal static extern uint LoCreat(global::System.IntPtr conn, int mode);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="lo_create")]
            internal static extern uint LoCreate(global::System.IntPtr conn, uint lobjId);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="lo_tell")]
            internal static extern int LoTell(global::System.IntPtr conn, int fd);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="lo_tell64")]
            internal static extern long LoTell64(global::System.IntPtr conn, int fd);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="lo_truncate")]
            internal static extern int LoTruncate(global::System.IntPtr conn, int fd, ulong len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="lo_truncate64")]
            internal static extern int LoTruncate64(global::System.IntPtr conn, int fd, long len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="lo_unlink")]
            internal static extern int LoUnlink(global::System.IntPtr conn, uint lobjId);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="lo_import")]
            internal static extern uint LoImport(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string filename);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="lo_import_with_oid")]
            internal static extern uint LoImportWithOid(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string filename, uint lobjId);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="lo_export")]
            internal static extern int LoExport(global::System.IntPtr conn, uint lobjId, [MarshalAs(UnmanagedType.LPStr)] string filename);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQlibVersion")]
            internal static extern int PQlibVersion();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQmblen")]
            internal static extern int PQmblen([MarshalAs(UnmanagedType.LPStr)] string s, int encoding);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQdsplen")]
            internal static extern int PQdsplen([MarshalAs(UnmanagedType.LPStr)] string s, int encoding);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQenv2encoding")]
            internal static extern int PQenv2encoding();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQencryptPassword")]
            internal static extern sbyte* PQencryptPassword([MarshalAs(UnmanagedType.LPStr)] string passwd, [MarshalAs(UnmanagedType.LPStr)] string user);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="PQencryptPasswordConn")]
            internal static extern sbyte* PQencryptPasswordConn(global::System.IntPtr conn, [MarshalAs(UnmanagedType.LPStr)] string passwd, [MarshalAs(UnmanagedType.LPStr)] string user, [MarshalAs(UnmanagedType.LPStr)] string algorithm);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="pg_char_to_encoding")]
            internal static extern int PgCharToEncoding([MarshalAs(UnmanagedType.LPStr)] string name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="pg_encoding_to_char")]
            internal static extern global::System.IntPtr PgEncodingToChar(int encoding);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="pg_valid_server_encoding_id")]
            internal static extern int PgValidServerEncodingId(int encoding);
        }

        public static PgConn PQconnectStart(string conninfo)
        {
            var __ret = __Internal.PQconnectStart(conninfo);
            PgConn __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PgConn.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PgConn) PgConn.NativeToManagedMap[__ret];
            else __result0 = PgConn.__CreateInstance(__ret);
            return __result0;
        }

        public static PgConn PQconnectStartParams(sbyte** keywords, sbyte** values, int expand_dbname)
        {
            var __ret = __Internal.PQconnectStartParams(keywords, values, expand_dbname);
            PgConn __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PgConn.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PgConn) PgConn.NativeToManagedMap[__ret];
            else __result0 = PgConn.__CreateInstance(__ret);
            return __result0;
        }

        public static PostgresPollingStatusType PQconnectPoll(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQconnectPoll(__arg0);
            return __ret;
        }

        public static PgConn PQconnectdb(string conninfo)
        {
            var __ret = __Internal.PQconnectdb(conninfo);
            PgConn __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PgConn.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PgConn) PgConn.NativeToManagedMap[__ret];
            else __result0 = PgConn.__CreateInstance(__ret);
            return __result0;
        }

        public static PgConn PQconnectdbParams(sbyte** keywords, sbyte** values, int expand_dbname)
        {
            var __ret = __Internal.PQconnectdbParams(keywords, values, expand_dbname);
            PgConn __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PgConn.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PgConn) PgConn.NativeToManagedMap[__ret];
            else __result0 = PgConn.__CreateInstance(__ret);
            return __result0;
        }

        public static PgConn PQsetdbLogin(string pghost, string pgport, string pgoptions, string pgtty, string dbName, string login, string pwd)
        {
            var __ret = __Internal.PQsetdbLogin(pghost, pgport, pgoptions, pgtty, dbName, login, pwd);
            PgConn __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PgConn.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PgConn) PgConn.NativeToManagedMap[__ret];
            else __result0 = PgConn.__CreateInstance(__ret);
            return __result0;
        }

        public static void PQfinish(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            __Internal.PQfinish(__arg0);
        }

        public static PQconninfoOption PQconndefaults()
        {
            var __ret = __Internal.PQconndefaults();
            PQconninfoOption __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PQconninfoOption.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PQconninfoOption) PQconninfoOption.NativeToManagedMap[__ret];
            else __result0 = PQconninfoOption.__CreateInstance(__ret);
            return __result0;
        }

        public static PQconninfoOption PQconninfoParse(string conninfo, sbyte** errmsg)
        {
            var __ret = __Internal.PQconninfoParse(conninfo, errmsg);
            PQconninfoOption __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PQconninfoOption.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PQconninfoOption) PQconninfoOption.NativeToManagedMap[__ret];
            else __result0 = PQconninfoOption.__CreateInstance(__ret);
            return __result0;
        }

        public static PQconninfoOption PQconninfo(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQconninfo(__arg0);
            PQconninfoOption __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PQconninfoOption.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PQconninfoOption) PQconninfoOption.NativeToManagedMap[__ret];
            else __result0 = PQconninfoOption.__CreateInstance(__ret);
            return __result0;
        }

        public static void PQconninfoFree(PQconninfoOption connOptions)
        {
            var __arg0 = ReferenceEquals(connOptions, null) ? global::System.IntPtr.Zero : connOptions.__Instance;
            __Internal.PQconninfoFree(__arg0);
        }

        public static int PQresetStart(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQresetStart(__arg0);
            return __ret;
        }

        public static PostgresPollingStatusType PQresetPoll(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQresetPoll(__arg0);
            return __ret;
        }

        public static void PQreset(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            __Internal.PQreset(__arg0);
        }

        public static PgCancel PQgetCancel(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQgetCancel(__arg0);
            PgCancel __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PgCancel.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PgCancel) PgCancel.NativeToManagedMap[__ret];
            else __result0 = PgCancel.__CreateInstance(__ret);
            return __result0;
        }

        public static void PQfreeCancel(PgCancel cancel)
        {
            var __arg0 = ReferenceEquals(cancel, null) ? global::System.IntPtr.Zero : cancel.__Instance;
            __Internal.PQfreeCancel(__arg0);
        }

        public static int PQcancel(PgCancel cancel, sbyte* errbuf, int errbufsize)
        {
            var __arg0 = ReferenceEquals(cancel, null) ? global::System.IntPtr.Zero : cancel.__Instance;
            var __ret = __Internal.PQcancel(__arg0, errbuf, errbufsize);
            return __ret;
        }

        public static int PQrequestCancel(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQrequestCancel(__arg0);
            return __ret;
        }

        public static sbyte* PQdb(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQdb(__arg0);
            return __ret;
        }

        public static sbyte* PQuser(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQuser(__arg0);
            return __ret;
        }

        public static sbyte* PQpass(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQpass(__arg0);
            return __ret;
        }

        public static sbyte* PQhost(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQhost(__arg0);
            return __ret;
        }

        public static sbyte* PQport(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQport(__arg0);
            return __ret;
        }

        public static sbyte* PQtty(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQtty(__arg0);
            return __ret;
        }

        public static sbyte* PQoptions(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQoptions(__arg0);
            return __ret;
        }

        public static ConnStatusType PQstatus(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQstatus(__arg0);
            return __ret;
        }

        public static PGTransactionStatusType PQtransactionStatus(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQtransactionStatus(__arg0);
            return __ret;
        }

        public static string PQparameterStatus(PgConn conn, string paramName)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQparameterStatus(__arg0, paramName);
            return Marshal.PtrToStringAnsi(__ret);
        }

        public static int PQprotocolVersion(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQprotocolVersion(__arg0);
            return __ret;
        }

        public static int PQserverVersion(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQserverVersion(__arg0);
            return __ret;
        }

        public static string PQerrorMessage(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQerrorMessage(__arg0);
            return Marshal.PtrToStringUTF8(__ret);
        }

        public static int PQsocket(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQsocket(__arg0);
            return __ret;
        }

        public static int PQbackendPID(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQbackendPID(__arg0);
            return __ret;
        }

        public static int PQconnectionNeedsPassword(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQconnectionNeedsPassword(__arg0);
            return __ret;
        }

        public static int PQconnectionUsedPassword(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQconnectionUsedPassword(__arg0);
            return __ret;
        }

        public static int PQclientEncoding(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQclientEncoding(__arg0);
            return __ret;
        }

        public static int PQsetClientEncoding(PgConn conn, string encoding)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQsetClientEncoding(__arg0, encoding);
            return __ret;
        }

        public static int PQsslInUse(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQsslInUse(__arg0);
            return __ret;
        }

        public static global::System.IntPtr PQsslStruct(PgConn conn, string struct_name)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQsslStruct(__arg0, struct_name);
            return __ret;
        }

        public static string PQsslAttribute(PgConn conn, string attribute_name)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQsslAttribute(__arg0, attribute_name);
            return Marshal.PtrToStringAnsi(__ret);
        }

        public static sbyte** PQsslAttributeNames(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQsslAttributeNames(__arg0);
            return __ret;
        }

        public static global::System.IntPtr PQgetssl(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQgetssl(__arg0);
            return __ret;
        }

        public static void PQinitSSL(int do_init)
        {
            __Internal.PQinitSSL(do_init);
        }

        public static void PQinitOpenSSL(int do_ssl, int do_crypto)
        {
            __Internal.PQinitOpenSSL(do_ssl, do_crypto);
        }

        public static PGVerbosity PQsetErrorVerbosity(PgConn conn, PGVerbosity verbosity)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQsetErrorVerbosity(__arg0, verbosity);
            return __ret;
        }

        public static PGContextVisibility PQsetErrorContextVisibility(PgConn conn, PGContextVisibility show_context)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQsetErrorContextVisibility(__arg0, show_context);
            return __ret;
        }

        public static void PQtrace(PgConn conn, global::System.IntPtr debug_port)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            __Internal.PQtrace(__arg0, debug_port);
        }

        public static void PQuntrace(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            __Internal.PQuntrace(__arg0);
        }

        public static PQnoticeReceiver PQsetNoticeReceiver(PgConn conn, PQnoticeReceiver proc, global::System.IntPtr arg)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __arg1 = proc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(proc);
            var __ret = __Internal.PQsetNoticeReceiver(__arg0, __arg1, arg);
            var __ptr0 = __ret;
            return __ptr0 == IntPtr.Zero? null : (PQnoticeReceiver)Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(PQnoticeReceiver));
        }

        public static PQnoticeProcessor PQsetNoticeProcessor(PgConn conn, PQnoticeProcessor proc, global::System.IntPtr arg)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __arg1 = proc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(proc);
            var __ret = __Internal.PQsetNoticeProcessor(__arg0, __arg1, arg);
            var __ptr0 = __ret;
            return __ptr0 == IntPtr.Zero? null : (PQnoticeProcessor)Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(PQnoticeProcessor));
        }

        public static PgthreadlockT PQregisterThreadLock(PgthreadlockT newhandler)
        {
            var __arg0 = newhandler == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(newhandler);
            var __ret = __Internal.PQregisterThreadLock(__arg0);
            var __ptr0 = __ret;
            return __ptr0 == IntPtr.Zero? null : (PgthreadlockT)Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(PgthreadlockT));
        }

        /// <summary>
        /// Submits a command to the server and waits for the result, with the ability to pass parameters separately from the SQL command text.
        /// </summary>
        /// <param name="conn">The connection object to send the command through.</param>
        /// <param name="command">The SQL command string to be executed.
        /// <returns>
        /// Returns a <see cref="PgResult"/> or possibly a <c>null</c>. A non-null value will generally be returned except in out-of-memory conditions or serious errors such as inability to send the command to the server. The <see cref="PQresultStatus"/> function should be called to check the return value for any errors (including the value of a null value, in which case it will return <see cref="ExecStatusType.PGRES_FATAL_ERROR"/>). Use <see cref="PQerrorMessage"/> to get more information about such errors.
        /// </returns>
        /// <remarks>
        /// The command string can include multiple SQL commands (separated by semicolons). Multiple queries sent in a single <see cref="PQexec"/> call are processed in a single transaction, unless there are explicit BEGIN/COMMIT commands included in the query string to divide it into multiple transactions. Note however that the returned PGresult structure describes only the result of the last command executed from the string. Should one of the commands fail, processing of the string stops with it and the returned <see cref="PgResult"/> describes the error condition.
        /// </remarks>
        public static PgResult PQexec(PgConn conn, string command)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQexec(__arg0, command);
            PgResult __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PgResult.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PgResult) PgResult.NativeToManagedMap[__ret];
            else __result0 = PgResult.__CreateInstance(__ret);
            return __result0;
        }

        /// <summary>
        /// Submits a command to the server and waits for the result, with the ability to pass parameters separately from the SQL command text.
        /// </summary>
        /// <param name="conn">The connection object to send the command through.</param>
        /// <param name="command">The SQL command string to be executed. If parameters are used, they are referred to in the command string as $1, $2, etc.</param>
        /// <param name="nParams">The number of parameters supplied; it is the length of the arrays paramTypes[], paramValues[], paramLengths[], and paramFormats[]. (The array pointers can be <c>null</c> when nParams is zero.)</param>
        /// <param name="paramTypes">Specifies, by OID, the data types to be assigned to the parameter symbols. If paramTypes is NULL, or any particular element in the array is zero, the server infers a data type for the parameter symbol in the same way it would do for an untyped literal string.</param>
        /// <param name="paramValues">Specifies the actual values of the parameters. A null pointer in this array means the corresponding parameter is null; otherwise the pointer points to a zero-terminated text string (for text format) or binary data in the format expected by the server (for binary format).</param>
        /// <param name="paramLengths">Specifies the actual data lengths of binary-format parameters. It is ignored for null parameters and text-format parameters. The array pointer can be null when there are no binary parameters.</param>
        /// <param name="paramFormats">Specifies whether parameters are text (put a zero in the array entry for the corresponding parameter) or binary (put a one in the array entry for the corresponding parameter). If the array pointer is null then all parameters are presumed to be text strings.</param>
        /// <param name="resultFormat">Specify zero to obtain results in text format, or one to obtain results in binary format. (There is not currently a provision to obtain different result columns in different formats, although that is possible in the underlying protocol.)</param>
        /// <returns>
        /// Returns a <see cref="PgResult"/> or possibly a <c>null</c>. A non-null value will generally be returned except in out-of-memory conditions or serious errors such as inability to send the command to the server. The <see cref="PQresultStatus"/> function should be called to check the return value for any errors (including the value of a null value, in which case it will return <see cref="ExecStatusType.PGRES_FATAL_ERROR"/>). Use <see cref="PQerrorMessage"/> to get more information about such errors.
        /// </returns>
        /// <remarks>
        /// The command string can include multiple SQL commands (separated by semicolons). Multiple queries sent in a single <see cref="PQexecParams"/> call are processed in a single transaction, unless there are explicit BEGIN/COMMIT commands included in the query string to divide it into multiple transactions. Note however that the returned PGresult structure describes only the result of the last command executed from the string. Should one of the commands fail, processing of the string stops with it and the returned <see cref="PgResult"/> describes the error condition.
        /// </remarks>
        public static PgResult PQexecParams(PgConn conn, string command, int nParams, uint[] paramTypes, byte** paramValues, int[] paramLengths, int[] paramFormats, int resultFormat)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQexecParams(__arg0, command, nParams, paramTypes, paramValues, paramLengths, paramFormats, resultFormat);
            PgResult __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PgResult.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PgResult)PgResult.NativeToManagedMap[__ret];
            else __result0 = PgResult.__CreateInstance(__ret);
            return __result0;
        }

        /// <summary>
        /// Submits a request to create a prepared statement with the given parameters, and waits for completion.
        /// </summary>
        /// <param name="conn">The connection object to send the command through.</param>
        /// <param name="stmtName">The name of the prepared statement. <see cref="stmtName"/> can be <c>""</c> to create an unnamed statement, in which case any pre-existing unnamed statement is automatically replaced; otherwise it is an error if the statement name is already defined in the current session.</param>
        /// <param name="query">The SQL command string to be executed.
        /// <param name="nParams">The number of parameters supplied; it is the length of the arrays paramTypes[], paramValues[], paramLengths[], and paramFormats[]. (The array pointers can be <c>null</c> when nParams is zero.)</param>
        /// <param name="paramTypes">Specifies, by OID, the data types to be assigned to the parameter symbols. If paramTypes is NULL, or any particular element in the array is zero, the server infers a data type for the parameter symbol in the same way it would do for an untyped literal string.</param>
        /// <returns>
        /// Returns a <see cref="PgResult"/> or possibly a <c>null</c>. A non-null value will generally be returned except in out-of-memory conditions or serious errors such as inability to send the command to the server. The <see cref="PQresultStatus"/> function should be called to check the return value for any errors (including the value of a null value, in which case it will return <see cref="ExecStatusType.PGRES_FATAL_ERROR"/>). Use <see cref="PQerrorMessage"/> to get more information about such errors.
        /// </returns>
        public static PgResult PQprepare(PgConn conn, string stmtName, string query, int nParams, uint[] paramTypes)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQprepare(__arg0, stmtName, query, nParams, paramTypes);
            PgResult __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PgResult.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PgResult) PgResult.NativeToManagedMap[__ret];
            else __result0 = PgResult.__CreateInstance(__ret);
            return __result0;
        }

        /// <summary>
        /// Submits a command to the server and waits for the result, with the ability to pass parameters separately from the SQL command text.
        /// </summary>
        /// <param name="conn">The connection object to send the command through.</param>
        /// <param name="stmtName">The name of the prepared statement. <see cref="stmtName"/> can be <c>""</c> to create an unnamed statement, in which case any pre-existing unnamed statement is automatically replaced; otherwise it is an error if the statement name is already defined in the current session.</param>
        /// <param name="nParams">The number of parameters supplied; it is the length of the arrays paramTypes[], paramValues[], paramLengths[], and paramFormats[]. (The array pointers can be <c>null</c> when nParams is zero.)</param>
        /// <param name="paramTypes">Specifies, by OID, the data types to be assigned to the parameter symbols. If paramTypes is NULL, or any particular element in the array is zero, the server infers a data type for the parameter symbol in the same way it would do for an untyped literal string.</param>
        /// <param name="paramValues">Specifies the actual values of the parameters. A null pointer in this array means the corresponding parameter is null; otherwise the pointer points to a zero-terminated text string (for text format) or binary data in the format expected by the server (for binary format).</param>
        /// <param name="paramLengths">Specifies the actual data lengths of binary-format parameters. It is ignored for null parameters and text-format parameters. The array pointer can be null when there are no binary parameters.</param>
        /// <param name="paramFormats">Specifies whether parameters are text (put a zero in the array entry for the corresponding parameter) or binary (put a one in the array entry for the corresponding parameter). If the array pointer is null then all parameters are presumed to be text strings.</param>
        /// <param name="resultFormat">Specify zero to obtain results in text format, or one to obtain results in binary format. (There is not currently a provision to obtain different result columns in different formats, although that is possible in the underlying protocol.)</param>
        /// <returns>
        /// Returns a <see cref="PgResult"/> or possibly a <c>null</c>. A non-null value will generally be returned except in out-of-memory conditions or serious errors such as inability to send the command to the server. The <see cref="PQresultStatus"/> function should be called to check the return value for any errors (including the value of a null value, in which case it will return <see cref="ExecStatusType.PGRES_FATAL_ERROR"/>). Use <see cref="PQerrorMessage"/> to get more information about such errors.
        /// </returns>
        /// <remarks>
        /// The command string can include multiple SQL commands (separated by semicolons). Multiple queries sent in a single <see cref="PQexecParams"/> call are processed in a single transaction, unless there are explicit BEGIN/COMMIT commands included in the query string to divide it into multiple transactions. Note however that the returned PGresult structure describes only the result of the last command executed from the string. Should one of the commands fail, processing of the string stops with it and the returned <see cref="PgResult"/> describes the error condition.
        /// </remarks>
        public static PgResult PQexecPrepared(PgConn conn, string stmtName, int nParams, byte** paramValues, int[] paramLengths, int[] paramFormats, int resultFormat)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQexecPrepared(__arg0, stmtName, nParams, paramValues, paramLengths, paramFormats, resultFormat);
            PgResult __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PgResult.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PgResult) PgResult.NativeToManagedMap[__ret];
            else __result0 = PgResult.__CreateInstance(__ret);
            return __result0;
        }

        public static int PQsendQuery(PgConn conn, string query)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQsendQuery(__arg0, query);
            return __ret;
        }

        public static int PQsendQueryParams(PgConn conn, string command, int nParams, uint[] paramTypes, sbyte** paramValues, int[] paramLengths, int[] paramFormats, int resultFormat)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQsendQueryParams(__arg0, command, nParams, paramTypes, paramValues, paramLengths, paramFormats, resultFormat);
            return __ret;
        }

        public static int PQsendPrepare(PgConn conn, string stmtName, string query, int nParams, uint[] paramTypes)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQsendPrepare(__arg0, stmtName, query, nParams, paramTypes);
            return __ret;
        }

        public static int PQsendQueryPrepared(PgConn conn, string stmtName, int nParams, sbyte** paramValues, int[] paramLengths, int[] paramFormats, int resultFormat)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQsendQueryPrepared(__arg0, stmtName, nParams, paramValues, paramLengths, paramFormats, resultFormat);
            return __ret;
        }

        public static int PQsetSingleRowMode(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQsetSingleRowMode(__arg0);
            return __ret;
        }

        public static PgResult PQgetResult(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQgetResult(__arg0);
            PgResult __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PgResult.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PgResult) PgResult.NativeToManagedMap[__ret];
            else __result0 = PgResult.__CreateInstance(__ret);
            return __result0;
        }

        public static int PQisBusy(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQisBusy(__arg0);
            return __ret;
        }

        public static int PQconsumeInput(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQconsumeInput(__arg0);
            return __ret;
        }

        public static PgNotify PQnotifies(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQnotifies(__arg0);
            PgNotify __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PgNotify.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PgNotify) PgNotify.NativeToManagedMap[__ret];
            else __result0 = PgNotify.__CreateInstance(__ret);
            return __result0;
        }

        public static int PQputCopyData(PgConn conn, string buffer, int nbytes)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQputCopyData(__arg0, buffer, nbytes);
            return __ret;
        }

        public static int PQputCopyEnd(PgConn conn, string errormsg)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQputCopyEnd(__arg0, errormsg);
            return __ret;
        }

        public static int PQgetCopyData(PgConn conn, sbyte** buffer, int async)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQgetCopyData(__arg0, buffer, async);
            return __ret;
        }

        public static int PQgetline(PgConn conn, sbyte* @string, int length)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQgetline(__arg0, @string, length);
            return __ret;
        }

        public static int PQputline(PgConn conn, string @string)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQputline(__arg0, @string);
            return __ret;
        }

        public static int PQgetlineAsync(PgConn conn, sbyte* buffer, int bufsize)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQgetlineAsync(__arg0, buffer, bufsize);
            return __ret;
        }

        public static int PQputnbytes(PgConn conn, string buffer, int nbytes)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQputnbytes(__arg0, buffer, nbytes);
            return __ret;
        }

        public static int PQendcopy(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQendcopy(__arg0);
            return __ret;
        }

        public static int PQsetnonblocking(PgConn conn, int arg)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQsetnonblocking(__arg0, arg);
            return __ret;
        }

        public static int PQisnonblocking(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQisnonblocking(__arg0);
            return __ret;
        }

        public static int PQisthreadsafe()
        {
            var __ret = __Internal.PQisthreadsafe();
            return __ret;
        }

        public static PGPing PQping(string conninfo)
        {
            var __ret = __Internal.PQping(conninfo);
            return __ret;
        }

        public static PGPing PQpingParams(sbyte** keywords, sbyte** values, int expand_dbname)
        {
            var __ret = __Internal.PQpingParams(keywords, values, expand_dbname);
            return __ret;
        }

        public static int PQflush(PgConn conn)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQflush(__arg0);
            return __ret;
        }

        public static PgResult PQfn(PgConn conn, int fnid, int[] result_buf, int[] result_len, int result_is_int, PQArgBlock args, int nargs)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __arg5 = ReferenceEquals(args, null) ? global::System.IntPtr.Zero : args.__Instance;
            var __ret = __Internal.PQfn(__arg0, fnid, result_buf, result_len, result_is_int, __arg5, nargs);
            PgResult __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PgResult.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PgResult) PgResult.NativeToManagedMap[__ret];
            else __result0 = PgResult.__CreateInstance(__ret);
            return __result0;
        }

        /// <summary>
        /// Returns the result status of the command.
        /// </summary>
        /// <param name="res">The result.</param>
        /// <returns>The result status.</returns>
        public static ExecStatusType PQresultStatus(PgResult res)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQresultStatus(__arg0);
            return __ret;
        }

        /// <summary>
        /// Converts the enumerated type returned by PQresultStatus into a string constant describing the status code. The caller should not free the result.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string PQresStatus(ExecStatusType status)
        {
            var __ret = __Internal.PQresStatus(status);
            return Marshal.PtrToStringUTF8(__ret);
        }

        /// <summary>
        /// Returns the error message associated with the command, or an empty string if there was no error.
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public static string PQresultErrorMessage(PgResult res)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQresultErrorMessage(__arg0);
            return Marshal.PtrToStringUTF8(__ret);
        }

        /// <summary>
        /// Returns a reformatted version of the error message associated with a PGresult object.
        /// </summary>
        /// <param name="res"></param>
        /// <param name="verbosity"></param>
        /// <param name="show_context"></param>
        /// <returns></returns>
        public static string PQresultVerboseErrorMessage(PgResult res, PGVerbosity verbosity, PGContextVisibility show_context)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQresultVerboseErrorMessage(__arg0, verbosity, show_context);
            return Marshal.PtrToStringUTF8(__ret);
        }

        public static sbyte* PQresultErrorField(PgResult res, int fieldcode)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQresultErrorField(__arg0, fieldcode);
            return __ret;
        }

        /// <summary>
        /// Returns the number of rows (tuples) in the query result. (Note that PGresult objects are limited to no more than INT_MAX rows, so an int result is sufficient.)
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public static int PQntuples(PgResult res)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQntuples(__arg0);
            return __ret;
        }

        /// <summary>
        /// Returns the number of columns (fields) in each row of the query result.
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public static int PQnfields(PgResult res)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQnfields(__arg0);
            return __ret;
        }

        public static int PQbinaryTuples(PgResult res)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQbinaryTuples(__arg0);
            return __ret;
        }

        /// <summary>
        /// Returns the column name associated with the given column number. Column numbers start at 0.
        /// </summary>
        /// <param name="res"></param>
        /// <param name="field_num"></param>
        /// <returns></returns>
        public static string PQfname(PgResult res, int field_num)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQfname(__arg0, field_num);
            return Marshal.PtrToStringUTF8(__ret);
        }

        /// <summary>
        /// Returns the column number associated with the given column name.
        /// </summary>
        /// <param name="res"></param>
        /// <param name="field_name"></param>
        /// <returns>-1 is returned if the given name does not match any column.</returns>
        public static int PQfnumber(PgResult res, string field_name)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQfnumber(__arg0, field_name);
            return __ret;
        }

        /// <summary>
        /// Returns the OID of the table from which the given column was fetched. Column numbers start at 0.
        /// </summary>
        /// <param name="res"></param>
        /// <param name="field_num"></param>
        /// <returns></returns>
        public static uint PQftable(PgResult res, int field_num)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQftable(__arg0, field_num);
            return __ret;
        }

        /// <summary>
        /// Returns the column number (within its table) of the column making up the specified query result column. Query-result column numbers start at 0, but table columns have nonzero numbers.
        /// </summary>
        /// <param name="res"></param>
        /// <param name="field_num"></param>
        /// <returns></returns>
        public static int PQftablecol(PgResult res, int field_num)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQftablecol(__arg0, field_num);
            return __ret;
        }

        public static int PQfformat(PgResult res, int field_num)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQfformat(__arg0, field_num);
            return __ret;
        }

        public static uint PQftype(PgResult res, int field_num)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQftype(__arg0, field_num);
            return __ret;
        }

        public static int PQfsize(PgResult res, int field_num)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQfsize(__arg0, field_num);
            return __ret;
        }

        public static int PQfmod(PgResult res, int field_num)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQfmod(__arg0, field_num);
            return __ret;
        }

        public static sbyte* PQcmdStatus(PgResult res)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQcmdStatus(__arg0);
            return __ret;
        }

        public static sbyte* PQoidStatus(PgResult res)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQoidStatus(__arg0);
            return __ret;
        }

        public static uint PQoidValue(PgResult res)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQoidValue(__arg0);
            return __ret;
        }

        public static sbyte* PQcmdTuples(PgResult res)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQcmdTuples(__arg0);
            return __ret;
        }

        /// <summary>
        /// Returns a single field value of one row of a PGresult. Row and column numbers start at 0.
        /// </summary>
        /// <param name="res"></param>
        /// <param name="tup_num"></param>
        /// <param name="field_num"></param>
        /// <returns></returns>
        public static string PQgetvalue(PgResult res, int tup_num, int field_num)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQgetvalue(__arg0, tup_num, field_num);
            return Marshal.PtrToStringUTF8(__ret);
        }

        /// <summary>
        /// Returns the actual length of a field value in bytes. Row and column numbers start at 0.
        /// </summary>
        /// <param name="res"></param>
        /// <param name="tup_num"></param>
        /// <param name="field_num"></param>
        /// <returns></returns>
        public static int PQgetlength(PgResult res, int tup_num, int field_num)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQgetlength(__arg0, tup_num, field_num);
            return __ret;
        }

        /// <summary>
        /// Tests a field for a null value. Row and column numbers start at 0.
        /// </summary>
        /// <param name="res"></param>
        /// <param name="tup_num"></param>
        /// <param name="field_num"></param>
        /// <returns></returns>
        public static int PQgetisnull(PgResult res, int tup_num, int field_num)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQgetisnull(__arg0, tup_num, field_num);
            return __ret;
        }

        public static int PQnparams(PgResult res)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQnparams(__arg0);
            return __ret;
        }

        public static uint PQparamtype(PgResult res, int param_num)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQparamtype(__arg0, param_num);
            return __ret;
        }

        public static PgResult PQdescribePrepared(PgConn conn, string stmt)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQdescribePrepared(__arg0, stmt);
            PgResult __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PgResult.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PgResult) PgResult.NativeToManagedMap[__ret];
            else __result0 = PgResult.__CreateInstance(__ret);
            return __result0;
        }

        public static PgResult PQdescribePortal(PgConn conn, string portal)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQdescribePortal(__arg0, portal);
            PgResult __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PgResult.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PgResult) PgResult.NativeToManagedMap[__ret];
            else __result0 = PgResult.__CreateInstance(__ret);
            return __result0;
        }

        public static int PQsendDescribePrepared(PgConn conn, string stmt)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQsendDescribePrepared(__arg0, stmt);
            return __ret;
        }

        public static int PQsendDescribePortal(PgConn conn, string portal)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQsendDescribePortal(__arg0, portal);
            return __ret;
        }

        /// <summary>
        /// Frees the storage associated with a PGresult. Every command result should be freed via PQclear when it is no longer needed.
        /// </summary>
        /// <param name="res"></param>
        public static void PQclear(PgResult res)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            __Internal.PQclear(__arg0);
        }

        public static void PQfreemem(global::System.IntPtr ptr)
        {
            __Internal.PQfreemem(ptr);
        }

        public static PgResult PQmakeEmptyPGresult(PgConn conn, ExecStatusType status)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQmakeEmptyPGresult(__arg0, status);
            PgResult __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PgResult.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PgResult) PgResult.NativeToManagedMap[__ret];
            else __result0 = PgResult.__CreateInstance(__ret);
            return __result0;
        }

        public static PgResult PQcopyResult(PgResult src, int flags)
        {
            var __arg0 = ReferenceEquals(src, null) ? global::System.IntPtr.Zero : src.__Instance;
            var __ret = __Internal.PQcopyResult(__arg0, flags);
            PgResult __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (PgResult.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (PgResult) PgResult.NativeToManagedMap[__ret];
            else __result0 = PgResult.__CreateInstance(__ret);
            return __result0;
        }

        public static int PQsetResultAttrs(PgResult res, int numAttributes, PgresAttDesc attDescs)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __arg2 = ReferenceEquals(attDescs, null) ? global::System.IntPtr.Zero : attDescs.__Instance;
            var __ret = __Internal.PQsetResultAttrs(__arg0, numAttributes, __arg2);
            return __ret;
        }

        public static global::System.IntPtr PQresultAlloc(PgResult res, ulong nBytes)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQresultAlloc(__arg0, nBytes);
            return __ret;
        }

        public static int PQsetvalue(PgResult res, int tup_num, int field_num, sbyte* value, int len)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __ret = __Internal.PQsetvalue(__arg0, tup_num, field_num, value, len);
            return __ret;
        }

        public static ulong PQescapeStringConn(PgConn conn, sbyte[] to, string from, ulong length, int[] error)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQescapeStringConn(__arg0, to, from, length, error);
            return __ret;
        }

        public static sbyte* PQescapeLiteral(PgConn conn, string str, ulong len)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQescapeLiteral(__arg0, str, len);
            return __ret;
        }

        public static sbyte* PQescapeIdentifier(PgConn conn, string str, ulong len)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQescapeIdentifier(__arg0, str, len);
            return __ret;
        }

        public static byte* PQescapeByteaConn(PgConn conn, byte* from, ulong from_length, ref ulong to_length)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            fixed (ulong* __refParamPtr3 = &to_length)
            {
                var __arg3 = __refParamPtr3;
                var __ret = __Internal.PQescapeByteaConn(__arg0, from, from_length, __arg3);
                return __ret;
            }
        }

        public static byte* PQunescapeBytea(byte* strtext, ref ulong retbuflen)
        {
            fixed (ulong* __refParamPtr1 = &retbuflen)
            {
                var __arg1 = __refParamPtr1;
                var __ret = __Internal.PQunescapeBytea(strtext, __arg1);
                return __ret;
            }
        }

        public static ulong PQescapeString(sbyte* to, string from, ulong length)
        {
            var __ret = __Internal.PQescapeString(to, from, length);
            return __ret;
        }

        public static byte* PQescapeBytea(byte* from, ulong from_length, ref ulong to_length)
        {
            fixed (ulong* __refParamPtr2 = &to_length)
            {
                var __arg2 = __refParamPtr2;
                var __ret = __Internal.PQescapeBytea(from, from_length, __arg2);
                return __ret;
            }
        }

        public static void PQprint(global::System.IntPtr fout, PgResult res, PQprintOpt ps)
        {
            var __arg1 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            var __arg2 = ReferenceEquals(ps, null) ? global::System.IntPtr.Zero : ps.__Instance;
            __Internal.PQprint(fout, __arg1, __arg2);
        }

        public static void PQdisplayTuples(PgResult res, global::System.IntPtr fp, int fillAlign, string fieldSep, int printHeader, int quiet)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            __Internal.PQdisplayTuples(__arg0, fp, fillAlign, fieldSep, printHeader, quiet);
        }

        public static void PQprintTuples(PgResult res, global::System.IntPtr fout, int printAttName, int terseOutput, int width)
        {
            var __arg0 = ReferenceEquals(res, null) ? global::System.IntPtr.Zero : res.__Instance;
            __Internal.PQprintTuples(__arg0, fout, printAttName, terseOutput, width);
        }

        public static int LoOpen(PgConn conn, uint lobjId, int mode)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.LoOpen(__arg0, lobjId, mode);
            return __ret;
        }

        public static int LoClose(PgConn conn, int fd)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.LoClose(__arg0, fd);
            return __ret;
        }

        public static int LoRead(PgConn conn, int fd, sbyte* buf, ulong len)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.LoRead(__arg0, fd, buf, len);
            return __ret;
        }

        public static int LoWrite(PgConn conn, int fd, string buf, ulong len)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.LoWrite(__arg0, fd, buf, len);
            return __ret;
        }

        public static int LoLseek(PgConn conn, int fd, int offset, int whence)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.LoLseek(__arg0, fd, offset, whence);
            return __ret;
        }

        public static long LoLseek64(PgConn conn, int fd, long offset, int whence)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.LoLseek64(__arg0, fd, offset, whence);
            return __ret;
        }

        public static uint LoCreat(PgConn conn, int mode)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.LoCreat(__arg0, mode);
            return __ret;
        }

        public static uint LoCreate(PgConn conn, uint lobjId)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.LoCreate(__arg0, lobjId);
            return __ret;
        }

        public static int LoTell(PgConn conn, int fd)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.LoTell(__arg0, fd);
            return __ret;
        }

        public static long LoTell64(PgConn conn, int fd)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.LoTell64(__arg0, fd);
            return __ret;
        }

        public static int LoTruncate(PgConn conn, int fd, ulong len)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.LoTruncate(__arg0, fd, len);
            return __ret;
        }

        public static int LoTruncate64(PgConn conn, int fd, long len)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.LoTruncate64(__arg0, fd, len);
            return __ret;
        }

        public static int LoUnlink(PgConn conn, uint lobjId)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.LoUnlink(__arg0, lobjId);
            return __ret;
        }

        public static uint LoImport(PgConn conn, string filename)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.LoImport(__arg0, filename);
            return __ret;
        }

        public static uint LoImportWithOid(PgConn conn, string filename, uint lobjId)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.LoImportWithOid(__arg0, filename, lobjId);
            return __ret;
        }

        public static int LoExport(PgConn conn, uint lobjId, string filename)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.LoExport(__arg0, lobjId, filename);
            return __ret;
        }

        public static int PQlibVersion()
        {
            var __ret = __Internal.PQlibVersion();
            return __ret;
        }

        public static int PQmblen(string s, int encoding)
        {
            var __ret = __Internal.PQmblen(s, encoding);
            return __ret;
        }

        public static int PQdsplen(string s, int encoding)
        {
            var __ret = __Internal.PQdsplen(s, encoding);
            return __ret;
        }

        public static int PQenv2encoding()
        {
            var __ret = __Internal.PQenv2encoding();
            return __ret;
        }

        public static sbyte* PQencryptPassword(string passwd, string user)
        {
            var __ret = __Internal.PQencryptPassword(passwd, user);
            return __ret;
        }

        public static sbyte* PQencryptPasswordConn(PgConn conn, string passwd, string user, string algorithm)
        {
            var __arg0 = ReferenceEquals(conn, null) ? global::System.IntPtr.Zero : conn.__Instance;
            var __ret = __Internal.PQencryptPasswordConn(__arg0, passwd, user, algorithm);
            return __ret;
        }

        public static int PgCharToEncoding(string name)
        {
            var __ret = __Internal.PgCharToEncoding(name);
            return __ret;
        }

        public static string PgEncodingToChar(int encoding)
        {
            var __ret = __Internal.PgEncodingToChar(encoding);
            return Marshal.PtrToStringAnsi(__ret);
        }

        public static int PgValidServerEncodingId(int encoding)
        {
            var __ret = __Internal.PgValidServerEncodingId(encoding);
            return __ret;
        }
    }

    
}
