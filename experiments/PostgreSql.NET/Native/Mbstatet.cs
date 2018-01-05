using System;
using System.Runtime.InteropServices;
using System.Security;

namespace PostgreSql.Native
{
    public unsafe partial class Mbstatet : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 8)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal uint _Wchar;

            [FieldOffset(4)]
            internal ushort _Byte;

            [FieldOffset(6)]
            internal ushort _State;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpq", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="??0_Mbstatet@@QEAA@AEBU0@@Z")]
            internal static extern global::System.IntPtr cctor(global::System.IntPtr instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        protected int __PointerAdjustment;
        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, Mbstatet> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, Mbstatet>();
        protected void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static Mbstatet __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new Mbstatet(native.ToPointer(), skipVTables);
        }

        internal static Mbstatet __CreateInstance(Mbstatet.__Internal native, bool skipVTables = false)
        {
            return new Mbstatet(native, skipVTables);
        }

        private static void* __CopyValue(Mbstatet.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(Mbstatet.__Internal));
            *(Mbstatet.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private Mbstatet(Mbstatet.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected Mbstatet(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public Mbstatet()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(Mbstatet.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public Mbstatet(Mbstatet _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(Mbstatet.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((Mbstatet.__Internal*) __Instance) = *((Mbstatet.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            Mbstatet __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public uint Wchar
        {
            get
            {
                return ((Mbstatet.__Internal*) __Instance)->_Wchar;
            }

            set
            {
                ((Mbstatet.__Internal*) __Instance)->_Wchar = value;
            }
        }

        public ushort Byte
        {
            get
            {
                return ((Mbstatet.__Internal*) __Instance)->_Byte;
            }

            set
            {
                ((Mbstatet.__Internal*) __Instance)->_Byte = value;
            }
        }

        public ushort State
        {
            get
            {
                return ((Mbstatet.__Internal*) __Instance)->_State;
            }

            set
            {
                ((Mbstatet.__Internal*) __Instance)->_State = value;
            }
        }
    }

    
}
