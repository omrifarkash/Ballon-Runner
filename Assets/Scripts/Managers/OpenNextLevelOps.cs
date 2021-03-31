using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenNextLevelOps : MonoBehaviour
{
    public void LoadNextLevel()
    {
        CoinsCollectorManager.CoinsCounter = 0;
        int currentLevel = Int32.Parse(SceneManager.GetActiveScene().name.Substring(5));
        string nextLevel = "Level" + (currentLevel + 1);
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
    }
}
