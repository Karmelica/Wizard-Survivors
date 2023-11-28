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
    public Movement movement;
    public GameObject Shop;
    public GameObject cooldownUpgradeButton;

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
        Shop.SetActive(false);  
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
            Stats.currentHp = stats.maxHp;
            healthBar.SetMaxHealth(stats.maxHp);
        }
    }

    public void CooldownDecrease()
    {
        if (stats.currentCoins >= shopManager.coinCostDc)
        {
            movement.setDashCooldown = 3f;
            Movement.uiDashCooldown = 3f;
            stats.currentCoins -= shopManager.coinCostDc;
            coinCounter.CoinCount(stats.currentCoins);
            cooldownUpgradeButton.SetActive(false);
        }
    }

    public void ButtonActive(bool bActive)
    {
      if (bActive)
        {
            Shop.SetActive(true);
        }
       else if (!bActive)
        {
            Shop.SetActive(false);
        }
    }
}
