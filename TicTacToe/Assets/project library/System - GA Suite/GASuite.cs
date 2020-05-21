using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GameAnalyticsSDK;

public class GASuite : MonoBehaviour
{
    public static GASuite self;
    [SerializeField] bool active;
    [SerializeField] GASuite_WinLossPercentage winLossPercentage; 

    string level = "";

    private void Awake()
    {
        self = this;
    }

    private void Start()
    {
        level = LevelManager.self.GetRunningLevel() + "";
    }

    public string GetLevel()
    {
        return level;
    }

    public bool IsActive()
    {
        if (active)
            return true;
        else
            return false;
    }

    public void OnGameStart()
    {
        if (!active)
            return;

      //  TinySauce.OnGameStarted(level);

        if (winLossPercentage != null)
            winLossPercentage.OnGameStart();
    }


    public void OnGameOver(string outcome)
    {
        if (!active)
            return;

     //   TinySauce.OnGameFinished(level, 1);

        if (outcome == "win")
        {
            //this is experimental because idk how this will end up working
         //   TinySauce.OnGameFinished(level, true, 1);

        }
        else
        {
            //this is experimental because idk how this will end up working
        //    TinySauce.OnGameFinished(level, false, 0);

        }

        if (winLossPercentage != null)
            winLossPercentage.OnGameOver(outcome);
    }





}
