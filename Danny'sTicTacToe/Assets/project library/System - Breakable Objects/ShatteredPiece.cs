using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatteredPiece : MonoBehaviour
{

    public BoxCollider col;
    public Rigidbody rb; 
    

    public void OnCreation()
    {
        col = gameObject.AddComponent<BoxCollider>();
        rb = gameObject.AddComponent<Rigidbody>();

        rb.useGravity = false;
        rb.isKinematic = true;

        gameObject.layer = 14;
        gameObject.tag = "shattered piece";
    }

    public void EnablePhysics()
    {
        rb.isKinematic = false; 
        rb.useGravity = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bullet")
        {
            gameObject.SetActive(false);
        }
    }

}
