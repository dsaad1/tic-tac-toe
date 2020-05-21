using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class FXManager : FXManagerBase
{

    public static FXManager self;



    private void Awake()
    {
        self = this;
    }


    public new void OnGameEnd(string status)
    {
        base.OnGameEnd(status);
    }



}
