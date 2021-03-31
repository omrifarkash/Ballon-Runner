using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class PlayerGravityManager : MonoBehaviour
{
    private Rigidbody RB;
    public static bool IsFlying;

    public static GameObject CurrentPlatform;
    public GameObject NextPlatform;

    void Awake()
    {
        IsFlying = false;
        RB = GetComponent<Rigidbody>();

        CurrentPlatform = GameManager.StartPlatform;
    }

    private void FixedUpdate()
    {
        if (IsFlying)
        {
            fly();
            EnableFlyingParticaleSystem();
        }
        else
        {
            setNextPlatform();
            DidableFlyingPaticaleSystme();
        }
    }

    private void DidableFlyingPaticaleSystme()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }

    private void EnableFlyingParticaleSystem()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }

    private void fly()
    {
        float nextPlatformStartingZ = NextPlatform.transform.position.z - NextPlatform.GetComponent<Renderer>().bounds.size.z / 2;
        float nextPlatformStartingY = NextPlatform.transform.position.y + NextPlatform.GetComponent<Renderer>().bounds.size.y / 2;

        float distZ = Mathf.Abs(nextPlatformStartingZ - transform.position.z);
        float time = distZ / Constants.PlayerForwardSpeed;

        float distY = Mathf.Abs(nextPlatformStartingY - transform.position.y);

        float yMovement = Time.deltaTime / time * distY;

        transform.position -= new Vector3(0, yMovement, 0);
    }

    private void setNextPlatform()
    {
        GameObject nextPlatform = new GameObject();

        float minDistanceInZPlus = float.MaxValue;
        foreach(GameObject platform in PlatformsOps.Platforms)
        {
            // after the current platform
            if(platform.transform.position.z > CurrentPlatform.transform.position.z)
            {
                // closer to current platform
                if(Mathf.Abs(platform.transform.position.z - CurrentPlatform.transform.position.z) < minDistanceInZPlus)
                {
                    minDistanceInZPlus = Mathf.Abs(platform.transform.position.z - CurrentPlatform.transform.position.z);
                    nextPlatform = platform.gameObject;
                }
            }
        }

        NextPlatform = nextPlatform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Platform") || collision.collider.CompareTag("EndPlatform"))
        {
            RB.useGravity = true;
            IsFlying = false;
            Constants.PlayerForwardSpeed = Constants.PlayerForwardSpeedAtStart;
            SoundManager.i().stopPlaySound(Constants.Sound.on_air);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            RB.useGravity = false;
            IsFlying = true;
            Constants.PlayerForwardSpeed = Constants.PlayerForwardSpeedMax;
            SoundManager.i().playOnce(Constants.Sound.on_air);
            //Camera.main.GetComponent<MotionBlur>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlatformAirZoneStart"))
        {
            RB.useGravity = true;
            IsFlying = false;
            Constants.PlayerForwardSpeed = Constants.PlayerForwardSpeedLowDown;
            //Camera.main.GetComponent<MotionBlur>().enabled = false;
        }
    }
}
