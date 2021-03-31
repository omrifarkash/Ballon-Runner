using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SetBalloonsText : MonoBehaviour
{
    private Text BallonsCountText;

    // Start is called before the first frame update
    void Start()
    {
        BallonsCountText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        BallonsCountText.text = BalloonCollisionsManager.BalloonCount.ToString();
    }
}
