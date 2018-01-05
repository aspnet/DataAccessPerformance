using System;
using System.Runtime.InteropServices;
using System.Security;

namespace PostgreSql.Native
{
    public unsafe partial class PQArgBlock : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal int len;

            [FieldOffset(4)]
            internal int isint;

            [FieldOffset(8)]
            internal PQArgBlock._.__Internal u;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="??0PQArgBlock@@QEAA@AEBU0@@Z")]
            internal static extern global::System.IntPtr cctor(global::System.IntPtr instance, global::System.IntPtr _0);
        }

        public unsafe partial struct _
        {
            [StructLayout(LayoutKind.Explicit, Size = 8)]
            public partial struct __Internal
            {
                [FieldOffset(0)]
                internal global::System.IntPtr ptr;

                [FieldOffset(0)]
                internal int integer;
            }
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, PQArgBlock> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, PQArgBlock>();
        protected void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static PQArgBlock __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new PQArgBlock(native.ToPointer(), skipVTables);
        }

        internal static PQArgBlock __CreateInstance(PQArgBlock.__Internal native, bool skipVTables = false)
        {
            return new PQArgBlock(native, skipVTables);
        }

        private static void* __CopyValue(PQArgBlock.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(PQArgBlock.__Internal));
            *(PQArgBlock.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private PQArgBlock(PQArgBlock.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected PQArgBlock(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public PQArgBlock()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(PQArgBlock.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public PQArgBlock(PQArgBlock _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(PQArgBlock.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((PQArgBlock.__Internal*) __Instance) = *((PQArgBlock.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            PQArgBlock __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public int Len
        {
            get
            {
                return ((PQArgBlock.__Internal*) __Instance)->len;
            }

            set
            {
                ((PQArgBlock.__Internal*) __Instance)->len = value;
            }
        }

        public int Isint
        {
            get
            {
                return ((PQArgBlock.__Internal*) __Instance)->isint;
            }

            set
            {
                ((PQArgBlock.__Internal*) __Instance)->isint = value;
            }
        }
    }

    
}
