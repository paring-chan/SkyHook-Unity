using System;

namespace SkyHook
{
  public class SkyHookException : Exception
  {
    public SkyHookException(string message) : base(message) { }
  }
}