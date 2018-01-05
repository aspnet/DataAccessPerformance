using System;
using System.Runtime.InteropServices;
using System.Security;

namespace PostgreSql.Native
{
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void PQnoticeReceiver(global::System.IntPtr arg, global::System.IntPtr res);

    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void PQnoticeProcessor(global::System.IntPtr arg, [MarshalAs(UnmanagedType.LPStr)] string message);

    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void PgthreadlockT(int acquire);

    public unsafe partial class Iobuf : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 8)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr _Placeholder;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="??0_iobuf@@QEAA@AEBU0@@Z")]
            internal static extern global::System.IntPtr cctor(global::System.IntPtr instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, Iobuf> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, Iobuf>();
        protected void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static Iobuf __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new Iobuf(native.ToPointer(), skipVTables);
        }

        internal static Iobuf __CreateInstance(Iobuf.__Internal native, bool skipVTables = false)
        {
            return new Iobuf(native, skipVTables);
        }

        private static void* __CopyValue(Iobuf.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(Iobuf.__Internal));
            *(Iobuf.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private Iobuf(Iobuf.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected Iobuf(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public Iobuf()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(Iobuf.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public Iobuf(Iobuf _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(Iobuf.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((Iobuf.__Internal*) __Instance) = *((Iobuf.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            Iobuf __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::System.IntPtr Placeholder
        {
            get
            {
                return ((Iobuf.__Internal*) __Instance)->_Placeholder;
            }

            set
            {
                ((Iobuf.__Internal*) __Instance)->_Placeholder = (global::System.IntPtr) value;
            }
        }
    }    
}
