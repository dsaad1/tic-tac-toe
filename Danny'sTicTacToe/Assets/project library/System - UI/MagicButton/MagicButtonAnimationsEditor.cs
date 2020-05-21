using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR

[CustomEditor(typeof(MagicButtonAnimations))]
public class MagicButtonAnimationsEditor : Editor
{

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();

        DrawDefaultInspector();
      /*  MagicButtonAnimations manager = (MagicButtonAnimations)target;
        if (GUILayout.Button("Slide In"))
        {
            manager.SlideIn();
        }
        if (GUILayout.Button("Slide Out"))
        {
            manager.SlideOut();
        } */
    }


   

}
#endif