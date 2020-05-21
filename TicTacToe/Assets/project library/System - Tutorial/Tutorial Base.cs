using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBase : MonoBehaviour
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
    string tutorialPlayerPref = "tutorial completed"; 
    bool active;
    [Header("MINI TUTORIALS")]
    [SerializeField] protected bool useMiniTutorials; 
    public List<MiniTutorial> MiniTutorials = new List<MiniTutorial>();
    MiniTutorial activeMiniTutorial;


   
    protected void StartMiniTutorial(int index)
    {
        activeMiniTutorial = MiniTutorials[index];
        if (activeMiniTutorial != null)
        {
            activeMiniTutorial.OnStart();
            Enable();
        }
    }

    protected void EndMiniTutorial()
    {
        if(activeMiniTutorial != null)
        {
            activeMiniTutorial.OnComplete();
            Disable();
        } 
    }

    protected void OnMiniTutorialStep(int step)
    {
        if (activeMiniTutorial != null)
            activeMiniTutorial.OnStep(step);
    }

    public MiniTutorial GetActiveMiniTutorial()
    {
        return activeMiniTutorial;
    }

    protected void OnStart()
    {
        Enable();
    }

    protected void OnComplete()
    { 
        SetTutorialPlayerPref(1);
    }



    protected void OnStep(int step)
    {
        currentStep = step;
        switch(step)
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

    public bool Active()
    {
        return active;
    }

    public void Enable()
    {
        active = true;
    }

    public void Disable()
    {
        active = false;
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
