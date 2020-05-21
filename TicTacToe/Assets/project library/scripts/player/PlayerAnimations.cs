using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using FIMSpace;

public class PlayerAnimations : PlayerAnimationsBase
{

    public static PlayerAnimations self;
   


    private void Awake()
    {
        self = this;
    }



    public void OnGameEnd(string status)
    {
        if(status == "win")
        {
            OnWin();
        }
        else
        {
            OnDeath();
        }
    }

}
