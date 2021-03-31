using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollectorManager : MonoBehaviour
{
    public GameObject coinImage2D;
    public GameObject Player;

    public static int CoinsCounter = 0;

    // Update is called once per frame
    public void coinHasBeenCollected()
    {
        Vector3 offset = new Vector3(1, 1, 0);
        Vector3 position = Camera.main.WorldToScreenPoint(Player.transform.position + offset);
        Instantiate(coinImage2D, position, Quaternion.identity, transform);
    }

    public static void AddCoins(int AddCoins)
    {
        CoinsCounter += AddCoins;
    }
}
