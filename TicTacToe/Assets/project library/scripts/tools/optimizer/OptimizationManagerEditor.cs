using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR  
[CustomEditor(typeof(OptimizationManager))]
public class OptimizationManagerEditor : Editor {

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();

        DrawDefaultInspector();
        OptimizationManager manager = (OptimizationManager)target; 
        if(GUILayout.Button("Clear"))
        {
         //   manager.Clear();
        }
    }


}
#endif
