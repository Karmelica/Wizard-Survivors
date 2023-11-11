using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour
{

    [SerializeField]
    public Image FireballCooldown;
    public Image DashCooldown;
    public Image AttackCooldown;

    private int dashCooldownInt;
    private int attackCooldownInt;
    private int fireballCooldownInt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DashCooldown.fillAmount = Movement.dashCooldown / Movement.uiDashCooldown;

        AttackCooldown.fillAmount = Attack.attackCooldown / Attack.uiAttackCooldown;

        FireballCooldown.fillAmount = Shooting.fireballCooldown / Shooting.uiFireballCooldown;

    }
}
