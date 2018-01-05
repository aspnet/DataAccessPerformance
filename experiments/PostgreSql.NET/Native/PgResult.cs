using System;
using System.Runtime.InteropServices;

namespace PostgreSql.Native
{
    public unsafe partial class PgResult
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, PgResult> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, PgResult>();
        protected void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static PgResult __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new PgResult(native.ToPointer(), skipVTables);
        }

        internal static PgResult __CreateInstance(PgResult.__Internal native, bool skipVTables = false)
        {
            return new PgResult(native, skipVTables);
        }

        private static void* __CopyValue(PgResult.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(PgResult.__Internal));
            *(PgResult.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private PgResult(PgResult.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected PgResult(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    
}
