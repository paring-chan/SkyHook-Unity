using System;
using System.Runtime.InteropServices;
using System.Threading;
using AOT;
using UnityEngine;
using UnityEngine.Events;

namespace SkyHook
{
    /// <summary>
    /// Manages SkyHook activity.
    /// A "<see cref="GameObject.DontDestroyOnLoad"/>ed" instance will be created automatically upon use.
    /// </summary>
    public class SkyHookManager : MonoBehaviour
    {
        private static SkyHookManager _instance;

        private GCHandle? _handle = null;
        private ManualResetEvent _mre;

        /// <summary>
        /// Whether this process is focused.
        /// </summary>
        public static bool IsFocused;

        /// <summary>
        /// Whether or the event will be received only if the game window is focused.
        /// Note that only down key events will be ignored.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        public bool requireFocus = true;

        /// <summary>
        /// Whether the hook is active now.
        /// </summary>
        public bool isHookActive => SkyHookNative.HookIsRunning();

        /// <summary>
        /// Your callback for each key updated events.
        /// Use <see cref="UnityEvent.AddListener"/> to register your callback.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public static readonly UnityEvent<SkyHookEvent> KeyUpdated = new();


        /// <summary>
        /// The instance of <see cref="SkyHookManager"/>.
        /// A new instance will be created if it does not exist.
        /// <br/>
        /// This will return <c>null</c> if <see cref="Application.isPlaying"/> is <c>false</c>.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public static SkyHookManager Instance
        {
            get
            {
                if (!Application.isPlaying) return null;
                if (_instance) return _instance;

                var obj = new GameObject("SkyHook Manager");

                _instance = obj.AddComponent<SkyHookManager>();

                DontDestroyOnLoad(_instance);

                return _instance;
            }
        }

        [MonoPInvokeCallback(typeof(SkyHookNative.Callback))]
        private static void NativeHookCallback(IntPtr context, SkyHookEvent ev)
        {
            if (context == IntPtr.Zero) return;
            var handle = GCHandle.FromIntPtr(context);
            var obj = (SkyHookManager)handle.Target;
            obj.HookCallback(ev);
        }

        private void HookCallback(SkyHookEvent ev)
        {
            if (requireFocus && !IsFocused && ev.Type == EventType.KeyPressed)
            {
                return;
            }

            KeyUpdated.Invoke(ev);
        }

        private void _StartHook()
        {
            var started = false;
            Exception exception = null;

            _mre = new(false);

            _handle = GCHandle.Alloc(this, GCHandleType.Pinned);
            var ptr = GCHandle.ToIntPtr(_handle.Value);

            SkyHookNative.SetContext(ptr);

            new Thread(() =>
            {
                try
                {
                    var result = SkyHookNative.StartHook(NativeHookCallback);

                    if (result != null)
                    {
                        exception = new SkyHookException(result);
                    }

                    started = true;

                    _mre.WaitOne();

                    Debug.Log("Thread ended");
                }
                catch (Exception e)
                {
                    exception = e;
                    Debug.LogError(e);
                    throw;
                }
            }).Start();

            while (!started && exception == null)
            {
                Thread.Yield();
            }

            if (exception != null)
            {
                throw exception;
            }
        }

        private void _StopHook()
        {
            var result = SkyHookNative.StopHook();

            if (_handle.HasValue)
            {
                _handle.Value.Free();
                _handle = null;
            }

            if (result != null)
            {
                throw new SkyHookException(result);
            }

            if (_mre != null)
            {
                _mre.Set();
            }
        }

        /// <summary>
        /// Starts the native hook.
        /// <br/>
        /// This will only work if <see cref="Application.isPlaying"/> is <c>true</c>.
        /// </summary>
        public static void StartHook()
        {
            if (!Application.isPlaying)
            {
                Debug.LogWarning("You may not call StartHook() if the application is not playing.");
                return;
            }

            Instance._StartHook();
        }

        /// <summary>
        /// Stops the native hook.
        /// <br/>
        /// This will only work if <see cref="Application.isPlaying"/> is <c>true</c>.
        /// </summary>
        public static void StopHook()
        {
            if (!Application.isPlaying)
            {
                Debug.LogWarning("You may not call StopHook() if the application is not playing.");
                return;
            }

            Instance._StopHook();
        }

        private void OnDestroy()
        {
            if (isHookActive)
            {
                _StopHook();
            }
        }

        private void Update()
        {
            if (requireFocus)
            {
                IsFocused = Application.isFocused;
            }
        }
    }
}