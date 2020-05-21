using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR  
[CustomEditor(typeof(ProjectBuilder))]
public class ProjectBuilderEditor : Editor
{

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();

        DrawDefaultInspector();
        ProjectBuilder manager = (ProjectBuilder)target;
        if (GUILayout.Button("Build Project"))
        {
            manager.BuildProject();
        }
    }


}
#endif
