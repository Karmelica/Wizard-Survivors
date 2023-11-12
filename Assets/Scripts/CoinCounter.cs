using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public Text coins;

    public void CoinCount(int amount)
    {
        coins.text = amount.ToString();
    }
}
