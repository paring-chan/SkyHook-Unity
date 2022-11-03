using System.Runtime.InteropServices;

namespace SkyHook
{
  [StructLayout(LayoutKind.Sequential)]
  public struct SkyHookEvent
  {
    public ulong Time;
    public short Type;
    public uint Key;
  }

  public enum EventType
  {
    KeyPressed,
    KeyReleased
  }
}