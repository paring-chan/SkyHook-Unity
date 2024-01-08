using System;
using System.Runtime.InteropServices;

namespace SkyHook
{
    /// <summary>
    /// Native method calls for SkyHook.
    /// </summary>
    internal static class SkyHookNative
    {
        /// <summary>
        /// The native callback handled by <see cref="SkyHookManager"/>.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void Callback(IntPtr context, SkyHookEvent ev);

        private const string Lib = "skyhook";

        /// <summary>
        /// The native version of <see cref="SkyHookManager.StartHook"/> method handled by <see cref="SkyHookManager"/>.
        /// </summary>
        /// <param name="callback">A native callback.</param>
        /// <returns><c>null</c> if no error, or an error message.</returns>
        [DllImport(Lib, EntryPoint = "start_hook", CallingConvention = CallingConvention.Cdecl)]
        public static extern string StartHook(Callback callback);

        /// <summary>
        /// The native version of <see cref="SkyHookManager.StopHook"/> method handled by <see cref="SkyHookManager"/>.
        /// </summary>
        /// <returns><c>null</c> if no error, or an error message.</returns>
        [DllImport(Lib, EntryPoint = "stop_hook", CallingConvention = CallingConvention.Cdecl)]
        public static extern string StopHook();

        /// <summary>
        /// The native version of <see cref="SkyHookManager.StopHook"/> method handled by <see cref="SkyHookManager"/>.
        /// </summary>
        /// <returns><c>null</c> if no error, or an error message.</returns>
        [DllImport(Lib, EntryPoint = "hook_is_running", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HookIsRunning();

        /// <summary>
        /// Set context variable
        /// </summary>
        /// <param name="ptr"></param>
        [DllImport(Lib, EntryPoint = "set_context", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetContext(IntPtr ptr);
    }
}
