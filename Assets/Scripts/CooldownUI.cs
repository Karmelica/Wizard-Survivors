using TMPro;
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
        if (Movement.dashCooldown > 0f)
        {
            DashCooldown.enabled = true;
            dashCooldownInt = Mathf.RoundToInt(Movement.dashCooldown);
            DashCooldown.fillAmount = Movement.dashCooldown / 5f;
        }
        else
        {
            DashCooldown.enabled = false;
        }

        if (Attack.attackCooldown > 0f)
        {
            AttackCooldown.enabled = true;
            attackCooldownInt = Mathf.RoundToInt(Attack.attackCooldown);
            AttackCooldown.fillAmount = Attack.attackCooldown / 3f;
        }
        else
        {
            AttackCooldown.enabled = false;
        }

        if (Shooting.fireballCooldown > 0f)
        {
            FireballCooldown.enabled = true;
            fireballCooldownInt = Mathf.RoundToInt(Shooting.fireballCooldown);
            FireballCooldown.fillAmount = Shooting.fireballCooldown / 1f;
        }
        else
        {
            FireballCooldown.enabled = false;
        }
    }
}
