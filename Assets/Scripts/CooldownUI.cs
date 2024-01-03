using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour
{
    public ShopManager shopManager;

    public TextMeshProUGUI hpUpgradeCost;
    public TextMeshProUGUI dashUpgradeCost;
    public TextMeshProUGUI speedUpgradeCost;
    public TextMeshProUGUI slashUpgradeCost;
    public TextMeshProUGUI projUpgradeCost;

    public Image FireballCooldown;
    public Image DashCooldown;
    public Image AttackCooldown;
    public Image EarthCooldown;

    // Update is called once per frame
    void Update()
    {
        DashCooldown.fillAmount = 1 - (Movement.dashCooldown / Movement.uiDashCooldown);

        AttackCooldown.fillAmount = 1 - (Attack.attackCooldown / Attack.uiAttackCooldown);

        FireballCooldown.fillAmount = 1 - (Attack.fireballCooldown / Attack.uiFireballCooldown);

        EarthCooldown.fillAmount = 1 - (Attack.earthCooldown / Attack.uiEarthCooldown);


        hpUpgradeCost.text = shopManager.coinCostHp.ToString();
        dashUpgradeCost.text = shopManager.coinCostDashCdUp.ToString();
        speedUpgradeCost.text = shopManager.coinCostBOS.ToString();
        slashUpgradeCost.text = shopManager.coinCostSlashUp.ToString();
        projUpgradeCost.text = shopManager.coinCostProjUp.ToString();
    }
}

/*
 * po przekroczeniu ca³ego ¿ycia ma dodawaæ overheal a¿ do realnego overheal
 */
