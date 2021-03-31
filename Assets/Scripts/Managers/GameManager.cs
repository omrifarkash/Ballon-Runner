using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static EPlayMode playMode;

    private static GameManager instance;
    public static GameObject Player1;
    public static GameObject StartPlatform;
    public static GameObject EndPlatform;
    public static GameObject Pipes;

    // Start is called before the first frame update
    void Awake()
    {
        PlatformsOps.BalloonNumberInScene = Constants.PlayerStartsCountBlloon;
        ToturialManager.allowMovement = false;

        instance = this;
        Player1 = GameObject.Find("Player1");
        StartPlatform = GameObject.Find("StartPlatform");
        EndPlatform = GameObject.Find("EndPlatform");
        Pipes = GameObject.Find("Pipes");
    }

    private void Update()
    {
        Debug.Log(playMode);
        //   || Input.anyKeyDown) need to remove
        if ((Input.touchCount > 0  || Input.anyKeyDown)&& GameManager.playMode == GameManager.EPlayMode.WaitingToPlay)
        {
            playMode = EPlayMode.Play;
            SoundManager.i().backGroundMusic.Play();
        }
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public enum EPlayMode
    {
        StartMenu,
        SetCamera,
        WaitingToPlay,
        Play,
        Pause,
        disqualified,
        End,
    }
}
