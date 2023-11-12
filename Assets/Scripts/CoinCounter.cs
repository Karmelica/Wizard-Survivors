using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI coins;

    public void CoinCount(int amount)
    {
        coins.text = amount.ToString();
    }
}
