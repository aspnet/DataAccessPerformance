using System;
using System.Runtime.InteropServices;
using System.Security;

namespace PostgreSql.Native
{
    public unsafe partial class CrtLocalePointers : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr locinfo;

            [FieldOffset(8)]
            internal global::System.IntPtr mbcinfo;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="??0__crt_locale_pointers@@QEAA@AEBU0@@Z")]
            internal static extern global::System.IntPtr cctor(global::System.IntPtr instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, CrtLocalePointers> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, CrtLocalePointers>();
        protected void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static CrtLocalePointers __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new CrtLocalePointers(native.ToPointer(), skipVTables);
        }

        internal static CrtLocalePointers __CreateInstance(CrtLocalePointers.__Internal native, bool skipVTables = false)
        {
            return new CrtLocalePointers(native, skipVTables);
        }

        private static void* __CopyValue(CrtLocalePointers.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(CrtLocalePointers.__Internal));
            *(CrtLocalePointers.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private CrtLocalePointers(CrtLocalePointers.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected CrtLocalePointers(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public CrtLocalePointers()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(CrtLocalePointers.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public CrtLocalePointers(CrtLocalePointers _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(CrtLocalePointers.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((CrtLocalePointers.__Internal*) __Instance) = *((CrtLocalePointers.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            CrtLocalePointers __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public CrtLocaleData Locinfo
        {
            get
            {
                CrtLocaleData __result0;
                if (((CrtLocalePointers.__Internal*) __Instance)->locinfo == IntPtr.Zero) __result0 = null;
                else if (CrtLocaleData.NativeToManagedMap.ContainsKey(((CrtLocalePointers.__Internal*) __Instance)->locinfo))
                    __result0 = (CrtLocaleData) CrtLocaleData.NativeToManagedMap[((CrtLocalePointers.__Internal*) __Instance)->locinfo];
                else __result0 = CrtLocaleData.__CreateInstance(((CrtLocalePointers.__Internal*) __Instance)->locinfo);
                return __result0;
            }

            set
            {
                ((CrtLocalePointers.__Internal*) __Instance)->locinfo = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public CrtMultibyteData Mbcinfo
        {
            get
            {
                CrtMultibyteData __result0;
                if (((CrtLocalePointers.__Internal*) __Instance)->mbcinfo == IntPtr.Zero) __result0 = null;
                else if (CrtMultibyteData.NativeToManagedMap.ContainsKey(((CrtLocalePointers.__Internal*) __Instance)->mbcinfo))
                    __result0 = (CrtMultibyteData) CrtMultibyteData.NativeToManagedMap[((CrtLocalePointers.__Internal*) __Instance)->mbcinfo];
                else __result0 = CrtMultibyteData.__CreateInstance(((CrtLocalePointers.__Internal*) __Instance)->mbcinfo);
                return __result0;
            }

            set
            {
                ((CrtLocalePointers.__Internal*) __Instance)->mbcinfo = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }
    }

    
}
