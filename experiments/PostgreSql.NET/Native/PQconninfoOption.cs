using System;
using System.Runtime.InteropServices;
using System.Security;

namespace PostgreSql.Native
{
    public unsafe partial class PQconninfoOption : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 56)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr keyword;

            [FieldOffset(8)]
            internal global::System.IntPtr envvar;

            [FieldOffset(16)]
            internal global::System.IntPtr compiled;

            [FieldOffset(24)]
            internal global::System.IntPtr val;

            [FieldOffset(32)]
            internal global::System.IntPtr label;

            [FieldOffset(40)]
            internal global::System.IntPtr dispchar;

            [FieldOffset(48)]
            internal int dispsize;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="??0_PQconninfoOption@@QEAA@AEBU0@@Z")]
            internal static extern global::System.IntPtr cctor(global::System.IntPtr instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, PQconninfoOption> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, PQconninfoOption>();
        protected void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static PQconninfoOption __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new PQconninfoOption(native.ToPointer(), skipVTables);
        }

        internal static PQconninfoOption __CreateInstance(PQconninfoOption.__Internal native, bool skipVTables = false)
        {
            return new PQconninfoOption(native, skipVTables);
        }

        private static void* __CopyValue(PQconninfoOption.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(PQconninfoOption.__Internal));
            *(PQconninfoOption.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private PQconninfoOption(PQconninfoOption.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected PQconninfoOption(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public PQconninfoOption()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(PQconninfoOption.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public PQconninfoOption(PQconninfoOption _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(PQconninfoOption.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((PQconninfoOption.__Internal*) __Instance) = *((PQconninfoOption.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            PQconninfoOption __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public sbyte* Keyword
        {
            get
            {
                return (sbyte*) ((PQconninfoOption.__Internal*) __Instance)->keyword;
            }

            set
            {
                ((PQconninfoOption.__Internal*) __Instance)->keyword = (global::System.IntPtr) value;
            }
        }

        public sbyte* Envvar
        {
            get
            {
                return (sbyte*) ((PQconninfoOption.__Internal*) __Instance)->envvar;
            }

            set
            {
                ((PQconninfoOption.__Internal*) __Instance)->envvar = (global::System.IntPtr) value;
            }
        }

        public sbyte* Compiled
        {
            get
            {
                return (sbyte*) ((PQconninfoOption.__Internal*) __Instance)->compiled;
            }

            set
            {
                ((PQconninfoOption.__Internal*) __Instance)->compiled = (global::System.IntPtr) value;
            }
        }

        public sbyte* Val
        {
            get
            {
                return (sbyte*) ((PQconninfoOption.__Internal*) __Instance)->val;
            }

            set
            {
                ((PQconninfoOption.__Internal*) __Instance)->val = (global::System.IntPtr) value;
            }
        }

        public sbyte* Label
        {
            get
            {
                return (sbyte*) ((PQconninfoOption.__Internal*) __Instance)->label;
            }

            set
            {
                ((PQconninfoOption.__Internal*) __Instance)->label = (global::System.IntPtr) value;
            }
        }

        public sbyte* Dispchar
        {
            get
            {
                return (sbyte*) ((PQconninfoOption.__Internal*) __Instance)->dispchar;
            }

            set
            {
                ((PQconninfoOption.__Internal*) __Instance)->dispchar = (global::System.IntPtr) value;
            }
        }

        public int Dispsize
        {
            get
            {
                return ((PQconninfoOption.__Internal*) __Instance)->dispsize;
            }

            set
            {
                ((PQconninfoOption.__Internal*) __Instance)->dispsize = value;
            }
        }
    }

    
}
