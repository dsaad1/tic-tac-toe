using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerBase : MonoBehaviour
{
    [Header("ON START")]
    [SerializeField] private GameObject[] objsToEnableOnGameStart;
    [SerializeField] private GameObject[] objsToDisableOnGameStart;

    [Header("ON GAME OVER")]
    [SerializeField] private GameObject[] objsToEnableOnGameOver;
    [SerializeField] private GameObject[] objsToDisableOnGameOver;
    [Header("ON WIN")]
    [SerializeField] private float winDelay;
    [SerializeField] private GameObject[] objsToEnableOnWin;
    [SerializeField] private GameObject[] objsToDisableOnwin;
    [Header("ON LOSS")]
    [SerializeField] private float lossDelay;
    [SerializeField] private GameObject[] objsToEnableOnLoss;
    [SerializeField] private GameObject[] objsToDisableOnLoss;

    protected void OnGameStart()
    {
        HandleObjects(objsToEnableOnGameStart, objsToDisableOnGameStart);
    }

    protected void OnGameEnd(string status)
    {
      

        //enable and disable necessary objects

        if (status == "win")
        {
            HandleObjects(objsToEnableOnWin, objsToDisableOnwin);
            HandleObjects(objsToEnableOnGameOver, winDelay, objsToDisableOnGameOver, winDelay);
        }
        else if (status == "lose")
        {
            HandleObjects(objsToEnableOnLoss, objsToDisableOnLoss);
            HandleObjects(objsToEnableOnGameOver, lossDelay, objsToDisableOnGameOver, lossDelay);
        }
        else
        {
            HandleObjects(objsToEnableOnGameOver, lossDelay, objsToDisableOnGameOver, lossDelay);

        }

    }

    //UTILITIES ---------------------------------------------------------------------------------------
    #region
    void HandleObjects(GameObject[] objsToEnable, float enableDelay, GameObject[] objsToDisable, float disableDelay)
    {
        foreach (GameObject g in objsToEnable)
        {
            StartCoroutine(EnableAfterSeconds(g, enableDelay));
        }

        foreach (GameObject g in objsToDisable)
        {
            StartCoroutine(DisableAfterSeconds(g, disableDelay));
        }
    }

    void HandleObjects(GameObject[] objsToEnable, GameObject[] objsToDisable)
    {
        foreach (GameObject g in objsToEnable)
        {
            StartCoroutine(EnableAfterSeconds(g, 0));
        }

        foreach (GameObject g in objsToDisable)
        {
            StartCoroutine(DisableAfterSeconds(g, 0));
        }
    }

    IEnumerator DisableAfterSeconds(GameObject g, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        g.SetActive(false);
    }
    void DisableAfterSecond(GameObject g, float seconds)
    {
        StartCoroutine(DisableAfterSeconds(g, seconds));
    }
    void EnableAfterSecond(GameObject g, float seconds)
    {
        StartCoroutine(EnableAfterSeconds(g, seconds));
    }
    IEnumerator EnableAfterSeconds(GameObject g, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        g.SetActive(true);
    }


    #endregion
}

