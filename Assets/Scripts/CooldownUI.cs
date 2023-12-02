using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour
{
    public ShopManager shopManager;

    public TextMeshProUGUI hpUpgradeCost;
    public TextMeshProUGUI dashUpgradeCost;
    public TextMeshProUGUI speedUpgradeCost;

    public Image FireballCooldown;
    public Image DashCooldown;
    public Image AttackCooldown;

    // Update is called once per frame
    void Update()
    {
        DashCooldown.fillAmount = 1 - (Movement.dashCooldown / Movement.uiDashCooldown);

        AttackCooldown.fillAmount = 1 - (Attack.attackCooldown / Attack.uiAttackCooldown);

        FireballCooldown.fillAmount = 1 - (Shooting.fireballCooldown / Shooting.uiFireballCooldown);


        hpUpgradeCost.text = shopManager.coinCostHp.ToString();
        dashUpgradeCost.text = shopManager.coinCostDc.ToString();
        speedUpgradeCost.text = shopManager.coinCostBOS.ToString();
    }
}

/*
 * po przekroczeniu ca³ego ¿ycia ma dodawaæ overheal a¿ do realnego overheal
 */
