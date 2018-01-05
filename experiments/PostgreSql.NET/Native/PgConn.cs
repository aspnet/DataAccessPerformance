using System;
using System.Runtime.InteropServices;

namespace PostgreSql.Native
{
    public unsafe partial class PgConn
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, PgConn> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, PgConn>();
        protected void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static PgConn __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new PgConn(native.ToPointer(), skipVTables);
        }

        internal static PgConn __CreateInstance(PgConn.__Internal native, bool skipVTables = false)
        {
            return new PgConn(native, skipVTables);
        }

        private static void* __CopyValue(PgConn.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(PgConn.__Internal));
            *(PgConn.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private PgConn(PgConn.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected PgConn(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    
}
