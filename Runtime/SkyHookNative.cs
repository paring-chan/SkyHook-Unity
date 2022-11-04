using System.Runtime.InteropServices;

namespace SkyHook
{
  internal static class SkyHookNative
  {
    public delegate void Callback(SkyHookEvent ev);

    private const string Lib = "skyhook";

    [DllImport(Lib, EntryPoint = "start_hook", CallingConvention = CallingConvention.Cdecl)]
    public static extern string StartHook(Callback callback);

    [DllImport(Lib, EntryPoint = "stop_hook", CallingConvention = CallingConvention.Cdecl)]
    public static extern string StopHook();
  }
}