using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            coin.SetTarget(transform.parent.position);
        }
    }
}
