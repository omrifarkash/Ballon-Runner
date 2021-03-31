using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepOnGazer : MonoBehaviour
{
    private ComboManager comboManager;
    private Vector3 target;
    private Vector3 startPosition;
    private float startTime;
    private float distance;
    void Start()
    {
        comboManager = ComboManager.i();

        int balloonCount = BalloonCollisionsManager.BalloonCount;
        int ComboIndex = (balloonCount * comboManager.TotalCombosInLevel) / PlatformsOps.BalloonNumberInScene;
        if (ComboIndex >= comboManager.TotalCombosInLevel)
            ComboIndex--;

        target = comboManager.combosArray[ComboIndex].transform.position;
        target.z -= 15;
        target.y -= 6f;
        target.x -= 4f;
        startPosition = transform.position;

        startTime = Time.time;
        distance = Vector3.Distance(startPosition, target);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.playMode == GameManager.EPlayMode.Play)
        {
            moveToTarget();
        }

    }


    private void moveToTarget()
    {

        float distCovered = (Time.time - startTime) * 25;

        float fractionOfJourney = distCovered / distance;
        if (fractionOfJourney >= 0.99)
        {
            transform.position += Vector3.forward * 15 * Time.fixedDeltaTime;
            transform.position = new Vector3(transform.position.x, target.y, transform.position.z);

        }

        else
        {
            Vector3 temp = new Vector3(target.x, target.y + 1, target.z);
            transform.position = Vector3.Lerp(startPosition, temp, fractionOfJourney);
        }
    }

}