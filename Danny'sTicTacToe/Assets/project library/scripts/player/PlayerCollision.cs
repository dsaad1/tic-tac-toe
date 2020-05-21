using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public static PlayerCollision self; 



    private void Awake()
    {
        self = this;
    }

    private void OnTriggerEnter(Collider other)
    {
      
    }

  


}
