namespace PostgreSql.Native
{
    public enum ConnStatusType
    {
        CONNECTION_OK = 0,
        CONNECTION_BAD = 1,
        CONNECTION_STARTED = 2,
        CONNECTION_MADE = 3,
        CONNECTION_AWAITING_RESPONSE = 4,
        CONNECTION_AUTH_OK = 5,
        CONNECTION_SETENV = 6,
        CONNECTION_SSL_STARTUP = 7,
        CONNECTION_NEEDED = 8,
        CONNECTION_CHECK_WRITABLE = 9,
        CONNECTION_CONSUME = 10
    }
}
