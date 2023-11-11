using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("Stats")]
    public int maxHp = 20;
    public int maxExp = 100;
    public int currentLevel = 1;
    public int currentCoins;
    public static int exp = 0;
    public int playerDmg = 1;
    static public int currentHp;
    public int currentExp;

    [Header("Components")]
    public HealthBar healthBar;
    public ExpBar expBar;
    public LevelCounter levelCounter;




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            currentCoins++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (GodMode.godMode == false)
            {
                TakeDamage(Enemy.enemyDmg);
            }
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            currentCoins++;
        }
    }

    void TakeDamage(int damage)
    {
        currentHp -= damage;
        healthBar.SetHealth(currentHp);
    }

    private void OnEnable()
    {
        ExpManager.Instance.ExpChange += HandleExpChange;
    }

    private void OnDisable()
    {
        ExpManager.Instance.ExpChange -= HandleExpChange;
    }


    public void HandleExpChange(int newExp)
    {
        currentExp += newExp;

        expBar.SetExp(currentExp);
        expBar.MaxExp(maxExp);

        if (currentExp >= maxExp)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        maxHp += 10;
        Enemy.enemyDmg += 2;
        currentHp = maxHp;

        currentLevel++;

        currentExp = 0;
        maxExp += 100;

        levelCounter.LevelCount(currentLevel);
        healthBar.SetMaxHealth(maxHp);
    }

    public void GainExp()
    {
        if (exp >= currentExp)
        {
            currentExp = exp;

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
