﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMainMenu : MonoBehaviour
{
    public void DoIt()
    {
        CoinsCollectorManager.CoinsCounter = 0;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
