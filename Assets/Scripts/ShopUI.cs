using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject icon;
    public GameObject text;

    private bool oneTime;
    
    public Stats stats;

    public void Start()
    {
        icon.SetActive(false);
        text.SetActive(false);
    }

    void Update()
    {
        if (stats.currentCoins > 0 && oneTime == false)
        {
            oneTime = !oneTime;
            icon.SetActive(true);
            text.SetActive(true);
            StartCoroutine(Text(5f));
        }
    }

    private IEnumerator Text(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        text.SetActive(false);
    }
}
