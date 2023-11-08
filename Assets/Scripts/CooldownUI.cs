using TMPro;
using UnityEngine;

public class CooldownUI : MonoBehaviour
{

    [SerializeField]
    public TextMeshProUGUI DashCooldown;
    public TextMeshProUGUI AttackCooldown;

    private int dashCooldownInt;
    private int attackCooldownInt;

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
            DashCooldown.text = ("Dash cooldown: " + dashCooldownInt.ToString());
        }
        else
        {
            DashCooldown.enabled = false;
        }

        if (Attack.attackCooldown > 0f)
        {
            AttackCooldown.enabled = true;
            attackCooldownInt = Mathf.RoundToInt(Attack.attackCooldown);
            AttackCooldown.text = ("Attack cooldown: " + attackCooldownInt.ToString());
        }
        else
        {
            AttackCooldown.enabled = false;
        }
    }
}
