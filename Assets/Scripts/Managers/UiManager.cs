using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject OnGamePanel;
    public GameObject EndLevelPanel;
    public GameObject DisqualifiedPanel;
    public GameObject DebugPanel;

    public GameObject ToturialWelcomePanel;
    public GameObject ToturialSwipePanel;
    public GameObject ToturialTakeCoinsPanel;
    public GameObject ToturialTakeBallonsPanel;
    public GameObject ToturialGetOnGazerPanel;

    public Text CoinsText;
    private bool FirstFrameEnded = true;

    // Start is called before the first frame update
    void Start()
    {
       OnGamePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        setPanelByGameState();
        setPanelsByToturialMode();
    }

    //Toturial UI
    private void setPanelsByToturialMode()
    {
        switch (ToturialManager.toturialMode)
        {
            case ToturialManager.EToturialMode.Welcome:
                toturialWelcome();
                break;
            case ToturialManager.EToturialMode.Swipe:
                toturialSwipe();
                break;
            case ToturialManager.EToturialMode.TakeCoins:
                toturialTakeCoins();
                break;
            case ToturialManager.EToturialMode.TakeBalloons:
                toturialTakeBallons();
                break;
            case ToturialManager.EToturialMode.GetOnGazer:
                toturialGetOnGazer();
                break;
            case ToturialManager.EToturialMode.End:
                toturialEnd();
                break;
            default:
                break;
        }
    }

    private void toturialWelcome()
    {
        ToturialWelcomePanel.SetActive(true);
    }

    private void toturialSwipe()
    {
        ToturialWelcomePanel.SetActive(false);
        ToturialSwipePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void toturialTakeCoins()
    {
        if (ToturialSwipePanel.active)
        {
            ToturialSwipePanel.SetActive(false);
            Invoke("activateTakeCoins", Constants.ToturialTimeAfterSwipe);
        }
    }

    private void toturialTakeBallons()
    {
        if (ToturialTakeCoinsPanel.active)
        {
            ToturialTakeCoinsPanel.SetActive(false);
            Invoke("activateTakeBallons", Constants.ToturialTimeAfterTakeCoins);
        }
    }

    private void toturialGetOnGazer()
    {
        if (ToturialTakeBallonsPanel.active)
        {
            ToturialTakeBallonsPanel.SetActive(false);
            Invoke("activateGetOnGazer", Constants.ToturialTimeAfterTakeBallons);
        }
    }

    private void toturialEnd()
    {
        ToturialGetOnGazerPanel.SetActive(false);
    }

    private void activateTakeCoins()
    {
        ToturialTakeCoinsPanel.SetActive(true);
    }

    private void activateTakeBallons()
    {
        ToturialTakeBallonsPanel.SetActive(true);
    }

    private void activateGetOnGazer()
    {
        ToturialGetOnGazerPanel.SetActive(true);
    }

    // Regular UI
    private void setPanelByGameState()
    {
        switch (GameManager.playMode)
        {
            case GameManager.EPlayMode.SetCamera:
                SetCameraMode();
                break;
            case GameManager.EPlayMode.WaitingToPlay:
                WaitingToPlayMode();
                break;
            case GameManager.EPlayMode.Play:
                PlayMode();
                break;
            case GameManager.EPlayMode.disqualified:
                DisqualifiedMode();
                break;
            case GameManager.EPlayMode.End:
                EndMode();
                break;
            case GameManager.EPlayMode.Pause:
                PauseMode();
                break;
            default:
                break;
        }
    }

    private void PauseMode()
    {
        Time.timeScale = 0f;
        OnGamePanel.SetActive(false);
        DebugPanel.SetActive(true);
    }

    private void DisqualifiedMode()
    {
        Time.timeScale = 0f;
        DisqualifiedPanel.SetActive(true);
        OnGamePanel.SetActive(false);

    }

    private void SetCameraMode()
    {
        OnGamePanel.SetActive(true);
        DebugPanel.SetActive(false);
        EndLevelPanel.SetActive(false);
        DisqualifiedPanel.SetActive(false);
    }

    private void WaitingToPlayMode()
    {
        OnGamePanel.SetActive(true);
        DebugPanel.SetActive(false);
        EndLevelPanel.SetActive(false);
        DisqualifiedPanel.SetActive(false);
    }

    private void PlayMode()
    {
        OnGamePanel.SetActive(true);
        DebugPanel.SetActive(false);
        EndLevelPanel.SetActive(false);
        DisqualifiedPanel.SetActive(false);
    }

    private void EndMode()
    {
        if (FirstFrameEnded)
        {
            FirstFrameEnded = false;

            SaveCoins();
            OnGamePanel.SetActive(false);
            EndLevelPanel.SetActive(true);
        }
    }

    private void SaveCoins()
    {
        int numOfCoins = CoinsCollectorManager.CoinsCounter;
        PlayerPrefs.SetInt(Constants.PPUserCoins, PlayerPrefs.GetInt(Constants.PPUserCoins) + numOfCoins);
    }

    public void OnlyMainMenu()
    {
        OnGamePanel.SetActive(false);
        EndLevelPanel.SetActive(false);
    }
}
