using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatformScript : MonoBehaviour
{
    private float maxX;
    private float minX;
   // private Vector3 startPosition;
    private float moveSpeed;
    private bool moveRight;
    void Start()
    {
        moveRight = true;
        moveSpeed = Constants.MovingPlatformMoveSpeed;
        maxX = transform.position.x + Constants.MovingPlatformMoveRange/2;
        minX = transform.position.x - Constants.MovingPlatformMoveRange/2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moving();
    }

    void moving()
    {
        if(moveRight)
        {
            transform.position += new Vector3(1, 0, 0) * moveSpeed * Time.fixedDeltaTime;
            if (transform.position.x >= maxX)
                moveRight = false;

        }
        else
        {
            transform.position += new Vector3(-1,0,0) * moveSpeed * Time.fixedDeltaTime;
            if (transform.position.x <= minX)
                moveRight = true;
        }
    }
}
