using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{

    protected void OnGameEnd(string status)
    {
        PlayerAnimations.self.OnGameEnd(status);

        if (status == "win")
        {

        }
        else
        {

        }
    }

}
