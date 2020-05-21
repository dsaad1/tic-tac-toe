using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR

[CustomEditor(typeof(MagicButton))]
public class MagicButtonEditor : Editor
{

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();

        DrawDefaultInspector();
        MagicButton manager = (MagicButton)target;
        if (GUILayout.Button("Disable"))
        {
            manager.Disable(true);
        }
        if (GUILayout.Button("Enable"))
        {
            manager.Enable(true);
        }
    }


}
#endif
