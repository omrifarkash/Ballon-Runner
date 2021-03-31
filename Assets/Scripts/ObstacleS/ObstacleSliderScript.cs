using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSliderScript : MonoBehaviour
{
    private GameObject player1;
    public bool imRightSlider=true;
    private bool playerOnMe;
    private float sideMove = -1;
    private float movePlayerSpeed;
    private float scrollSpeed = 1.5f;
    private Renderer ArrowRenderer;
    private void Start()
    {
         player1 = GameManager.Player1;
        ArrowRenderer = transform.GetChild(0).gameObject.GetComponent<Renderer>();
        if (imRightSlider)
        {
            sideMove *= -1;
            // here i need to rotate child 180 on the y
            transform.GetChild(0).transform.Rotate(0.0f, 180f, 0.0f, Space.Self);
        }
        playerOnMe = false;
        movePlayerSpeed = Constants.SliderObstacleMovePlayerSpeed;
    }


    private void Update()
    {
        if (playerOnMe)
        {
            Vector3 current = player1.transform.position;
            Vector3 target = current + new Vector3(sideMove, 0, 0);
            player1.transform.position = Vector3.MoveTowards(
                            current, target ,movePlayerSpeed * Time.deltaTime);
        }
        scrolling();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnMe = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnMe = false;
        }
    }

    private void scrolling()
    {
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
         x *= -1;
        Vector2 offset = new Vector2(x, 0);
        ArrowRenderer.material.SetTextureOffset("_MainTex", offset);
    }



}
