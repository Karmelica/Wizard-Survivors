using UnityEngine;

public class Slash : MonoBehaviour
{
    //public HealthBar healthBar;
    private Animator animator;
    private float time = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* narazie zostawiam to wylaczone
        Stats.currentHp += heal;
        healthBar.SetHealth(Stats.currentHp);
        */
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("SlashNew");
        //healthBar = FindObjectOfType<HealthBar>();
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }
}
