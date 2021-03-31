using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private bool stepOnEndPlatform = false;
    public float XlimitRight = float.MaxValue;
    public float XlimitLeft = float.MinValue;
    private float normalSpeed;
    private bool setNormalSpeedOnce = true;
    public static GameObject canvas;
    private bool onGazer = false;

    private void Start()
    {
        transform.GetComponent<stepOnGazer>().enabled = false;
        canvas = GameObject.Find("Canvas");
        normalSpeed = Constants.PlayerForwardSpeedAtStart;
    }


    void FixedUpdate()
    {
        if (GameManager.playMode == GameManager.EPlayMode.Play && !stepOnEndPlatform && TutoriaEnableMovement() && !onGazer)
        {
            MovementForward();
            inputHandeler();
        }
        dontFallFromPlatromCheck();

        if(Constants.gazerTimer <= Constants.gazerTimerMax)
        {
            onGazerObstacleMoveUp();
            Constants.gazerTimer += Time.fixedDeltaTime;
        }

        if (isEndOfGame())
        {
            GameManager.playMode = GameManager.EPlayMode.disqualified;
        }
    }

    private bool isEndOfGame()
    {
        return (transform.position.y < PlatformsOps.MinYPlatform - 20);
    }

    private void MovementForward()
    {
        transform.position += new Vector3(0, 0, 1) * Constants.PlayerForwardSpeed * Time.fixedDeltaTime;
    }

    private void inputHandeler()
    {
        //touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float delta = touch.position.x - Camera.main.WorldToScreenPoint(transform.position).x;
                transform.position = transform.position += new Vector3(delta, 0, 0) * Time.fixedDeltaTime *Constants.PlayerSideSpeed;
            }
        }

        //keyboard input, can be removed after game is complete. remove also moveRight \ Left functions
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                moveRight();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveLeft();
            }
        }
    }

    private bool TutoriaEnableMovement()
    {
        bool ans = true;

        if (SceneManager.GetActiveScene().name.Equals("Level1"))
        {
            if (!ToturialManager.allowMovement)
            {
                ans = false;
            }
        }

        return ans;
    }

    private void moveRight()
    {
        transform.position += new Vector3(1, 0, 0) * 100 * Constants.PlayerSideSpeed * Time.fixedDeltaTime;
    }

    private void moveLeft()
    {
        transform.position += new Vector3(-1, 0, 0) * 100 * Constants.PlayerSideSpeed * Time.fixedDeltaTime;
    }

    private void dontFallFromPlatromCheck()
    {
        if (transform.position.x >= XlimitRight)
        {
            transform.position = new Vector3(XlimitRight, transform.position.y, transform.position.z);
        }

        else if (transform.position.x <= XlimitLeft)
        {
            transform.position = new Vector3(XlimitLeft, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            PlayerGravityManager.CurrentPlatform = collision.collider.gameObject;

            Constants.PlayerForwardSpeed = normalSpeed;
            setNormalSpeedOnce = true;
            GameObject curPlatform = collision.collider.gameObject;
            float halfSizeOfCurPlatform = curPlatform.GetComponent<Renderer>().bounds.size.x / 2;
            XlimitRight = curPlatform.transform.position.x + halfSizeOfCurPlatform - 1;
            XlimitLeft = curPlatform.transform.position.x - halfSizeOfCurPlatform + 1;
        }

        if (collision.collider.CompareTag("EndPlatform"))
        {
            PlayerGravityManager.CurrentPlatform = collision.collider.gameObject;

            GameManager.playMode = GameManager.EPlayMode.End;

            confetti(collision);

            // Here??
            unlockNewLevel();

            if (!stepOnEndPlatform)
            {
                SoundManager.i().backGroundMusic.Stop();
                SoundManager.i().playOnce(Constants.Sound.completeLVL);
            }
            stepOnEndPlatform = true;
        }
    }

    // Need to move to other class
    private void unlockNewLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        int curerntLevel = Int32.Parse(currentSceneName.Substring(5));

        if (curerntLevel + 1 <= Constants.MaxLevelNumber)
        {
            PlayerPrefs.SetInt("Level" + (curerntLevel + 1), 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PlatformAirZoneEnd"))
        {
            XlimitRight = float.MaxValue;
            XlimitLeft = float.MinValue;
        }

        if (other.CompareTag("PlatformAirZoneStart"))
        {
            if (setNormalSpeedOnce)
            {
                normalSpeed = Constants.PlayerForwardSpeed;
                setNormalSpeedOnce = false;
            }
            Constants.PlayerForwardSpeed = Constants.PlayerForwardSpeedLowDown;
        }

        if (other.gameObject.CompareTag("Crack"))
        {
            transform.GetComponent<stepOnGazer>().enabled = true;
            onGazer = true;
        }

        if (other.gameObject.CompareTag("Combo"))
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            CoinsCollectorManager.CoinsCounter *= Int32.Parse(other.name.Substring(5));
        }

        if (other.gameObject.tag == "Coin")
        {
            canvas.GetComponent<CoinsCollectorManager>().coinHasBeenCollected();
            // SoundManager.i().stopPlaySound(Constants.Sound.coin_collected);
            SoundManager.i().playOnce(Constants.Sound.coin_collected);
            Destroy(other.gameObject);
        }
    }

    private void confetti(Collision collision)
    {
        transform.GetChild(2).gameObject.SetActive(true);
    }

    private void onGazerObstacleMoveUp()
    {
        transform.position += Vector3.up * Constants.gazerSpeed * Constants.gazerTimer * Time.fixedDeltaTime;
    }
}