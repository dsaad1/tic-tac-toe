using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : ControlsBase {

    public static Controls self;

   

    void Awake()
    {
        self = this;
    }

    public new void OnGameStart()
    {
        base.OnGameStart();
    }

    public new void OnGameEnd()
    {
        base.OnGameEnd(); 
    }


    void Update()
    {
        if (Input.touchCount == 1 && active)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("TODO: on tap");
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                Debug.Log("TODO: on tap hold");
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                Debug.Log("TODO: on release");
            }
        }
    }


}
