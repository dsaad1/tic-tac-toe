using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler self;

    public GameObject pooled_object;

    private List<GameObject> pooledObjects = new List<GameObject>();

    void Awake()
    {
        self = this;
    }

    public GameObject GetObj(Vector3 pos, Transform parent)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].transform.position = pos;
                pooledObjects[i].transform.SetParent(parent);
                pooledObjects[i].SetActive(true);
                return pooledObjects[i];
            }
        }
        return CreateObj(pos,parent);
    }

    public GameObject CreateObj(Vector3 pos, Transform parent)
    {
        GameObject obj = Instantiate(pooled_object);
        obj.transform.position = pos;
        obj.transform.SetParent(parent);
        pooledObjects.Add(obj);
        obj.SetActive(true);
        return obj;
    }
}
