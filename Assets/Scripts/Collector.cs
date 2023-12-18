using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public Stats stats;
    public CoinCounter coinCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            stats.currentCoins++;
            coinCounter.CoinCount(stats.currentCoins);
        }
    }
}
