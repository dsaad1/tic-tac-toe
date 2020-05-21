using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : LevelManagerBase {


    public static LevelManager self;

    private void Awake()
    {
        self = this;
    }


    public new void OnGameEnd(string status)
    {
        base.OnGameEnd(status);
    }
}
