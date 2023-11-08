using System.Diagnostics.Tracing;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("Stats")]
    public int maxHp = 100;
    public static int exp = 0;
    public int playerDmg = 1;
    static public int currentHp;
    public int currentExp;

    [Header("Components")]
    public HealthBar healthBar;
    public ExpBar expBar;


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

    public void GainExp()
    {
        if (exp >= currentExp)
        {
            currentExp = exp;
            expBar.SetExp(currentExp);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        healthBar.SetMaxHealth(maxHp);
        currentExp = exp;
        expBar.SetStartExp(currentExp);
    }

    // Update is called once per frame
    void Update()
    {
        GainExp();
    }
}
