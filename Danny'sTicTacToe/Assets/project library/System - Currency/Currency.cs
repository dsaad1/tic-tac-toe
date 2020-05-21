using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public static Currency self;

    public GameObject currencyObj;
    string playerCurrencyPref = "player currency";

    [SerializeField] CurrencyUI ui;


    private void Awake()
    {
        self = this;
    }





    public int GetPlayerCurrency()
    {
        return PlayerPrefs.GetInt(playerCurrencyPref);
    }

    public void IncreasePlayerCurrencyBy(int anAmount)
    {
        int newAmount = GetPlayerCurrency() + anAmount;
        SetPlayerCurrency(newAmount);
    }

    public void DecreasePlayerCurrencyBy(int anAmount)
    {
        int newAmount = GetPlayerCurrency() - anAmount;
        SetPlayerCurrency(newAmount);
    }

    public void SetPlayerCurrency(int anInt)
    {
        PlayerPrefs.SetInt(playerCurrencyPref, anInt);
        MakeSurePlayerCurrencyIsNotNegative();
        ui.SetUIText();
    }

    void MakeSurePlayerCurrencyIsNotNegative()
    {
        if (GetPlayerCurrency() < 0)
            SetPlayerCurrency(0);
    }
}
