using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR

[CustomEditor(typeof(PlayerSkinsManager))]
public class PlayerSkinsManagerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();

        DrawDefaultInspector();
        PlayerSkinsManager manager = (PlayerSkinsManager)target;
        if (GUILayout.Button("Unlock All"))
        {
            manager.UnlockAll();
        }
        if (GUILayout.Button("Lock All"))
        {
            manager.LockAll();
        }

        GUILayout.Space(50);

        if (GUILayout.Button("Clear All"))
        {
            manager.ClearAll();
        }

    }


}
#endif
