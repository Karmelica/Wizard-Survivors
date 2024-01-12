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
        if(Movement.dashUnlocked)
        {
            var tempColor = DashCooldown.color;
            tempColor.a = 1;
            DashCooldown.color = tempColor;
            DashCooldown.fillAmount = 1 - (Movement.dashCooldown / Movement.uiDashCooldown);
        }

        if(Attack.slashUnlocked)
        {
            var tempColor = AttackCooldown.color;
            tempColor.a = 1;
            AttackCooldown.color = tempColor;
            AttackCooldown.fillAmount = 1 - (Attack.attackCooldown / Attack.uiAttackCooldown);
        }

        if(Attack.earthUnlocked)
        {
            var tempColor = EarthCooldown.color;
            tempColor.a = 1;
            EarthCooldown.color = tempColor;
            EarthCooldown.fillAmount = 1 - (Attack.earthCooldown / Attack.uiEarthCooldown);

        }

        FireballCooldown.fillAmount = 1 - (Attack.fireballCooldown / Attack.uiFireballCooldown);


        hpUpgradeCost.text = shopManager.coinCostHp.ToString();
        dashUpgradeCost.text = shopManager.coinCostDashCdUp.ToString();
        speedUpgradeCost.text = shopManager.coinCostBOS.ToString();
        slashUpgradeCost.text = shopManager.coinCostSlashUp.ToString();
        projUpgradeCost.text = shopManager.coinCostProjUp.ToString();
    }
}

/*
 * po przekroczeniu ca�ego �ycia ma dodawa� overheal a� do realnego overheal
 */
