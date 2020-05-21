using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
[ExecuteInEditMode]
public class PlayerSkinsWizard : MonoBehaviour
{
    [Header("CREATE A SKIN")]
    [Tooltip("name of the skin")]
    public string skinName;
    [Header("REMOVE A SKIN")]
    public PlayerSkin skinToRemove; 

    public void CreateSkin()
    {
        PlayerSkinsManager manager = GetComponent<PlayerSkinsManager>();

        //creates a skin and the creation values
        GameObject obj = new GameObject();
        obj.transform.SetParent(transform);
        PlayerSkin newSkin = obj.AddComponent<PlayerSkin>();
        //setting the name
        newSkin.SetName(skinName);
        obj.name = "skin: " + skinName;
        //setting the index
        newSkin.SetIndex(manager.skins.Count);

        //adds the skin to the player skins manager 
    
        manager.skins.Add(newSkin);

        ClearValuesInEditor();
    }

    public void RemoveSkin()
    {
        PlayerSkinsManager manager = GetComponent<PlayerSkinsManager>();

        for (int i = skinToRemove.GetIndex()+1; i < manager.skins.Count; i++)
        {
            manager.skins[i].SetIndex(manager.skins[i].GetIndex() - 1);
        }

        manager.skins.Remove(skinToRemove);
        skinToRemove.Delete();
        ClearValuesInEditor();
    }

    //clears all of the values 
    void ClearValuesInEditor()
    {
        skinName = "";
        skinToRemove = null;
    }


}
#endif