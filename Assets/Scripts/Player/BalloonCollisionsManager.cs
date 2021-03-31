using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;


public class BalloonCollisionsManager : MonoBehaviour
{
    public static int BalloonCount;

    public GameObject rightHand;

    // Start is called before the first frame update
    void Start()
    {
        BalloonCount = Constants.PlayerStartsCountBlloon;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Balloon"))
        {
            other.tag = "Untagged";
            other.gameObject.GetComponent<Collider>().isTrigger = false;
            BalloonCount++;
            other.transform.position = rightHand.transform.position;
            other.transform.parent = rightHand.transform;
            Instantiate(other);
        }
    }
}
