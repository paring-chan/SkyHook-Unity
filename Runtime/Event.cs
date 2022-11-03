using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace SkyHook
{
  [StructLayout(LayoutKind.Sequential)]
  [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
  public struct SkyHookEvent
  {
    /// <summary>
    /// When the key was pressed
    /// </summary>
    public readonly ulong Time;
    /// <summary>
    /// The key is pressed or released
    /// </summary>
    public readonly EventType Type;
    /// <summary>
    /// The key number that was pressed or released
    /// </summary>
    public readonly uint Key;
  }

  public enum EventType
  {
    KeyPressed,
    KeyReleased
  }
}