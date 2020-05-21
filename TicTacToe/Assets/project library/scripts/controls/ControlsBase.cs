using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsBase : MonoBehaviour
{
    protected bool active;
    protected Touch touch;

    [SerializeField] bool debug;

    public void Enable()
    {
        active = true;
        if(debug)
            Debug.Log("controls enabled!");
    }

    public void EnableAfterSeconds(float seconds)
    {
        CancelInvoke();
        Invoke("Enable", seconds);
    }

    public void Disable()
    {
        CancelInvoke();
        active = false;
        if(debug)
            Debug.Log("controls disabled!");
    }

    public void DisableAfterSeconds(float seconds)
    {
        CancelInvoke();
        Invoke("Disable", seconds);
    }

    protected void OnGameStart()
    {
        Enable();
    }

    protected void OnGameEnd()
    {
        Disable(); 
    }

}
