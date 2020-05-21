using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniTutorial : MiniTutorialBase
{ 


    public new void OnStart()
    {
        Debug.Log("mini tutorial for level " + triggerLevel + " started!");
        base.OnStart();
    }

    public new void OnComplete()
    {
        base.OnComplete();
    }

    public new void OnStep(int step)
    {
        base.OnStep(step);
    }





}
