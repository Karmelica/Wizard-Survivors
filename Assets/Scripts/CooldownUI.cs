using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour
{

    [SerializeField]
    public Image FireballCooldown;
    public Image DashCooldown;
    public Image AttackCooldown;
    public Image overHealBar;
    private float overHeal;
    private float vel = 1f;

    private void OverHeal()
    {
        if (Stats.currentHp > Stats.maxHp)
        {
            overHeal = Stats.currentHp - Stats.maxHp;
            float fillAmount = Mathf.SmoothDamp(overHealBar.fillAmount, overHeal/Stats.maxHp, ref vel, 200 * Time.deltaTime);
            overHealBar.fillAmount = fillAmount;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        overHeal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        DashCooldown.fillAmount = Movement.dashCooldown / Movement.uiDashCooldown;

        AttackCooldown.fillAmount = Attack.attackCooldown / Attack.uiAttackCooldown;

        FireballCooldown.fillAmount = Shooting.fireballCooldown / Shooting.uiFireballCooldown;
        
        OverHeal();
        
    }
}

/*
 * po przekroczeniu ca³ego ¿ycia ma dodawaæ overheal a¿ do realnego overheal
 */
