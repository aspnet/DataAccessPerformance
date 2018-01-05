namespace PostgreSql.Native
{
    public enum ExecStatusType
    {
        /// <summary>
        /// The string sent to the server was empty.
        /// </summary>
        PGRES_EMPTY_QUERY = 0,
        /// <summary>
        /// Successful completion of a command returning no data.
        /// </summary>
        PGRES_COMMAND_OK = 1,
        /// <summary>
        /// Successful completion of a command returning data (such as a SELECT or SHOW).
        /// </summary>
        PGRES_TUPLES_OK = 2,
        /// <summary>
        /// Copy Out (from server) data transfer started.
        /// </summary>
        PGRES_COPY_OUT = 3,
        /// <summary>
        /// Copy In (to server) data transfer started.
        /// </summary>
        PGRES_COPY_IN = 4,
        /// <summary>
        /// The server's response was not understood.
        /// </summary>
        PGRES_BAD_RESPONSE = 5,
        /// <summary>
        /// A nonfatal error (a notice or warning) occurred.
        /// </summary>
        PGRES_NONFATAL_ERROR = 6,
        /// <summary>
        /// A fatal error occurred.
        /// </summary>
        PGRES_FATAL_ERROR = 7,
        /// <summary>
        /// Copy In/Out (to and from server) data transfer started. This feature is currently used only for streaming replication, so this status should not occur in ordinary applications.
        /// </summary>
        PGRES_COPY_BOTH = 8,
        /// <summary>
        /// The PGresult contains a single result tuple from the current command. This status occurs only when single-row mode has been selected for the query.
        /// </summary>
        PGRES_SINGLE_TUPLE = 9
    }

    
}
