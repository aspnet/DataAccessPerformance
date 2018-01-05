using System;
using System.Runtime.InteropServices;

namespace PostgreSql.Native
{
    public unsafe partial class PgCancel
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, PgCancel> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, PgCancel>();
        protected void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static PgCancel __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new PgCancel(native.ToPointer(), skipVTables);
        }

        internal static PgCancel __CreateInstance(PgCancel.__Internal native, bool skipVTables = false)
        {
            return new PgCancel(native, skipVTables);
        }

        private static void* __CopyValue(PgCancel.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(PgCancel.__Internal));
            *(PgCancel.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private PgCancel(PgCancel.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected PgCancel(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    
}
