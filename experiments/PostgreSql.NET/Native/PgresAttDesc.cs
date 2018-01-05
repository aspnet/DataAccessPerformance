using System;
using System.Runtime.InteropServices;
using System.Security;

namespace PostgreSql.Native
{
    public unsafe partial class PgresAttDesc : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 32)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr name;

            [FieldOffset(8)]
            internal uint tableid;

            [FieldOffset(12)]
            internal int columnid;

            [FieldOffset(16)]
            internal int format;

            [FieldOffset(20)]
            internal uint typid;

            [FieldOffset(24)]
            internal int typlen;

            [FieldOffset(28)]
            internal int atttypmod;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="??0pgresAttDesc@@QEAA@AEBU0@@Z")]
            internal static extern global::System.IntPtr cctor(global::System.IntPtr instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, PgresAttDesc> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, PgresAttDesc>();
        protected void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static PgresAttDesc __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new PgresAttDesc(native.ToPointer(), skipVTables);
        }

        internal static PgresAttDesc __CreateInstance(PgresAttDesc.__Internal native, bool skipVTables = false)
        {
            return new PgresAttDesc(native, skipVTables);
        }

        private static void* __CopyValue(PgresAttDesc.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(PgresAttDesc.__Internal));
            *(PgresAttDesc.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private PgresAttDesc(PgresAttDesc.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected PgresAttDesc(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public PgresAttDesc()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(PgresAttDesc.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public PgresAttDesc(PgresAttDesc _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(PgresAttDesc.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((PgresAttDesc.__Internal*) __Instance) = *((PgresAttDesc.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            PgresAttDesc __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public sbyte* Name
        {
            get
            {
                return (sbyte*) ((PgresAttDesc.__Internal*) __Instance)->name;
            }

            set
            {
                ((PgresAttDesc.__Internal*) __Instance)->name = (global::System.IntPtr) value;
            }
        }

        public uint Tableid
        {
            get
            {
                return ((PgresAttDesc.__Internal*) __Instance)->tableid;
            }

            set
            {
                ((PgresAttDesc.__Internal*) __Instance)->tableid = value;
            }
        }

        public int Columnid
        {
            get
            {
                return ((PgresAttDesc.__Internal*) __Instance)->columnid;
            }

            set
            {
                ((PgresAttDesc.__Internal*) __Instance)->columnid = value;
            }
        }

        public int Format
        {
            get
            {
                return ((PgresAttDesc.__Internal*) __Instance)->format;
            }

            set
            {
                ((PgresAttDesc.__Internal*) __Instance)->format = value;
            }
        }

        public uint Typid
        {
            get
            {
                return ((PgresAttDesc.__Internal*) __Instance)->typid;
            }

            set
            {
                ((PgresAttDesc.__Internal*) __Instance)->typid = value;
            }
        }

        public int Typlen
        {
            get
            {
                return ((PgresAttDesc.__Internal*) __Instance)->typlen;
            }

            set
            {
                ((PgresAttDesc.__Internal*) __Instance)->typlen = value;
            }
        }

        public int Atttypmod
        {
            get
            {
                return ((PgresAttDesc.__Internal*) __Instance)->atttypmod;
            }

            set
            {
                ((PgresAttDesc.__Internal*) __Instance)->atttypmod = value;
            }
        }
    }

    
}
