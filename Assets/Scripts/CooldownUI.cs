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
        
        if (Stats.currentHp >= Stats.maxHp)
        {
            overHeal = Stats.currentHp - Stats.maxHp;
            overHealBar.fillAmount = overHeal / (Stats.maxHp);
        }
    }
}
