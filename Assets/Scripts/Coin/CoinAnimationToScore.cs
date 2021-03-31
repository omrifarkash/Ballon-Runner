using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimationToScore : MonoBehaviour
{
    public GameObject UI_Coin;
    private Vector3 targetPosition;

    void Start()
    {
        UI_Coin = GameObject.Find("UI_Coin");
        targetPosition = UI_Coin.GetComponent<RectTransform>().position;
        targetPosition += new Vector3(UI_Coin.GetComponent<RectTransform>().rect.x / 2, UI_Coin.GetComponent<RectTransform>().rect.y / 2, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            Constants.CoinSpeedToUI * Time.fixedDeltaTime);
        if (transform.position.x == targetPosition.x)
        {
            CoinsCollectorManager.AddCoins(1);
            UI_Coin.GetComponent<UI_Coin_Swelling>().addPump();
            Destroy(gameObject);
        }
    }
}
