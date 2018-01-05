using System;
using System.Runtime.InteropServices;
using System.Security;

namespace PostgreSql.Native
{
    public unsafe partial class PQprintOpt : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 40)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal sbyte header;

            [FieldOffset(1)]
            internal sbyte align;

            [FieldOffset(2)]
            internal sbyte standard;

            [FieldOffset(3)]
            internal sbyte html3;

            [FieldOffset(4)]
            internal sbyte expanded;

            [FieldOffset(5)]
            internal sbyte pager;

            [FieldOffset(8)]
            internal global::System.IntPtr fieldSep;

            [FieldOffset(16)]
            internal global::System.IntPtr tableOpt;

            [FieldOffset(24)]
            internal global::System.IntPtr caption;

            [FieldOffset(32)]
            internal global::System.IntPtr fieldName;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="??0_PQprintOpt@@QEAA@AEBU0@@Z")]
            internal static extern global::System.IntPtr cctor(global::System.IntPtr instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, PQprintOpt> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, PQprintOpt>();
        protected void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static PQprintOpt __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new PQprintOpt(native.ToPointer(), skipVTables);
        }

        internal static PQprintOpt __CreateInstance(PQprintOpt.__Internal native, bool skipVTables = false)
        {
            return new PQprintOpt(native, skipVTables);
        }

        private static void* __CopyValue(PQprintOpt.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(PQprintOpt.__Internal));
            *(PQprintOpt.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private PQprintOpt(PQprintOpt.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected PQprintOpt(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public PQprintOpt()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(PQprintOpt.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public PQprintOpt(PQprintOpt _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(PQprintOpt.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((PQprintOpt.__Internal*) __Instance) = *((PQprintOpt.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            PQprintOpt __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public sbyte Header
        {
            get
            {
                return ((PQprintOpt.__Internal*) __Instance)->header;
            }

            set
            {
                ((PQprintOpt.__Internal*) __Instance)->header = value;
            }
        }

        public sbyte Align
        {
            get
            {
                return ((PQprintOpt.__Internal*) __Instance)->align;
            }

            set
            {
                ((PQprintOpt.__Internal*) __Instance)->align = value;
            }
        }

        public sbyte Standard
        {
            get
            {
                return ((PQprintOpt.__Internal*) __Instance)->standard;
            }

            set
            {
                ((PQprintOpt.__Internal*) __Instance)->standard = value;
            }
        }

        public sbyte Html3
        {
            get
            {
                return ((PQprintOpt.__Internal*) __Instance)->html3;
            }

            set
            {
                ((PQprintOpt.__Internal*) __Instance)->html3 = value;
            }
        }

        public sbyte Expanded
        {
            get
            {
                return ((PQprintOpt.__Internal*) __Instance)->expanded;
            }

            set
            {
                ((PQprintOpt.__Internal*) __Instance)->expanded = value;
            }
        }

        public sbyte Pager
        {
            get
            {
                return ((PQprintOpt.__Internal*) __Instance)->pager;
            }

            set
            {
                ((PQprintOpt.__Internal*) __Instance)->pager = value;
            }
        }

        public sbyte* FieldSep
        {
            get
            {
                return (sbyte*) ((PQprintOpt.__Internal*) __Instance)->fieldSep;
            }

            set
            {
                ((PQprintOpt.__Internal*) __Instance)->fieldSep = (global::System.IntPtr) value;
            }
        }

        public sbyte* TableOpt
        {
            get
            {
                return (sbyte*) ((PQprintOpt.__Internal*) __Instance)->tableOpt;
            }

            set
            {
                ((PQprintOpt.__Internal*) __Instance)->tableOpt = (global::System.IntPtr) value;
            }
        }

        public sbyte* Caption
        {
            get
            {
                return (sbyte*) ((PQprintOpt.__Internal*) __Instance)->caption;
            }

            set
            {
                ((PQprintOpt.__Internal*) __Instance)->caption = (global::System.IntPtr) value;
            }
        }

        public sbyte** FieldName
        {
            get
            {
                return (sbyte**) ((PQprintOpt.__Internal*) __Instance)->fieldName;
            }

            set
            {
                ((PQprintOpt.__Internal*) __Instance)->fieldName = (global::System.IntPtr) value;
            }
        }
    }

    
}
