using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour
{

    [SerializeField]
    public Image FireballCooldown;
    public Image DashCooldown;
    public Image AttackCooldown;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        DashCooldown.fillAmount = 1 - (Movement.dashCooldown / Movement.uiDashCooldown);

        AttackCooldown.fillAmount = 1 - (Attack.attackCooldown / Attack.uiAttackCooldown);

        FireballCooldown.fillAmount = 1 - (Shooting.fireballCooldown / Shooting.uiFireballCooldown);
        
        
    }
}

/*
 * po przekroczeniu ca³ego ¿ycia ma dodawaæ overheal a¿ do realnego overheal
 */
