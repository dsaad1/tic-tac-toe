using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class BreakableObjectSetUp : MonoBehaviour
{
    private void Start()
    {
        if (PrefabUtility.GetPrefabParent(gameObject) == null && PrefabUtility.GetPrefabObject(gameObject) != null)
            PrefabUtility.UnpackPrefabInstance(gameObject, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
        BreakableObject breakableObj = gameObject.AddComponent<BreakableObject>();
        name = "Breakable Obj";

        GameObject solid = transform.GetChild(0).gameObject;
        solid.name = "solid";
        solid.tag = "solid piece";
        solid.layer = 14;
        BreakableObjectCollision collision = solid.AddComponent<BreakableObjectCollision>();
        collision.obj = breakableObj;
        BoxCollider col = solid.AddComponent<BoxCollider>();
        col.isTrigger = true;
        col.size *= 1.25f;
        Rigidbody solidRb = solid.AddComponent<Rigidbody>();
        solidRb.useGravity = false;
        solidRb.isKinematic = true;
        breakableObj.solid = solid.transform;

        GameObject shattered = new GameObject();
        shattered.name = "shattered";
        shattered.transform.SetParent(transform);
        breakableObj.shattered = shattered.transform;

     

        int size = transform.childCount - 2;
        for (int i = 0; i < size; i++)
        {
            GameObject child = transform.GetChild(1).gameObject;
            child.transform.SetParent(shattered.transform);
            ShatteredPiece shatteredPiece = child.AddComponent<ShatteredPiece>();
            shatteredPiece.OnCreation();
            breakableObj.shatteredPieces.Add(shatteredPiece);
        }

        shattered.SetActive(false); 



        

        DestroyImmediate(this);
    }

}
