using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class ShopManager : MonoBehaviour
{
    [SerializeField] 
    public bool check = false;
    bool bActive = true;

    [Header("Properties")]
    public int coinCostHp = 10;
    public int coinCostDc = 15;
    public int coinCostSw = 30;

    public TimeManager timeManager;

    public void Shop()
    {
        if (Input.GetKeyDown(KeyCode.B) && check == false)
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shop();
    }
}
