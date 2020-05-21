using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class FXManagerBase : MonoBehaviour
{

    protected void OnGameEnd(string state)
    {
        if (state == "win")
        {

        }
        else if (state == "lose")
        {
            CameraShaker.Instance.ShakeOnce(20, 5, .1f, .5f);
            iOSHapticController.instance.TriggerImpactHeavy();
        }

    }
}
