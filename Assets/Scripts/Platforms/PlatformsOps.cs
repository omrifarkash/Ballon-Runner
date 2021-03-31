using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsOps : MonoBehaviour
{
    public static float MinYPlatform;
    public static int BalloonNumberInScene;
    public static List<GameObject> Platforms;

    // Start is called before the first frame update
    void Start()
    {
        Platforms = new List<GameObject>();
        MinYPlatform = GameManager.StartPlatform.transform.position.y;
        FindNumOfPlatformsAndBalloons();
    }

    private void FindNumOfPlatformsAndBalloons()
    {
        foreach (Transform platformGroup in transform)
        {
            foreach (Transform singlePlatform in platformGroup)
            {
                Platforms.Add(singlePlatform.gameObject);

                if (singlePlatform.position.y < MinYPlatform)
                {
                    MinYPlatform = singlePlatform.position.y;
                }

                foreach (Transform singleTranformChil in singlePlatform)
                {
                    if (singleTranformChil.name.Equals("Obstecales"))
                    {
                        foreach (Transform obstecaleGroup in singleTranformChil)
                        {
                            if (obstecaleGroup.name.Equals("Balloons"))
                            {
                                BalloonNumberInScene += obstecaleGroup.childCount;
                            }
                        }
                    }
                }
            }
        }
    }

    public static void AddOneToBalloonCounter()
    {
        BalloonNumberInScene++;
    }
}
