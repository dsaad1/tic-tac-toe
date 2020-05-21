using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using FIMSpace;

[RequireComponent (typeof(MagicButtonAnimations))] [RequireComponent (typeof(MagicButtonColors))]
public class MagicButton : MagicButtonBase
{
    public void Enable(bool recolor)
    {
        button.interactable = true;
        if(recolor)
            TryToColor("enable"); 
    }


    public void Disable(bool recolor)
    {
        button.interactable = false;
        if (recolor)
            TryToColor("disable");
    }

    public new void OnPress()
    {
        base.OnPress();
        Disable(false);
    }

 


  
}
