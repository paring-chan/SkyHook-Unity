using System;

namespace SkyHook
{
    /// <summary>
    /// An <see cref="Exception"/> that specifically occurred in SkyHook.
    /// </summary>
    public class SkyHookException : Exception
    {
	    /// <summary>
	    /// Initializes an instance of <see cref="SkyHookException"/>.
	    /// </summary>
	    /// <param name="message">A message to pass along with exception.</param>
		public SkyHookException(string message) : base(message) { }
    }
}
