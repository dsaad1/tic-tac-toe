using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR  
[CustomEditor(typeof(Coins))]
[CanEditMultipleObjects]
public class CoinsEditor : Editor
{

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();

        DrawDefaultInspector();
        Coins manager = (Coins)target;
        GUILayout.Space(25);
        if (GUILayout.Button("Add Coin"))
        {
            foreach (var obj in Selection.gameObjects)
            {
                obj.GetComponent<Coins>().AddCoin();
            }
        }
        if (GUILayout.Button("Delete Last"))
        {
            foreach (var obj in Selection.gameObjects)
            {
                obj.GetComponent<Coins>().DeleteLastCoin();
            }

        }
        GUILayout.Space(50);
        if (GUILayout.Button("Replace All"))
        {
            foreach (var obj in Selection.gameObjects)
            {
                obj.GetComponent<Coins>().ReplaceAll();
            }

        }

        GUILayout.Space(50);
    
        if (GUILayout.Button("Delete All"))
        {
            foreach (var obj in Selection.gameObjects)
            {
                obj.GetComponent<Coins>().DeleteAllCoins();
            }

        }
    

    }


}
#endif