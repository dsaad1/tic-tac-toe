using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsBase : MonoBehaviour
{
    string hapticsPlayerPref = "use haptics";




    public void ToggleHaptics()
    {
        if (UseHaptics())
            PlayerPrefs.SetInt(hapticsPlayerPref, 1);
        else
            PlayerPrefs.SetInt(hapticsPlayerPref, 0);
    }

    public bool UseHaptics()
    {
        if (PlayerPrefs.GetInt(hapticsPlayerPref) == 0)
            return true;
        return false; 
    }



    public void Clear()
    {
        PlayerPrefs.DeleteAll();
    }
}
