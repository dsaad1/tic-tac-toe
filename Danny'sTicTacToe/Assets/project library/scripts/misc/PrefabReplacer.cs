using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabReplacer : MonoBehaviour
{

    [SerializeField] string prefabName;
    GameObject targetPrefab;

    List<GameObject> oldPrefabs = new List<GameObject>();
    List<GameObject> newPrefabs = new List<GameObject>();

    public void ReplaceAll()
    {
        if (targetPrefab == null)
            GetPrefab();


        oldPrefabs.Clear();
        newPrefabs.Clear();
        int size = transform.childCount;

        for (int i = 0; i < size; i++)
        {
            oldPrefabs.Add(transform.GetChild(i).gameObject);
        }
        for(int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(targetPrefab, transform);
            newPrefabs.Add(obj);
            obj.transform.localPosition = oldPrefabs[i].transform.localPosition;
            obj.transform.localEulerAngles = oldPrefabs[i].transform.localEulerAngles;
            obj.transform.localScale = oldPrefabs[i].transform.localScale;
            DestroyImmediate(oldPrefabs[i].gameObject);
        }

       
    }


    public void GetPrefab()
    {
        GameObject[] statics = GameObject.FindGameObjectsWithTag("static");
        foreach (GameObject g in statics)
        {
            if (g.name == "World Prefabs")
            {
                targetPrefab = g.GetComponent<WorldPrefabs>().GetMatchingObject(prefabName);
            }
        }
    }
}
