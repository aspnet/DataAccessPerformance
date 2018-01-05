namespace PostgreSql.Native
{
    public enum PGTransactionStatusType
    {
        PQTRANS_IDLE = 0,
        PQTRANS_ACTIVE = 1,
        PQTRANS_INTRANS = 2,
        PQTRANS_INERROR = 3,
        PQTRANS_UNKNOWN = 4
    }

    
}
