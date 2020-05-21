using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour {

    //EDITOR ONLY VARIABLES
    [HideInInspector] public bool needsTomoveInTheDirectionOfAnotherObj;

    public Vector3 direction;
    public float movespeed;
    public bool move;
    float startSpeed;
 
    [HideInInspector] public bool moveInTheDirectionOfAnotherObj;
    [HideInInspector] public Transform obj;

    private void Start()
    {
        startSpeed = movespeed;
    }

    public void Go()
    {
        move = true;
    }

    public void Go(float seconds)
    {
        Invoke("Go", seconds);
    }

    public void Stop()
    {
        move = false;

        CancelInvoke();
    }

    public void Stop(float seconds)
    {
        Invoke("Stop", seconds);
    }

    public bool isMoving()
    {
        return move;
    }

    public void ChangeDir(Vector3 aDir)
    {
        direction = aDir;
    }

    public void SetSpeed(float aSpeed)
    {
        movespeed = aSpeed;
    }

    public void ResetSpeed()
    {
        movespeed = startSpeed;
    }

    void Update()
    {
        if (move)
        {
            if (moveInTheDirectionOfAnotherObj)
            {
                transform.Translate(obj.transform.forward * movespeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(direction.normalized * movespeed * Time.deltaTime);
            }

           
        }
    }
}
