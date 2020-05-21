using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : PlayerBase {

    public static Player self;
    public Sprite icon;

    private void Awake()
    {
        self = this;
    }

    public new void OnGameEnd(string status)
    {
        base.OnGameEnd(status);
    }

}
