﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBase : MonoBehaviour
{
    public Sprite icon;
    public void TakeTurn ()
    {
        if (GetComponent<EasyAI>() != null)
        {
            GetComponent<EasyAI>().TakeTurn();
        }
        BoardManager.self.PlayerTurn();
    }

    public void SetIcon(Sprite icon1)
    {
        icon = icon1;
    }
}
