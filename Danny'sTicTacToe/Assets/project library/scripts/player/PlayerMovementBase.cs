using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovementBase : MonoBehaviour
{
    [Header("DEBUGGING")]
    protected bool moving;




    public void Go()
    {
        moving = true;
    }

    public void Go(float seconds)
    {
        Invoke("Go", seconds);
    }

    public void Stop()
    {
        moving = false;
    }

    public void Stop(float seconds)
    {
        Invoke("Stop", seconds);
    }





}
