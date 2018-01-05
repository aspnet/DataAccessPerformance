using System;
using System.Runtime.InteropServices;
using System.Security;

namespace PostgreSql.Native
{
    public unsafe partial class CrtLocaleDataPublic : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr _locale_pctype;

            [FieldOffset(8)]
            internal int _locale_mb_cur_max;

            [FieldOffset(12)]
            internal uint _locale_lc_codepage;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="??0__crt_locale_data_public@@QEAA@AEBU0@@Z")]
            internal static extern global::System.IntPtr cctor(global::System.IntPtr instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, CrtLocaleDataPublic> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, CrtLocaleDataPublic>();
        protected void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static CrtLocaleDataPublic __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new CrtLocaleDataPublic(native.ToPointer(), skipVTables);
        }

        internal static CrtLocaleDataPublic __CreateInstance(CrtLocaleDataPublic.__Internal native, bool skipVTables = false)
        {
            return new CrtLocaleDataPublic(native, skipVTables);
        }

        private static void* __CopyValue(CrtLocaleDataPublic.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(CrtLocaleDataPublic.__Internal));
            *(CrtLocaleDataPublic.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private CrtLocaleDataPublic(CrtLocaleDataPublic.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected CrtLocaleDataPublic(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public CrtLocaleDataPublic()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(CrtLocaleDataPublic.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public CrtLocaleDataPublic(CrtLocaleDataPublic _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(CrtLocaleDataPublic.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((CrtLocaleDataPublic.__Internal*) __Instance) = *((CrtLocaleDataPublic.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            CrtLocaleDataPublic __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public ushort* LocalePctype
        {
            get
            {
                return (ushort*) ((CrtLocaleDataPublic.__Internal*) __Instance)->_locale_pctype;
            }

            set
            {
                ((CrtLocaleDataPublic.__Internal*) __Instance)->_locale_pctype = (global::System.IntPtr) value;
            }
        }

        public int LocaleMbCurMax
        {
            get
            {
                return ((CrtLocaleDataPublic.__Internal*) __Instance)->_locale_mb_cur_max;
            }

            set
            {
                ((CrtLocaleDataPublic.__Internal*) __Instance)->_locale_mb_cur_max = value;
            }
        }

        public uint LocaleLcCodepage
        {
            get
            {
                return ((CrtLocaleDataPublic.__Internal*) __Instance)->_locale_lc_codepage;
            }

            set
            {
                ((CrtLocaleDataPublic.__Internal*) __Instance)->_locale_lc_codepage = value;
            }
        }
    }

    
}
