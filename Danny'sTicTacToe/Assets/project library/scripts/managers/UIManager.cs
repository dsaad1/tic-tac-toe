using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : UIManagerBase
{
    public static UIManager self;

    private void Awake()
    {
        self = this;
    }

    public new void OnGameStart()
    {
        base.OnGameStart();
    }

    public new void OnGameEnd(string status)
    {
        base.OnGameEnd(status);
    }




}


   



  
