using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : GameSettingsBase
{
    public static GameSettings self;

    private void Awake()
    {
        self = this;
    }



   

}
