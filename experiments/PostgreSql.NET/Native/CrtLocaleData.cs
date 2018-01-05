using System;
using System.Runtime.InteropServices;

namespace PostgreSql.Native
{
    public unsafe partial class CrtLocaleData
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, CrtLocaleData> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, CrtLocaleData>();
        protected void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static CrtLocaleData __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new CrtLocaleData(native.ToPointer(), skipVTables);
        }

        internal static CrtLocaleData __CreateInstance(CrtLocaleData.__Internal native, bool skipVTables = false)
        {
            return new CrtLocaleData(native, skipVTables);
        }

        private static void* __CopyValue(CrtLocaleData.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(CrtLocaleData.__Internal));
            *(CrtLocaleData.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private CrtLocaleData(CrtLocaleData.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected CrtLocaleData(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    
}
