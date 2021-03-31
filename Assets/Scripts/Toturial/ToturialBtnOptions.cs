using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToturialBtnOptions : MonoBehaviour
{
    public void EndWelcomePressed()
    {
        ToturialManager.allowMovement = false;
        ToturialManager.toturialMode = ToturialManager.EToturialMode.Swipe;
    }

    public void EndSwipingPressed()
    {
        ToturialManager.allowMovement = false;
        Time.timeScale = 1f;
        ToturialManager.toturialMode = ToturialManager.EToturialMode.TakeCoins;
        Invoke("changeTimeSCaleToZero", Constants.ToturialTimeAfterSwipe);
    }

    public void EndTakeCoinsPressed()
    {
        ToturialManager.allowMovement = true;
        Time.timeScale = 1f;
        ToturialManager.toturialMode = ToturialManager.EToturialMode.TakeBalloons;
        Invoke("changeTimeSCaleToZero", Constants.ToturialTimeAfterTakeCoins);
    }

    public void EndTakeBallonsPressed()
    {
        Time.timeScale = 1f;
        ToturialManager.toturialMode = ToturialManager.EToturialMode.GetOnGazer;
        Invoke("changeTimeSCaleToZero", Constants.ToturialTimeAfterTakeBallons);
    }

    public void EndGetOnGazerToturial()
    {
        Time.timeScale = 1f;
        ToturialManager.toturialMode = ToturialManager.EToturialMode.End;
    }

    private void changeTimeSCaleToZero()
    {
        Time.timeScale = 0f;
    }
}
