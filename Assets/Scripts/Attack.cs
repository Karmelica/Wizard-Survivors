using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject pfSlash;
    public GameObject pfFireball;
    public GameObject pfEarth;
    public Animator animator;
    public GameObject player;
    private Stats stats;

    static public bool slashUnlocked;
    static public bool earthUnlocked;
    static public bool IceUnlocked;


    static public bool attackUpgraded = false;
    static public bool projectileUpgraded = false;

    static public float attackCooldown;
    static public float uiAttackCooldown;
    public float setAttackCooldown = 3f;

    static public float fireballCooldown;
    static public float uiFireballCooldown;
    public float setFireballCooldown = 1f;

    static public float earthCooldown;
    static public float uiEarthCooldown;
    public float setEarthCooldown = 5f;

    

    IEnumerator Fireball()
    {

        if (projectileUpgraded)
        {
            animator.Play("Attack");
            fireballCooldown = setFireballCooldown;
            Instantiate(pfFireball, player.transform.position, Quaternion.identity)
            .GetComponent<Damage>().SetDamage(stats.projectileDmg);
            yield return new WaitForSeconds(0.2f);
            Instantiate(pfFireball, player.transform.position, Quaternion.identity)
            .GetComponent<Damage>().SetDamage(stats.projectileDmg);
            yield return new WaitForSeconds(0.2f);
            Instantiate(pfFireball, player.transform.position, Quaternion.identity)
            .GetComponent<Damage>().SetDamage(stats.projectileDmg);
        }
        else
        {
            animator.Play("Attack");
            fireballCooldown = setFireballCooldown;
            Instantiate(pfFireball, player.transform.position, Quaternion.identity)
            .GetComponent<Damage>().SetDamage(stats.projectileDmg);
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
                Instantiate(pfSlash, transform.position + new Vector3(0.5f, 0, 0) * -1, transform.rotation)
                .GetComponent<Damage>().SetDamage(stats.slashDmg);
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

    void Earth()
    {
        animator.Play("Attack");
        earthCooldown = setEarthCooldown;
        if (transform.rotation.y == 0)
        {
            Instantiate(pfEarth, transform.position + new Vector3(0.5f, 0, 0), transform.rotation)
            .GetComponent<Damage>().SetDamage(stats.earthDmg);
        }
        else
        {
            Instantiate(pfEarth, transform.position + new Vector3(0.5f, 0, 0) * -1, transform.rotation)
            .GetComponent<Damage>().SetDamage(stats.earthDmg);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        slashUnlocked = false;
        IceUnlocked = false;

        stats = player.GetComponent<Stats>();
        attackUpgraded = false;
        projectileUpgraded = false;

        uiAttackCooldown = setAttackCooldown;
        attackCooldown = 0f;

        uiFireballCooldown = setFireballCooldown;
        fireballCooldown = 0f;

        uiEarthCooldown = setEarthCooldown;
        earthCooldown = 0f;

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && fireballCooldown <= 0f && Time.timeScale != 0)
        {
            StartCoroutine(Fireball());
        }
        if (Input.GetMouseButton(0) && attackCooldown <= 0f && Time.timeScale != 0 && slashUnlocked)
        {
            Slash();
        }
        if (Input.GetKeyDown(KeyCode.Space) && earthCooldown <= 0f && Time.timeScale != 0)
        {
            Earth();
        }

        attackCooldown -= Time.deltaTime;
        fireballCooldown -= Time.deltaTime;
        earthCooldown -= Time.deltaTime;
    }
}
