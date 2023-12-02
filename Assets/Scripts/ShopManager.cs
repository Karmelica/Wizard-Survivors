using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class ShopManager : MonoBehaviour
{
    public bool check = false;
    private readonly bool bActive = true;

    [Header("Properties")]
    public int coinCostHp = 10;
    public int coinCostDc = 15;
    public int coinCostBOS = 20;

    public TimeManager timeManager;
    public ShopUIManager shopUIManager;

    public void Shop()
    {
        if (Input.GetKeyDown(KeyCode.B) && check == false && Stats.unlockShop)
        {
            Time.timeScale = 0f;
            check = !check;
            ShopUIManager.Instance.ButtonActive(bActive);
        }
        else if (Input.GetKeyDown(KeyCode.B) || (Input.GetKeyDown(KeyCode.Escape)) && check == true)
        {
            Time.timeScale = 1f;
            check = !check;
            ShopUIManager.Instance.ButtonActive(!bActive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Shop();
    }
}
