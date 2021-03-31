using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementSetter : MonoBehaviour
{
    private GameObject Player;
    private GameObject StartPaltform;
    private GameObject EndPlatform;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameManager.Player1;
        StartPaltform = GameManager.StartPlatform;
        EndPlatform = GameManager.EndPlatform;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Slider>().value = calculateNormalizedHeight();
    }

    private float calculateNormalizedHeight()
    {
        
        float platformDifference = Mathf.Abs(StartPaltform.transform.position.z - EndPlatform.transform.position.z);
        return (Mathf.Abs(Player.transform.position.z - EndPlatform.transform.position.z)) / platformDifference;
    }
}
