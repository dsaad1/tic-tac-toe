using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class CurrencyUI : MonoBehaviour
{
    public static CurrencyUI self;

    [SerializeField] Currency currency; 
    [SerializeField] Text uiText; 


    private void Awake()
    {
        self = this;
    }

    private void Start()
    {
        SetUIText();
    }

    public void SetUIText()
    {
        uiText.text = currency.GetPlayerCurrency()+"";
    }

}
