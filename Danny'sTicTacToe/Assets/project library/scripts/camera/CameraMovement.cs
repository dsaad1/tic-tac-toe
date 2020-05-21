using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : CameraMovementBase
{

    public static CameraMovement self;



    private void Awake()
    {
        self = this;
    }

 
    public void OnGameStart()
    {
       
    }

    public void OnGameEnd(string status)
    {
        Stop();

        if(status == "win")
        {
            
        }
        else
        {

        }
    }

    private void Update()
    {
        if (follow)
        {
            Vector3 desiredPosition = new Vector3(transform.position.x, target.position.y, target.position.z) + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }

}
