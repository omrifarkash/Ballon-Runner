using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsSetter : MonoBehaviour
{
    private Text CoinsText;

    private void Start()
    {
        CoinsText = GetComponent<Text>();
    }

    private void Update()
    {
        setCoinsInUI();
    }

    private void setCoinsInUI()
    {
        if (CoinsCollectorManager.CoinsCounter >= 10)
        {
            CoinsText.text = "x" + CoinsCollectorManager.CoinsCounter;
        }
        else
        {
            CoinsText.text = "x0" + CoinsCollectorManager.CoinsCounter;
        }
    }
}
