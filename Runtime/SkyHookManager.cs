using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace SkyHook
{
    public class SkyHookManager : MonoBehaviour
    {
        private static SkyHookManager _instance;

        public static bool IsFocused;

        /// <summary>
        /// Whether or not the event will be received only if the game window is focused.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        public bool requireFocus = true;

        public bool isHookActive;

        /// <summary>
        /// The key updated event data
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public static readonly UnityEvent<SkyHookEvent> KeyUpdated = new();

        /// <summary>
        /// The instance of sky hook manager. The instance will be crated if it does not exist
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

        public static void StartHook()
        {
            Instance._StartHook();
        }

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