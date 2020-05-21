using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerMovementBase {

    public static PlayerMovement self;


    private void Awake()
    {
        self = this;
    }

    public void OnGameStart()
    {

    }

    public void OnGameEnd(string status)
    {

    }


}
