using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    public static ShopUIManager Instance;

    [Header("Components")]
    public Stats stats;
    public CoinCounter coinCounter;
    public ShopManager shopManager;
    public HealthBar healthBar;

    [Header("Properties")]
    [SerializeField] 
    Button button;
    


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        button.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseHealth()
    {
        if (stats.currentCoins >= shopManager.coinCostHp)
        {
            stats.maxHp += 20;
            stats.currentCoins -= shopManager.coinCostHp;
            coinCounter.CoinCount(stats.currentCoins);
            healthBar.SetMaxHealth(stats.maxHp);
        }
    }

    public void ButtonActive(bool bActive)
    {
      if (bActive)
        {
            button.gameObject.SetActive(true);
        }
       else if (!bActive)
        {
            button.gameObject.SetActive(false);
        }
    }
}
