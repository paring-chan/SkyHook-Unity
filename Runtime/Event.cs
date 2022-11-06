using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace SkyHook
{
  /// <summary>
  /// Recorded key updates from SkyHook.
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
  public struct SkyHookEvent
  {
    /// <summary>
    /// When the key's state was updated.
    /// </summary>
    public readonly ulong Time;
    /// <summary>
    /// Whether the key is pressed or released.
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

  /// <summary>
  /// The type of <see cref="SkyHookEvent"/>'s event.
  /// </summary>
  public enum EventType
  {
    KeyPressed,
    KeyReleased
  }
}