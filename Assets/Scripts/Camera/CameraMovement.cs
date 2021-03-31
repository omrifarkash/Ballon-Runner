using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    private float speed = 1;

    private void Awake()
    {
        Camera.main.fieldOfView = Constants.CameraFiledOfViewValue;
        GameManager.playMode = GameManager.EPlayMode.SetCamera;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(GameManager.playMode);
        if (GameManager.playMode == GameManager.EPlayMode.SetCamera)
        {
            moveToStartPosition();
            if (Mathf.Abs(transform.position.x - player.transform.position.x - Constants.CameraOffSetX) < 0.5f)
            {
                GameManager.playMode = GameManager.EPlayMode.WaitingToPlay;
            }
        }

        if(GameManager.playMode == GameManager.EPlayMode.WaitingToPlay)
        {
            lookAtPlayer();
        }
    }

    void Update()
    {
        if (GameManager.playMode != GameManager.EPlayMode.SetCamera && GameManager.playMode != GameManager.EPlayMode.StartMenu)
        {
            chasePlayer();
            SetFieldOfView(Constants.CameraFiledOfViewValue);
        }

        if ((GameManager.playMode == GameManager.EPlayMode.Pause))
        {
            lookAtPlayer();
        }
    }

    private void chasePlayer()
    {
        if (!PlayerGravityManager.IsFlying)
        {
            Constants.CameraFiledOfViewValue = 75f;
        }
        else 
        {
            Constants.CameraFiledOfViewValue = 90f;
        }
        transform.position = new Vector3(
                            Constants.CameraOffSetX,
                            player.transform.position.y + Constants.CameraOffSetY,
                            player.transform.position.z + Constants.CameraOffSetZ);
    }

    private void moveToStartPosition()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            player.transform.position + new Vector3(Constants.CameraOffSetX, Constants.CameraOffSetY, Constants.CameraOffSetZ),
            speed * Time.fixedDeltaTime);

        lookAtPlayer();
    }

    private void SetFieldOfView(float value)
    {
        Camera.main.fieldOfView = Mathf.Lerp(
                    Camera.main.fieldOfView, value, Time.deltaTime * Constants.CameraChangeFiledOfViewSpeed);
    }

    private void lookAtPlayer()
    {
        transform.LookAt(player.transform.position + Vector3.forward * 30);
    }
}
