using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject pfSlash;
    public GameObject pfFireball;
    public Animator animator;
    public Animator slash;
    public GameObject player;
    private Stats stats;

    static public bool attackUpgraded = false;
    static public bool projectileUpgraded = false;

    public float setAttackCooldown = 3f;
    public float setFireballCooldown = 1f;
    static public float uiAttackCooldown;
    static public float uiFireballCooldown;
    static public float attackCooldown;
    static public float fireballCooldown;

    IEnumerator Fireball()
    {

        if (projectileUpgraded)
        {
            animator.Play("Attack");
            fireballCooldown = setFireballCooldown;
            Instantiate(pfFireball, player.transform.position, Quaternion.identity).GetComponent<Damage>().SetDamage(stats.projectileDmg);
            yield return new WaitForSeconds(0.2f);
            Instantiate(pfFireball, player.transform.position, Quaternion.identity).GetComponent<Damage>().SetDamage(stats.projectileDmg);
            yield return new WaitForSeconds(0.2f);
            Instantiate(pfFireball, player.transform.position, Quaternion.identity).GetComponent<Damage>().SetDamage(stats.projectileDmg);
        }
        else
        {
            animator.Play("Attack");
            fireballCooldown = setFireballCooldown;
            Instantiate(pfFireball, player.transform.position, Quaternion.identity).GetComponent<Damage>().SetDamage(stats.projectileDmg);
        }
    }

    void Slash()
    {
        if (attackUpgraded)
        {
            animator.Play("Attack");
            attackCooldown = setAttackCooldown;
            if (transform.rotation.y == 0)
            {
                Instantiate(pfSlash, transform.position + new Vector3(0.5f, 0, 0), transform.rotation)
                    .GetComponent<Damage>().SetDamage(stats.slashDmg);
                Instantiate(pfSlash, transform.position + new Vector3(0.5f, 0, 0) * -1, transform.rotation * Quaternion.Euler(180, 180, 0))
                    .GetComponent<Damage>().SetDamage(stats.slashDmg);
            }
            else
            {
                Instantiate(pfSlash, transform.position + new Vector3(0.5f, 0, 0) * -1, transform.rotation).GetComponent<Damage>()
                    .SetDamage(stats.slashDmg);
                Instantiate(pfSlash, transform.position + new Vector3(0.5f, 0, 0), transform.rotation * Quaternion.Euler(180, 180, 0))
                    .GetComponent<Damage>().SetDamage(stats.slashDmg);
            }
        }
        else
        {
            animator.Play("Attack");
            attackCooldown = setAttackCooldown;
            if (transform.rotation.y == 0)
            {
                Instantiate(pfSlash, transform.position + new Vector3(0.5f, 0, 0), transform.rotation)
                .GetComponent<Damage>().SetDamage(stats.slashDmg);
            }
            else
            {
                Instantiate(pfSlash, transform.position + new Vector3(0.5f, 0, 0) * -1, transform.rotation)
                .GetComponent<Damage>().SetDamage(stats.slashDmg);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        stats = player.GetComponent<Stats>();
        attackUpgraded = false;
        projectileUpgraded = false;

        uiAttackCooldown = setAttackCooldown;
        attackCooldown = 0f;

        uiFireballCooldown = setFireballCooldown;
        fireballCooldown = 0f;

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && fireballCooldown <= 0f && Time.timeScale != 0)
        {
            StartCoroutine(Fireball());
        }
        if (Input.GetMouseButton(0) && attackCooldown <= 0f && Time.timeScale != 0)
        {
            Slash();
        }

        attackCooldown -= Time.deltaTime;
        fireballCooldown -= Time.deltaTime;

    }
}
