using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementBase : MonoBehaviour
{

    [SerializeField] protected Transform target;
    [SerializeField] protected float smoothSpeed;
    [SerializeField] protected Vector3 offset;
    [SerializeField] Transform offsetObj;

    protected bool follow;


    private void Start()
    {
        Follow();
        Debug.Log("camera set to follow on start");

        if(target == null)
        {
            Debug.Log("no target for camera to follow - stopping");
            Stop();
        }
    }

    protected void SetOffset()
    {
        offset = offsetObj.localPosition;
        transform.localPosition = offset;
        offsetObj.transform.localPosition = Vector3.zero;

    }

    public void Follow()
    {
        SetOffset();
        follow = true;
    }

    public void Stop()
    {
        follow = false;
    }

    public void SetOffset(Vector3 anOffset)
    {
        offset = anOffset;
    }

    public void SetSmoothSpeed(float aSpeed)
    {
        smoothSpeed = aSpeed;
    }

    public void SetTarget(Transform aTarget)
    {
        target = aTarget;
    }


}
