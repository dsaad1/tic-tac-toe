using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GameAnalyticsSDK;

public class GASuite_WinLossPercentage : MonoBehaviour
{
   

    public void OnGameStart()
    {
        //GameAnalytics.NewDesignEvent("Completion Rate:lv" + GASuite.self.GetLevel() + " starts", 1f);
       // TinySauce.TrackCustomEvent("Completion Rate:lv" + GASuite.self.GetLevel() + " starts", 1f);
       
    }

    public void OnGameOver(string outcome)
    {
 
        if (outcome == "win")
        {
            //TinySauce.TrackCustomEvent("Completion Rate:lv" + GASuite.self.GetLevel() + " completes", 1f);
        }
        else
        {

        }
    }


}
