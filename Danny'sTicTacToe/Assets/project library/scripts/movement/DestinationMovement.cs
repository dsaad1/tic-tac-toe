using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationMovement : MonoBehaviour {

    public float movespeed;
    public bool moveInLocalSpace;
    bool move;
    public Vector3 dest;
    float startSpeed;
    public string objectToCallOnDestArrival;


    private void Start()
    {
        startSpeed = movespeed;
    }


    public void SetSpeed(float aSpeed)
    {
        movespeed = aSpeed;
    }

    public void ResetSpeed()
    {
        movespeed = startSpeed;
    }

    public void SetDest(Vector3 aV3)
    {
        dest = aV3;
        move = true;
        Debug.Log("y");
    }

    public void SetDest(Vector3 ogV3, Vector3 aV3, string dir)
    {
        dest = SetDir(ogV3, aV3, dir);
        move = true;
    }

    public void SetDest(Transform aTransform)
    {
        dest = aTransform.position;
        move = true;
    }

    public void SetDest(GameObject anObj)
    {
        dest = anObj.transform.position;
        move = true;
    }

    public void SetDest(GameObject ogObj, GameObject anObj, string dir)
    {
        dest = SetDir(ogObj.transform.position, anObj.transform.position, dir);
        move = true;
    }

    Vector3 SetDir(Vector3 ogV3, Vector3 aDest, string dir)
    {
        switch (dir)
        {
            case "x":
                return new Vector3(aDest.x, ogV3.y, ogV3.z);
            case "y":
                return new Vector3(ogV3.x, aDest.z, ogV3.z);
            case "z":
                return new Vector3(ogV3.x, ogV3.y, aDest.z);
            case "yz":
                return new Vector3(ogV3.x, aDest.y, aDest.z);
            case "xz":
                return new Vector3(aDest.x, ogV3.y, aDest.z);
            default:
                return Vector3.zero;
        }
    }

    public void OnDestArrival()
    {
        //Debug.Log("dest reached!");
        Stop();

        if (objectToCallOnDestArrival == "player")
        {

        }
    }

    public void Stop()
    {
        //  Debug.Log("stop: " + Time.time);    
        move = false;
    }

    private void FixedUpdate()
    {
        if (move)
        {
            if (transform.position == dest)
            {
                //    Debug.Log("called: " + Time.time);
                OnDestArrival();
            }
            else if (moveInLocalSpace)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(dest.x, dest.y, dest.z), movespeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(dest.x, dest.y, dest.z), movespeed * Time.deltaTime);
            }
        }
    }

}

