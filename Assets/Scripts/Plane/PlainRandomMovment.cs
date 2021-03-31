using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainRandomMovment : MonoBehaviour
{
    private Vector3 startPosition;
    private bool justCollide = false;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        GetComponent<ConstantForce>().force = transform.up * -1 * Constants.PlainEnvSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AirplainsAirField"))
        {
            if (!justCollide)
            {
                Debug.Log("NewPlain");
                GetComponent<ConstantForce>().force *= -1;
                transform.RotateAround(transform.position, transform.forward * -1, 180);
                justCollide = true;
            }
            else
            {
                justCollide = false;
            }
        }
    }
}
