using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : TutorialBase {

    public static Tutorial self;


    private void Awake()
    {
        self = this;
        CheckMiniTutorialConditions();
    }

    void CheckMiniTutorialConditions()
    {
        for (int i = 0; i < MiniTutorials.Count; i++)
        {
            if (LevelManager.self.GetLevel() == MiniTutorials[i].triggerLevel)
            {
                StartMiniTutorial(i);
                break;
            }

        }
    }
    

    public new void OnStart()
    {
        if (!enableTutorial)
            return;

        base.OnStart();
    }

    public new void OnComplete()
    {
        if (!enableTutorial)
            return; 
        base.OnComplete(); 
    }

    public new void OnStep(int step)
    {
        base.OnStep(step); 
    }

    public new void StartMiniTutorial(int index)
    {
        if (!useMiniTutorials || !MiniTutorials[index].enableTutorial)
            return;
        base.StartMiniTutorial(index);
    }

    public new void EndMiniTutorial()
    {
        if (GetActiveMiniTutorial()==null)
            return;
        base.EndMiniTutorial(); 
    }

    public new void OnMiniTutorialStep(int step)
    {
        if (GetActiveMiniTutorial() == null)
            return;
        base.OnMiniTutorialStep(step);
    }





}
