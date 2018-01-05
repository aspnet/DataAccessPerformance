using System;
using System.Runtime.InteropServices;

namespace PostgreSql.Native
{
    public unsafe partial class CrtMultibyteData
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, CrtMultibyteData> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, CrtMultibyteData>();
        protected void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static CrtMultibyteData __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new CrtMultibyteData(native.ToPointer(), skipVTables);
        }

        internal static CrtMultibyteData __CreateInstance(CrtMultibyteData.__Internal native, bool skipVTables = false)
        {
            return new CrtMultibyteData(native, skipVTables);
        }

        private static void* __CopyValue(CrtMultibyteData.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(CrtMultibyteData.__Internal));
            *(CrtMultibyteData.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private CrtMultibyteData(CrtMultibyteData.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected CrtMultibyteData(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    
}
