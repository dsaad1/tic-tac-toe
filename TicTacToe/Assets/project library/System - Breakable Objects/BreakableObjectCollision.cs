using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjectCollision : MonoBehaviour
{
    public BreakableObject obj;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bullet")
        {
            GetComponent<Collider>().enabled = false;
            obj.OnFirstCollision();
        }
    }

}
