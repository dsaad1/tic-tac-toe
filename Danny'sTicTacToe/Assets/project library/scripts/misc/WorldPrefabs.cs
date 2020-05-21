using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPrefabs : MonoBehaviour
{
    public static WorldPrefabs self;

    public GameObject[] prefabs;

    private void Awake()
    {
        self = this;
    }

    public GameObject GetMatchingObject(GameObject anObj)
    {
        string name = anObj.name.ToLower();
        for(int i = 0; i < prefabs.Length; i++)
        {
            if (name.Contains(prefabs[i].name))
                return prefabs[i];
        }
        Debug.Log("cannot find obj of type: " + anObj.name);
        return null;
    }
    public GameObject GetMatchingObject(string anObj)
    {
        string name = anObj.ToLower();
        for (int i = 0; i < prefabs.Length; i++)
        {
            if (name.Contains(prefabs[i].name))
                return prefabs[i];
        }
        Debug.Log("cannot find obj of type: " + anObj);
        return null;
    }

    //EXAMPLE
    #region
    /*
    ------------------------------------------------------------------------------------------
    GameObject targetPrefab;

    public void ReplaceAll()
    {
        if (targetPrefab == null)
            GetPrefab();
    }


    public void GetPrefab()
    {
        GameObject[] statics = GameObject.FindGameObjectsWithTag("static");
        foreach (GameObject g in statics)
        {
            if (g.name == "World Prefabs")
            {
                targetPrefab = g.GetComponent<WorldPrefabs>().GetMatchingObject("target");
            }
        }
    }

    ------------------------------------------------------------------------------------------
     */
    #endregion

}
