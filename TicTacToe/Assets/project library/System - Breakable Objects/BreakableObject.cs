using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public Transform solid;
    public Transform shattered;
    public List<ShatteredPiece> shatteredPieces = new List<ShatteredPiece>();


    public void Peek()
    {
        if (solid.gameObject.activeInHierarchy)
        {
            solid.gameObject.SetActive(false);
            shattered.gameObject.SetActive(true);
        }
        else
        {
            solid.gameObject.SetActive(true);
            shattered.gameObject.SetActive(false);
        }

    }

    public void OnFirstCollision()
    {
        solid.gameObject.SetActive(false);
        shattered.gameObject.SetActive(true);
        /*foreach(ShatteredPiece p in shatteredPieces)
        {
            p.EnablePhysics();
        }*/
    }

}
