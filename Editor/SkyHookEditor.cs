using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SkyHook.Editor
{
    [CustomEditor(typeof(SkyHookManager))]
    public class SkyHookEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            SkyHookManager manager = (SkyHookManager)target;
        }
    }
}
