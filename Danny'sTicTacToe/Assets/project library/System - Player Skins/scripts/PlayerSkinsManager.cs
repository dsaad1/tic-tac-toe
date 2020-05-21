using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerSkinsManager : PlayerSkinsManagerBase
{
    public static PlayerSkinsManager self;

   

    private void Awake()
    {
        self = this;
        SetActiveSkin(skins[GetActiveSkinIndex()]);
    }


}
