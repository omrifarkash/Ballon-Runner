using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToturialManager : MonoBehaviour
{
    public static EToturialMode toturialMode = EToturialMode.Wait;
    public static bool allowMovement = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(toturialMode);
        stateMechine();
        setUIByState();
    }

    private void stateMechine()
    {
        if (GameManager.playMode == GameManager.EPlayMode.WaitingToPlay)
        {
            toturialMode = EToturialMode.Welcome;
        }
    }

    private void setUIByState()
    {
        switch (toturialMode)
        {
            case EToturialMode.Welcome:
                break;
            case EToturialMode.Swipe:
                break;
            case EToturialMode.Pause:
                break;
            case EToturialMode.Resume:
                break;
        }
    }

    public enum EToturialMode
    {
        Wait,
        Welcome,
        Swipe,
        Pause,
        Resume,
        TakeCoins,
        TakeBalloons,
        GetOnGazer,
        End,
    }
}
