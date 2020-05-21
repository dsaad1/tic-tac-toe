using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR  
[CustomEditor(typeof(PrefabReplacer))]
public class PrefabReplacerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();

        DrawDefaultInspector();
        PrefabReplacer manager = (PrefabReplacer)target;
        if (GUILayout.Button("Replace All"))
        {
            manager.ReplaceAll();
        }
    }


}
#endif
