using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuOptions : MonoBehaviour
{
    public void Play()
    {
        GameManager.playMode = GameManager.EPlayMode.SetCamera;
        Camera.main.GetComponent<CameraMovement>().enabled = true;
    }
}
