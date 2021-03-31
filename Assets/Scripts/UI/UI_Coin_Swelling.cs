using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Coin_Swelling : MonoBehaviour
{
    private float max_swell;
    private float min_swell;
    private float swell_index = 1.02f;
    private bool growUp = true;
    private Vector3 originScale;
    private int numberOfPumps = 0;

    void Start()
    {
        originScale = transform.localScale;
        min_swell = transform.localScale.x + transform.localScale.y;
        max_swell = transform.localScale.x + transform.localScale.y + .4f;
    }

    // Update is called once per frame
    void Update()
    {
        swell();
    }

    private void swell()
    {
        if (numberOfPumps > 0)
        {
            if (growUp)
            {
                transform.localScale *= swell_index;
                if (transform.localScale.x + transform.localScale.y > max_swell) growUp = false;
            }

            else
            {
                transform.localScale /= swell_index;
                if (transform.localScale.x + transform.localScale.y < min_swell)
                {
                    growUp = true;
                    numberOfPumps--;
                    transform.localScale = originScale;
                }
            }
        }
    }

    public void addPump()
    {
        if (numberOfPumps < 2)
            numberOfPumps++;
    }
}