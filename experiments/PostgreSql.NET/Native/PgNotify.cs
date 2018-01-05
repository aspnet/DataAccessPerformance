using System;
using System.Runtime.InteropServices;
using System.Security;

namespace PostgreSql.Native
{
    public unsafe partial class PgNotify : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 32)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr relname;

            [FieldOffset(8)]
            internal int be_pid;

            [FieldOffset(16)]
            internal global::System.IntPtr extra;

            [FieldOffset(24)]
            internal global::System.IntPtr next;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="??0pgNotify@@QEAA@AEBU0@@Z")]
            internal static extern global::System.IntPtr cctor(global::System.IntPtr instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, PgNotify> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, PgNotify>();
        protected void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static PgNotify __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new PgNotify(native.ToPointer(), skipVTables);
        }

        internal static PgNotify __CreateInstance(PgNotify.__Internal native, bool skipVTables = false)
        {
            return new PgNotify(native, skipVTables);
        }

        private static void* __CopyValue(PgNotify.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(PgNotify.__Internal));
            *(PgNotify.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private PgNotify(PgNotify.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected PgNotify(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public PgNotify()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(PgNotify.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public PgNotify(PgNotify _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(PgNotify.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((PgNotify.__Internal*) __Instance) = *((PgNotify.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            PgNotify __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public sbyte* Relname
        {
            get
            {
                return (sbyte*) ((PgNotify.__Internal*) __Instance)->relname;
            }

            set
            {
                ((PgNotify.__Internal*) __Instance)->relname = (global::System.IntPtr) value;
            }
        }

        public int BePid
        {
            get
            {
                return ((PgNotify.__Internal*) __Instance)->be_pid;
            }

            set
            {
                ((PgNotify.__Internal*) __Instance)->be_pid = value;
            }
        }

        public sbyte* Extra
        {
            get
            {
                return (sbyte*) ((PgNotify.__Internal*) __Instance)->extra;
            }

            set
            {
                ((PgNotify.__Internal*) __Instance)->extra = (global::System.IntPtr) value;
            }
        }

        public PgNotify Next
        {
            get
            {
                PgNotify __result0;
                if (((PgNotify.__Internal*) __Instance)->next == IntPtr.Zero) __result0 = null;
                else if (PgNotify.NativeToManagedMap.ContainsKey(((PgNotify.__Internal*) __Instance)->next))
                    __result0 = (PgNotify) PgNotify.NativeToManagedMap[((PgNotify.__Internal*) __Instance)->next];
                else __result0 = PgNotify.__CreateInstance(((PgNotify.__Internal*) __Instance)->next);
                return __result0;
            }

            set
            {
                ((PgNotify.__Internal*) __Instance)->next = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }
    }

    
}
