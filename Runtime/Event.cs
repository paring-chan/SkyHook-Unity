using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace SkyHook
{
  [StructLayout(LayoutKind.Sequential)]
  [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
  public struct SkyHookEvent
  {
    /// <summary>
    /// When the key was pressed.
    /// </summary>
    public readonly ulong Time;
    /// <summary>
    /// The key is pressed or released.
    /// </summary>
    public readonly EventType Type;
    /// <summary>
    /// The identified key label from the native assembly.
    /// </summary>
    public readonly ushort Label;
    /// <summary>
    /// The key number that was pressed or released.
    /// </summary>
    public readonly ushort Key;
  }

  public enum EventType
  {
    KeyPressed,
    KeyReleased
  }
}