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
            SkyHookManager manager = SkyHookManager.Instance;
            
            GUI.enabled = false;
            EditorGUILayout.Toggle("Hook is running", manager.isHookActive);
            GUI.enabled = true;
            
            manager.requireFocus = EditorGUILayout.Toggle("Focus required", manager.requireFocus);
            
            GUI.enabled = false;
            EditorGUILayout.Toggle("Focused", SkyHookManager.IsFocused);
            GUI.enabled = true;

        }
    }
}
