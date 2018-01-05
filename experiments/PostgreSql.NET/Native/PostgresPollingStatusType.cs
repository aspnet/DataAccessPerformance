namespace PostgreSql.Native
{
    public enum PostgresPollingStatusType
    {
        PGRES_POLLING_FAILED = 0,
        PGRES_POLLING_READING = 1,
        PGRES_POLLING_WRITING = 2,
        PGRES_POLLING_OK = 3,
        PGRES_POLLING_ACTIVE = 4
    }

    
}
