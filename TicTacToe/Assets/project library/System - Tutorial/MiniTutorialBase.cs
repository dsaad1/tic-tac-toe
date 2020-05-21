using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniTutorialBase : MonoBehaviour
{
    [SerializeField] public bool enableTutorial = true;
    [Header("STEP 1")]
    [SerializeField] GameObject[] objsToEnableOnStep1;
    [Header("STEP 2")]
    [SerializeField] GameObject[] objsToDisableOnStep2;
    [SerializeField] GameObject[] objsToEnableOnStep2;
    [Header("STEP 3")]
    [SerializeField] GameObject[] objsToDisableOnStep3;
    [SerializeField] GameObject[] objsToEnableOnStep3;

    int currentStep;
    [Header("MINI TUTORIAL")]
    [SerializeField] string tutorialPlayerPref;
    public int triggerLevel;

    protected void OnStart()
    {
        if (!enableTutorial)
            return;

    }

    protected void OnComplete()
    {
        if (!enableTutorial)
            return;
        SetTutorialPlayerPref(1);
    }

    protected void OnStep(int step)
    {
        currentStep = step;
        switch (step)
        {
            case 1:
                EnableObjs(objsToEnableOnStep1);
                break;
            case 2:
                DisableObjs(objsToDisableOnStep2);
                EnableObjs(objsToEnableOnStep2);
                break;
            case 3:
                DisableObjs(objsToDisableOnStep3);
                EnableObjs(objsToEnableOnStep3);
                break;
        }

    }


    void SetTutorialPlayerPref(int status)
    {
        PlayerPrefs.SetInt(tutorialPlayerPref, status);
    }

    public bool IsComplete()
    {
        if (PlayerPrefs.GetInt(tutorialPlayerPref) == 1)
            return true;
        return false;
    }

    public int GetCurrentStep()
    {
        return currentStep;
    }

    void EnableObjs(GameObject[] objs)
    {
        foreach (GameObject g in objs)
            g.SetActive(true);
    }

    void DisableObjs(GameObject[] objs)
    {
        foreach (GameObject g in objs)
            g.SetActive(false);
    }
}
