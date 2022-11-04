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

        private static bool _isFocused;

        /// <summary>
        /// Whether or not the event will be received only if the game window is focused.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        public static bool RequireFocus = true;

        private bool _started;

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
            if (RequireFocus && !_isFocused)
            {
                return;
            }

            KeyUpdated.Invoke(ev);
        }

        private void _StartHook()
        {
            if (_started) return;
            
            var result = SkyHookNative.StartHook(HookCallback);

            if (result != null)
            {
                throw new SkyHookException(result);
            }

            _started = true;
        }

        private void _StopHook()
        {
            if (!_started) return;

            var result = SkyHookNative.StopHook();

            if (result != null)
            {
                throw new SkyHookException(result);
            }

            _started = false;

            _started = false;
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
            if (RequireFocus)
            {
                _isFocused = Application.isFocused;
            }
        }
    }
}