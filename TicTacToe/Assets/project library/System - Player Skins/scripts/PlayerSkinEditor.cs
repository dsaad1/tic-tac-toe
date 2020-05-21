using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR

[CustomEditor(typeof(PlayerSkin)), CanEditMultipleObjects]
public class PlayerSkinEditor : Editor
{

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();

        DrawDefaultInspector();
        PlayerSkin manager = (PlayerSkin)target;
        if (GUILayout.Button("Unlock"))
        {
            manager.Unlock();
        }
        if (GUILayout.Button("Lock"))
        {
            manager.Lock();
        }
        GUILayout.Space(25);
        if (GUILayout.Button("Clear"))
        {
            manager.Clear();
        }
    }


}
#endif
