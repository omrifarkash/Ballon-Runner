using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeigthSetter : MonoBehaviour
{
    private GameObject Player;
    private GameObject EndPlatform;
    private GameObject StartPlatform;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameManager.Player1;
        EndPlatform = GameManager.EndPlatform;
        StartPlatform = GameManager.StartPlatform;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Slider>().value = newCalculator();
    }


    private float newCalculator()
    {
        float endPlatformHeight = EndPlatform.transform.position.y;
        float playerHeight = Player.transform.position.y;
        float Scalar = Constants.SliderEnviromentHeightDifference;

        return ((playerHeight - PlatformsOps.MinYPlatform  + 20) / Scalar);
    }
}
