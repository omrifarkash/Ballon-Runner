using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceUp : MonoBehaviour
{
    private float randomY;
    private float randomX;
    private float randomZ;


    // Start is called before the first frame update
    void Start()
    {
        randomX = Random.Range(0, 5000);
        randomY = Random.Range(0, 5000);
        randomZ = Random.Range(0, 10000);

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z + randomZ));
    }
}
