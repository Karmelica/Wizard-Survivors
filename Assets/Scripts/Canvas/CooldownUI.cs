using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour
{
    public ShopManager shopManager;

    [SerializeField] private GameObject josh;
    static public int enemiesKilled = 0;

    public TextMeshProUGUI killed;
    public TextMeshProUGUI hpUpgradeCost;
    public TextMeshProUGUI dashUpgradeCost;
    public TextMeshProUGUI speedUpgradeCost;
    public TextMeshProUGUI slashUpgradeCost;
    public TextMeshProUGUI projUpgradeCost;

    public Image FireballCooldown;
    public Image DashCooldown;
    public Image AttackCooldown;
    public Image EarthCooldown;



    private IEnumerator JoshEnable()
    {
        josh.SetActive(true);
        yield return new WaitForSeconds(8);
        josh.SetActive(false);
    }

    public void Josh()
    {
        StartCoroutine(JoshEnable());
    }

    // Update is called once per frame
    void Update()
    {
        killed.text = enemiesKilled.ToString();

        if (Movement.dashUnlocked)
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
 * po przekroczeniu ca³ego ¿ycia ma dodawaæ overheal a¿ do realnego overheal
 */
