using UnityEngine;

public class Attack : MonoBehaviour

{
    [SerializeField]
    public SpriteRenderer anim;
    public Collider2D colid;
    public float cooldownOrg = 4.0f;
    private float cooldown;

    void AnimCooldown()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 1.0f)
        {
            colid.enabled = true;
            anim.enabled = true;
        }
        if (cooldown <= 0.0f)
        {
            cooldown = cooldownOrg;
            colid.enabled = false;
            anim.enabled = false;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        cooldown = cooldownOrg;
        colid.enabled = false;
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        AnimCooldown();
    }
}
