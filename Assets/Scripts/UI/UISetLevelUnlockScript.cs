using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISetLevelUnlockScript : MonoBehaviour
{
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string CurrentLevel = SceneManager.GetActiveScene().name;
        int LevelNumber = Int32.Parse(CurrentLevel.Substring(5));
        if(LevelNumber + 1 < Constants.MaxLevelNumber)
        {
            text.text = "Level " + (LevelNumber + 1) + " unlocked!!";
        }
        else
        {
            text.text = "You finished the game!!";
        }
    }
}
