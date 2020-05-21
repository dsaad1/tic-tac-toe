using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR

[CustomEditor(typeof(PlayerSkinsWizard))]
public class ChallengesWizardEditor : Editor
{

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();

        DrawDefaultInspector();
        PlayerSkinsWizard manager = (PlayerSkinsWizard)target;
        if (GUILayout.Button("Create Skin"))
        {
            manager.CreateSkin();
        }
        if (GUILayout.Button("Remove Skin"))
        {
            manager.RemoveSkin();
        }
    }


}
#endif
