using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR  
[CustomEditor(typeof(LinearMovement))]
public class LinearMovementEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        LinearMovement script = (LinearMovement)target;

        script.needsTomoveInTheDirectionOfAnotherObj = GUILayout.Toggle(script.needsTomoveInTheDirectionOfAnotherObj, " move in the forward direction of another object?");

        if(script.needsTomoveInTheDirectionOfAnotherObj)
        {
            script.obj = EditorGUILayout.ObjectField("Obj", script.obj, typeof(Transform), true) as Transform;
            script.moveInTheDirectionOfAnotherObj = EditorGUILayout.Toggle("moveInTheDirectionOfAnotherObj", script.moveInTheDirectionOfAnotherObj);
        }

    }


}
#endif
