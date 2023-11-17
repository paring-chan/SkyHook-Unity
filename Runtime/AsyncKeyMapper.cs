using System.Collections.Generic;
using UnityEngine;

namespace SkyHook
{
    public static class AsyncKeyMapper
    {
        private static readonly Dictionary<KeyLabel, KeyCode> AsyncKeyToUnityKeyMap = new();
        private static readonly Dictionary<KeyCode, KeyLabel> UnityKeyToAsyncKeyMap = new();

        private static void AddMapping(KeyCode unityKey, KeyLabel asyncKey)
        {
            AsyncKeyToUnityKeyMap[asyncKey] = unityKey;
            UnityKeyToAsyncKeyMap[unityKey] = asyncKey;
        }

        public static KeyCode AsyncKeyToUnityKey(KeyLabel key) =>
            AsyncKeyToUnityKeyMap.GetValueOrDefault(key, KeyCode.None);

        public static KeyLabel UnityKeyToAsyncKey(KeyCode key) =>
            UnityKeyToAsyncKeyMap.GetValueOrDefault(key, KeyLabel.Unknown);

        static AsyncKeyMapper()
        {
            AddMapping(KeyCode.Backspace, KeyLabel.Backspace);
            AddMapping(KeyCode.Tab, KeyLabel.Tab);
            // Clear
            AddMapping(KeyCode.Return, KeyLabel.Enter);
            AddMapping(KeyCode.Pause, KeyLabel.PauseBreak);
            AddMapping(KeyCode.Escape, KeyLabel.Escape);
            AddMapping(KeyCode.Space, KeyLabel.Space);
            // Exclaim
            // DoubleQuote
            // Hash
            // Dollar
            // Percent
            // Percent
            // Ampersand
            // Quote
            // LeftParen
            // RightParen
            // Asterisk
            // Plus
            AddMapping(KeyCode.Comma, KeyLabel.Comma);
            AddMapping(KeyCode.Minus, KeyLabel.Minus);
            AddMapping(KeyCode.Period, KeyLabel.Dot);
            AddMapping(KeyCode.Slash, KeyLabel.Slash);
            AddMapping(KeyCode.Alpha0, KeyLabel.Alpha0);
            AddMapping(KeyCode.Alpha1, KeyLabel.Alpha1);
            AddMapping(KeyCode.Alpha2, KeyLabel.Alpha2);
            AddMapping(KeyCode.Alpha3, KeyLabel.Alpha3);
            AddMapping(KeyCode.Alpha4, KeyLabel.Alpha4);
            AddMapping(KeyCode.Alpha5, KeyLabel.Alpha5);
            AddMapping(KeyCode.Alpha6, KeyLabel.Alpha6);
            AddMapping(KeyCode.Alpha7, KeyLabel.Alpha7);
            AddMapping(KeyCode.Alpha8, KeyLabel.Alpha8);
            AddMapping(KeyCode.Alpha9, KeyLabel.Alpha9);

            AddMapping(KeyCode.Colon, KeyLabel.Semicolon);
            AddMapping(KeyCode.Semicolon, KeyLabel.Semicolon);
            AddMapping(KeyCode.Less, KeyLabel.Comma);
            AddMapping(KeyCode.Equals, KeyLabel.Equal);
            AddMapping(KeyCode.Greater, KeyLabel.Equal);
            AddMapping(KeyCode.Question, KeyLabel.Slash);
            // At

            AddMapping(KeyCode.LeftBracket, KeyLabel.LeftBrace);
            AddMapping(KeyCode.Backslash, KeyLabel.BackSlash);
            AddMapping(KeyCode.RightBracket, KeyLabel.RightBrace);
            // Caret
            // Underscore
            // BackQuote

            AddMapping(KeyCode.A, KeyLabel.A);
            AddMapping(KeyCode.B, KeyLabel.B);
            AddMapping(KeyCode.C, KeyLabel.C);
            AddMapping(KeyCode.D, KeyLabel.D);
            AddMapping(KeyCode.E, KeyLabel.E);
            AddMapping(KeyCode.F, KeyLabel.F);
            AddMapping(KeyCode.G, KeyLabel.G);
            AddMapping(KeyCode.H, KeyLabel.H);
            AddMapping(KeyCode.I, KeyLabel.I);
            AddMapping(KeyCode.J, KeyLabel.J);
            AddMapping(KeyCode.K, KeyLabel.K);
            AddMapping(KeyCode.L, KeyLabel.L);
            AddMapping(KeyCode.M, KeyLabel.M);
            AddMapping(KeyCode.N, KeyLabel.N);
            AddMapping(KeyCode.O, KeyLabel.O);
            AddMapping(KeyCode.P, KeyLabel.P);
            AddMapping(KeyCode.Q, KeyLabel.Q);
            AddMapping(KeyCode.R, KeyLabel.R);
            AddMapping(KeyCode.S, KeyLabel.S);
            AddMapping(KeyCode.T, KeyLabel.T);
            AddMapping(KeyCode.U, KeyLabel.U);
            AddMapping(KeyCode.V, KeyLabel.V);
            AddMapping(KeyCode.W, KeyLabel.W);
            AddMapping(KeyCode.X, KeyLabel.X);
            AddMapping(KeyCode.Y, KeyLabel.Y);
            AddMapping(KeyCode.Z, KeyLabel.Z);

            AddMapping(KeyCode.LeftCurlyBracket, KeyLabel.LeftBrace);
            AddMapping(KeyCode.RightCurlyBracket, KeyLabel.RightBrace);
            AddMapping(KeyCode.Pipe, KeyLabel.BackSlash);
            AddMapping(KeyCode.Tilde, KeyLabel.Grave);

            AddMapping(KeyCode.Delete, KeyLabel.Delete);
            AddMapping(KeyCode.Keypad0, KeyLabel.Keypad0);
            AddMapping(KeyCode.Keypad1, KeyLabel.Keypad1);
            AddMapping(KeyCode.Keypad2, KeyLabel.Keypad2);
            AddMapping(KeyCode.Keypad3, KeyLabel.Keypad3);
            AddMapping(KeyCode.Keypad4, KeyLabel.Keypad4);
            AddMapping(KeyCode.Keypad5, KeyLabel.Keypad5);
            AddMapping(KeyCode.Keypad6, KeyLabel.Keypad6);
            AddMapping(KeyCode.Keypad7, KeyLabel.Keypad7);
            AddMapping(KeyCode.Keypad8, KeyLabel.Keypad8);
            AddMapping(KeyCode.Keypad9, KeyLabel.Keypad9);

            AddMapping(KeyCode.KeypadPeriod, KeyLabel.KeypadDot);
            AddMapping(KeyCode.KeypadDivide, KeyLabel.KeypadSlash);
            AddMapping(KeyCode.KeypadMultiply, KeyLabel.KeypadAsterisk);
            AddMapping(KeyCode.KeypadMinus, KeyLabel.KeypadMinus);
            AddMapping(KeyCode.KeypadPlus, KeyLabel.KeypadPlus);
            AddMapping(KeyCode.KeypadEnter, KeyLabel.KeypadEnter);
            // KeypadEquals
            AddMapping(KeyCode.UpArrow, KeyLabel.ArrowUp);
            AddMapping(KeyCode.DownArrow, KeyLabel.ArrowDown);
            AddMapping(KeyCode.RightArrow, KeyLabel.ArrowRight);
            AddMapping(KeyCode.LeftArrow, KeyLabel.ArrowLeft);
            AddMapping(KeyCode.Insert, KeyLabel.Insert);
            AddMapping(KeyCode.Home, KeyLabel.Home);
            AddMapping(KeyCode.End, KeyLabel.End);
            AddMapping(KeyCode.PageUp, KeyLabel.PageUp);
            AddMapping(KeyCode.PageDown, KeyLabel.PageDown);

            AddMapping(KeyCode.F1, KeyLabel.F1);
            AddMapping(KeyCode.F2, KeyLabel.F2);
            AddMapping(KeyCode.F3, KeyLabel.F3);
            AddMapping(KeyCode.F4, KeyLabel.F4);
            AddMapping(KeyCode.F5, KeyLabel.F5);
            AddMapping(KeyCode.F6, KeyLabel.F6);
            AddMapping(KeyCode.F7, KeyLabel.F7);
            AddMapping(KeyCode.F8, KeyLabel.F8);
            AddMapping(KeyCode.F9, KeyLabel.F9);
            AddMapping(KeyCode.F10, KeyLabel.F10);
            AddMapping(KeyCode.F11, KeyLabel.F11);
            AddMapping(KeyCode.F12, KeyLabel.F12);
            AddMapping(KeyCode.F13, KeyLabel.F13);
            AddMapping(KeyCode.F14, KeyLabel.F14);
            AddMapping(KeyCode.F15, KeyLabel.F15);

            AddMapping(KeyCode.Numlock, KeyLabel.NumLock);
            AddMapping(KeyCode.CapsLock, KeyLabel.CapsLock);
            AddMapping(KeyCode.ScrollLock, KeyLabel.ScrollLock);

            AddMapping(KeyCode.RightShift, KeyLabel.RShift);
            AddMapping(KeyCode.LeftShift, KeyLabel.LShift);
            AddMapping(KeyCode.RightControl, KeyLabel.RControl);
            AddMapping(KeyCode.LeftControl, KeyLabel.LControl);

            AddMapping(KeyCode.RightAlt, KeyLabel.RAlt);
            AddMapping(KeyCode.LeftAlt, KeyLabel.LAlt);

            AddMapping(KeyCode.LeftApple, KeyLabel.Super);
            AddMapping(KeyCode.RightApple, KeyLabel.Super);
            AddMapping(KeyCode.LeftMeta, KeyLabel.Super);
            AddMapping(KeyCode.RightMeta, KeyLabel.Super);
            AddMapping(KeyCode.LeftWindows, KeyLabel.Super);
            AddMapping(KeyCode.RightWindows, KeyLabel.Super);

            // AltGr
            // Help
            AddMapping(KeyCode.Print, KeyLabel.PrintScreen);
            // SysReq
            // Break
            // Menu
            AddMapping(KeyCode.Mouse0, KeyLabel.MouseLeft);
            AddMapping(KeyCode.Mouse1, KeyLabel.MouseRight);
            AddMapping(KeyCode.Mouse2, KeyLabel.MouseMiddle);
            AddMapping(KeyCode.Mouse3, KeyLabel.MouseX1);
            AddMapping(KeyCode.Mouse4, KeyLabel.MouseX2);
            // AddMapping(KeyCode.Mouse5, KeyLabel.MouseLeft);
            // AddMapping(KeyCode.Mouse6, KeyLabel.MouseLeft);

            // JoystickButton0
            // JoystickButton1
            // JoystickButton2
            // JoystickButton3
            // JoystickButton4
            // JoystickButton5
            // JoystickButton6
            // JoystickButton7
            // JoystickButton8
            // JoystickButton9
            // JoystickButton10
            // JoystickButton11
            // JoystickButton12
            // JoystickButton13
            // JoystickButton14
            // JoystickButton15
            // JoystickButton16
            // JoystickButton17
            // JoystickButton18
            // JoystickButton19

            // Joystick1Button0
            // Joystick1Button1
            // Joystick1Button2
            // Joystick1Button3
            // Joystick1Button4
            // Joystick1Button5
            // Joystick1Button6
            // Joystick1Button7
            // Joystick1Button8
            // Joystick1Button9
            // Joystick1Button10
            // Joystick1Button11
            // Joystick1Button12
            // Joystick1Button13
            // Joystick1Button14
            // Joystick1Button15
            // Joystick1Button16
            // Joystick1Button17
            // Joystick1Button18
            // Joystick1Button19

            // Joystick2Button0
            // Joystick2Button1
            // Joystick2Button2
            // Joystick2Button3
            // Joystick2Button4
            // Joystick2Button5
            // Joystick2Button6
            // Joystick2Button7
            // Joystick2Button8
            // Joystick2Button9
            // Joystick2Button10
            // Joystick2Button11
            // Joystick2Button12
            // Joystick2Button13
            // Joystick2Button14
            // Joystick2Button15
            // Joystick2Button16
            // Joystick2Button17
            // Joystick2Button18
            // Joystick2Button19

            // Joystick3Button0
            // Joystick3Button1
            // Joystick3Button2
            // Joystick3Button3
            // Joystick3Button4
            // Joystick3Button5
            // Joystick3Button6
            // Joystick3Button7
            // Joystick3Button8
            // Joystick3Button9
            // Joystick3Button10
            // Joystick3Button11
            // Joystick3Button12
            // Joystick3Button13
            // Joystick3Button14
            // Joystick3Button15
            // Joystick3Button16
            // Joystick3Button17
            // Joystick3Button18
            // Joystick3Button19

            // Joystick4Button0
            // Joystick4Button1
            // Joystick4Button2
            // Joystick4Button3
            // Joystick4Button4
            // Joystick4Button5
            // Joystick4Button6
            // Joystick4Button7
            // Joystick4Button8
            // Joystick4Button9
            // Joystick4Button10
            // Joystick4Button11
            // Joystick4Button12
            // Joystick4Button13
            // Joystick4Button14
            // Joystick4Button15
            // Joystick4Button16
            // Joystick4Button17
            // Joystick4Button18
            // Joystick4Button19

            // Joystick5Button0
            // Joystick5Button1
            // Joystick5Button2
            // Joystick5Button3
            // Joystick5Button4
            // Joystick5Button5
            // Joystick5Button6
            // Joystick5Button7
            // Joystick5Button8
            // Joystick5Button9
            // Joystick5Button10
            // Joystick5Button11
            // Joystick5Button12
            // Joystick5Button13
            // Joystick5Button14
            // Joystick5Button15
            // Joystick5Button16
            // Joystick5Button17
            // Joystick5Button18
            // Joystick5Button19

            // Joystick6Button0
            // Joystick6Button1
            // Joystick6Button2
            // Joystick6Button3
            // Joystick6Button4
            // Joystick6Button5
            // Joystick6Button6
            // Joystick6Button7
            // Joystick6Button8
            // Joystick6Button9
            // Joystick6Button10
            // Joystick6Button11
            // Joystick6Button12
            // Joystick6Button13
            // Joystick6Button14
            // Joystick6Button15
            // Joystick6Button16
            // Joystick6Button17
            // Joystick6Button18
            // Joystick6Button19

            // Joystick7Button0
            // Joystick7Button1
            // Joystick7Button2
            // Joystick7Button3
            // Joystick7Button4
            // Joystick7Button5
            // Joystick7Button6
            // Joystick7Button7
            // Joystick7Button8
            // Joystick7Button9
            // Joystick7Button10
            // Joystick7Button11
            // Joystick7Button12
            // Joystick7Button13
            // Joystick7Button14
            // Joystick7Button15
            // Joystick7Button16
            // Joystick7Button17
            // Joystick7Button18
            // Joystick7Button19

            // Joystick8Button0
            // Joystick8Button1
            // Joystick8Button2
            // Joystick8Button3
            // Joystick8Button4
            // Joystick8Button5
            // Joystick8Button6
            // Joystick8Button7
            // Joystick8Button8
            // Joystick8Button9
            // Joystick8Button10
            // Joystick8Button11
            // Joystick8Button12
            // Joystick8Button13
            // Joystick8Button14
            // Joystick8Button15
            // Joystick8Button16
            // Joystick8Button17
            // Joystick8Button18
            // Joystick8Button19
        }
    }
}