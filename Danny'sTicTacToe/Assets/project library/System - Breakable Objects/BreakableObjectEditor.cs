using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR  
[CustomEditor(typeof(BreakableObject))]
public class BreakableObjectEditor : Editor
{

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();

        DrawDefaultInspector();
        BreakableObject manager = (BreakableObject)target;
        if (GUILayout.Button("Peek"))
        {
            manager.Peek();
        }
    }


}
#endif
