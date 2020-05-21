using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR  
[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();

        DrawDefaultInspector();
        GameManager manager = (GameManager)target;
        if (GUILayout.Button("End Win"))
        {
            manager.EndGame("win");
        }
        if (GUILayout.Button("End Loss"))
        {
            manager.EndGame("loss");
        }
    }


}
#endif
