using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    public static ShopUIManager Instance;
    private bool canBuy;

    [Header("Scripts")]
    public Stats stats;
    public CoinCounter coinCounter;
    public ShopManager shopManager;
    public HealthBar healthBar;
    public Movement movement;

    [Header("GameObjects")]
    public GameObject cursor;
    public GameObject shop;
    public GameObject cooldownUpgradeButton;
    public GameObject bootsOfSwiftnessUpgradeButton;
    public GameObject slashUpgradeButton;
    public GameObject projectileUpgradeButton;
    public GameObject shopIndicator;

    public void IncreaseHealth()
    {
        if (stats.currentCoins >= shopManager.coinCostHp && canBuy)
        {
            stats.maxHp += 20;
            stats.currentCoins -= shopManager.coinCostHp;
            shopManager.coinCostHp++;
            healthBar.SetMaxHealth(stats.maxHp);
            Stats.unlockShop = false;
            canBuy = false;
        }
    }

    public void CooldownDecrease()
    {
        if (stats.currentCoins >= shopManager.coinCostDashCdUp && canBuy)
        {
            movement.setDashCooldown = 3f;
            Movement.uiDashCooldown = 3f;
            stats.currentCoins -= shopManager.coinCostDashCdUp;
            cooldownUpgradeButton.SetActive(false);
            Stats.unlockShop = false;
            canBuy = false;
        }
    }
    public void BootsOfSwiftness()
    {
        if (stats.currentCoins >= shopManager.coinCostBOS && canBuy)
        {
            Movement.playerSpeed*= 1.2f;
            stats.currentCoins -= shopManager.coinCostBOS;
            bootsOfSwiftnessUpgradeButton.SetActive(false);
            Stats.unlockShop = false;
            canBuy = false;
        }
    }

    public void SlashUpgrade()
    {
        if (stats.currentCoins >= shopManager.coinCostSlashUp && canBuy)
        {
            Attack.attackUpgraded = true;
            stats.currentCoins -= shopManager.coinCostSlashUp;
            slashUpgradeButton.SetActive(false);
            Stats.unlockShop = false;
            canBuy = false;
        }
    }
    public void ProjectileUpgrade()
    {
        if (stats.currentCoins >= shopManager.coinCostProjUp && canBuy)
        {
            Attack.projectileUpgraded = true;
            stats.currentCoins -= shopManager.coinCostProjUp;
            projectileUpgradeButton.SetActive(false);
            Stats.unlockShop = false;
            canBuy = false;
        }
    }

    public void ButtonActive(bool bActive)
    {
      if (bActive)
        {
            Cursor.visible = true;
            cursor.SetActive(false);
            shop.SetActive(true);
        }
       else if (!bActive)
        {
            Cursor.visible = false;
            cursor.SetActive(true);
            shop.SetActive(false);
        }
    }
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
        shop.SetActive(false);
    }

    void Update()
    {
        if(Stats.unlockShop)
        {
            shopIndicator.SetActive(true);
        }
        else
        {
            shopIndicator.SetActive(false);
            canBuy = true;
        }
    }

}
