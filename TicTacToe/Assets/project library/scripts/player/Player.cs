using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerBase {

    public static Player self;

    private void Awake()
    {
        self = this;
    }

    public new void OnGameEnd(string status)
    {
        base.OnGameEnd(status);
    }

}
