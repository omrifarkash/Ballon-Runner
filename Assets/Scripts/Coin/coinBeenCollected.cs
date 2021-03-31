using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinBeenCollected : MonoBehaviour
{
    public static GameObject canvas;

    private void Start()
    {
        canvas = GameObject.Find("Canvas");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            canvas.GetComponent<CoinsCollectorManager>().coinHasBeenCollected();
           // SoundManager.i().stopPlaySound(Constants.Sound.coin_collected);
            SoundManager.i().playOnce(Constants.Sound.coin_collected);
            Destroy(gameObject);
        }
    }
}
