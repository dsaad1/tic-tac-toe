using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class OptimizationManager : MonoBehaviour {

    public static OptimizationManager self; 

    [Header("-----MESH RENDERERS-----")]
    public bool optimizeMeshRenderer;
    public bool turnOffCastShadows;
    public bool turnOffReceiveShadows;
    [Space(30)]
    [Header("-----COLLIDERS-----")]
    public bool optimizeCollider;

    private void Awake()
    {
        self = this;
    }

    public void Optimize()
    {
        GameObject[] objectsToOptimizeArray;
        List<GameObject> objectsToOptimize = new List<GameObject>();
        
        objectsToOptimizeArray = new GameObject[transform.childCount];
        for(int i = 0; i < objectsToOptimizeArray.Length; i++)
        {
            objectsToOptimizeArray[i] = transform.GetChild(i).gameObject;
        }
        

        foreach(GameObject g in objectsToOptimizeArray)
        {
            objectsToOptimize.Add(g);
            GetAllChildren(g.transform, objectsToOptimize);
        }

        OptimizeGameObjects(objectsToOptimize);


        ClearSettings();
    }



    void GetAllChildren(Transform parent, List<GameObject> aList)
    {
        foreach(Transform child in parent)
        {
            aList.Add(child.gameObject);
            GetAllChildren(child,aList);
        }
    }

    public void OptimizeGameObjects(List<GameObject> objects)
    {
        foreach (GameObject g in objects)
        {
            if (optimizeMeshRenderer && g.GetComponent<MeshRenderer>() != null)
            {
                MeshRenderer rend = g.GetComponent<MeshRenderer>();
                rend.lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
                rend.reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;

                if (turnOffCastShadows)
                {
                    rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                }

                if (turnOffReceiveShadows)
                {
                    rend.receiveShadows = false;
                }
            }

            if (optimizeCollider && g.GetComponent<Collider>() != null)
            {
                DestroyImmediate(g.GetComponent<Collider>());
            }

            if(g.GetComponent<PrimitivePlus.PrimitivePlusMaterial>() != null)
            {
                DestroyImmediate(g.GetComponent<PrimitivePlus.PrimitivePlusMaterial>());
            }
        }

        ClearSettings();
    }

    public void OptimizeGameObject(GameObject obj)
    {
   
        if (optimizeMeshRenderer && obj.GetComponent<MeshRenderer>() != null)
        {
            MeshRenderer rend = obj.GetComponent<MeshRenderer>();
            rend.lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
            rend.reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;

            if (turnOffCastShadows)
            {
                rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            }

            if (turnOffReceiveShadows)
            {
                rend.receiveShadows = false;
            }
        }

        if (optimizeCollider && obj.GetComponent<Collider>() != null)
        {
            DestroyImmediate(obj.GetComponent<Collider>());
        }

        if (obj.GetComponent<PrimitivePlus.PrimitivePlusMaterial>() != null)
        {
            DestroyImmediate(obj.GetComponent<PrimitivePlus.PrimitivePlusMaterial>());
        }
        

        ClearSettings();
    }


    void ClearSettings()
    {
        optimizeMeshRenderer = false;
        optimizeCollider = false;
        turnOffReceiveShadows = false;
        turnOffCastShadows = false; 
    }


}
