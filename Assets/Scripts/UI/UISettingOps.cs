using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISettingOps : MonoBehaviour
{
    public GameObject InGameSettingPanel;
    public static GameManager.EPlayMode prevPlayMode;

    // Start is called before the first frame update
    void Start()
    {
        InGameSettingPanel.SetActive(false);
    }

    public void InGameSettingOpen()
    {
        prevPlayMode = GameManager.playMode;
        GameManager.playMode = GameManager.EPlayMode.Pause;
    }

    public void InGameSettingClose()
    {
        Time.timeScale = 1f;
        GameManager.playMode = prevPlayMode;
    }


}
