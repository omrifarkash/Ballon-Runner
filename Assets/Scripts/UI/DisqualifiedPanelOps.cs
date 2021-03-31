using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisqualifiedPanelOps : MonoBehaviour
{
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        GameManager.playMode = GameManager.EPlayMode.StartMenu;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        GameManager.playMode = GameManager.EPlayMode.SetCamera;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
