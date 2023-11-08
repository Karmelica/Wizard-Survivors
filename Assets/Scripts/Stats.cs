using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("Stats")]
    public int maxHp = 100;
    public int playerDmg = 1;
    static public int currentHp;
    static public int currentExp = 0;

    [Header("Components")]
    public HealthBar healthBar;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(Enemy.enemyDmg);
        }
    }

    void TakeDamage(int damage)
    {
        currentHp -= damage;
        healthBar.SetHealth(currentHp);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        healthBar.SetMaxHealth(maxHp);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
