using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR  
[CustomEditor(typeof(GameSettings))]
public class GameSettingsEditor : Editor
{

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();

        DrawDefaultInspector();
        GameSettings manager = (GameSettings)target;
        if (GUILayout.Button("Clear"))
        {
            manager.Clear();
        }
    }


}
#endif
