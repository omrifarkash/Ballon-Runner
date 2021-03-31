using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator playerAnimator;
    Vector3 SCALE;
    private bool firstTime;

    private void Start()
    {
        playerAnimator = transform.GetChild(0).GetComponent<Animator>();
        SCALE = transform.localScale;
        firstTime = true;
    }

    private void Update()
    {
        transform.localScale = SCALE;
        if(firstTime && GameManager.playMode == GameManager.EPlayMode.Play)
        {
            playerAnimator.SetTrigger("Run");
            firstTime = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.collider.CompareTag("Platform") && GameManager.playMode == GameManager.EPlayMode.Play)
        {
            playerAnimator.SetTrigger("Run");
        }
        if (collision.collider.CompareTag("EndPlatform") && GameManager.playMode == GameManager.EPlayMode.Play)
        {
            playerAnimator.SetTrigger("Release");
            // ballons script
        }
        if (collision.collider.CompareTag("EndPlatform") && GameManager.playMode == GameManager.EPlayMode.End)
        {
            transform.LookAt(new Vector3(Camera.main.transform.position.x,transform.position.y, Camera.main.transform.position.z));
            playerAnimator.SetTrigger("Release");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlatformAirZoneEnd") && GameManager.playMode == GameManager.EPlayMode.Play)
        {
            playerAnimator.SetTrigger("Fly");
        }
    }
}
