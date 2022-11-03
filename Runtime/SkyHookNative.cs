using System.Runtime.InteropServices;

namespace SkyHook
{
  internal class SkyHookNative
  {
    public delegate void Callback(SkyHookEvent ev);

    private const string LIB = "skyhook";

    [DllImport(LIB, EntryPoint = "start_hook", CallingConvention = CallingConvention.Cdecl)]
    public static extern string StartHook(Callback callback);

    [DllImport(LIB, EntryPoint = "stop_hook", CallingConvention = CallingConvention.Cdecl)]
    public static extern string StopHook();
  }
}