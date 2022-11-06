using System;
using System.Threading;
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
        public bool isHookActive;

        /// <summary>
        /// Your callback for each key updated events.
        /// Use <see cref="UnityEvent.AddListener"/> to register your callback.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public static readonly UnityEvent<SkyHookEvent> KeyUpdated = new();

        /// <summary>
        /// The instance of <see cref="SkyHookManager"/>.
        /// A new instance will be created if it does not exist.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public static SkyHookManager Instance
        {
            get
            {
                if (_instance) return _instance;

                var obj = new GameObject("SkyHook Manager");

                _instance = obj.AddComponent<SkyHookManager>();

                DontDestroyOnLoad(_instance);

                return _instance;
            }
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

            new Thread(() =>
            {
                if (isHookActive) return;

                var result = SkyHookNative.StartHook(HookCallback);

                if (result != null)
                {
                    exception = new SkyHookException(result);
                }

                isHookActive = true;
                started = true;

                while (isHookActive)
                {
                }
            }).Start();

            while (!started && exception == null)
            {
            }

            if (exception != null)
            {
                throw exception;
            }
        }

        private void _StopHook()
        {
            if (!isHookActive) return;

            var result = SkyHookNative.StopHook();

            if (result != null)
            {
                throw new SkyHookException(result);
            }

            isHookActive = false;
        }

        /// <summary>
        /// Starts the native hook.
        /// </summary>
        public static void StartHook()
        {
            Instance._StartHook();
        }

        /// <summary>
        /// Stops the native hook.
        /// </summary>
        public static void StopHook()
        {
            Instance._StopHook();
        }

        private void OnDestroy()
        {
            _StopHook();
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
