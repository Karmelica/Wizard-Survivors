using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [Header("Stats")]
    static public int maxHp = 20;
    static public int currentHp;
    public static int exp = 0;
    public int maxExp = 100;
    public int currentExp;
    public int currentLevel = 1;
    public int currentCoins;
    public int playerDmg = 1;
    private float overHeal;
    private float vel = 1f;

    [Header("Components")]
    public TextMeshProUGUI textMeshHP;
    public HealthBar healthBar;
    public ExpBar expBar;
    public LevelCounter levelCounter;
    public CoinCounter coinCounter;
    public Image overHealBar;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            currentCoins++;
            coinCounter.CoinCount(currentLevel);
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            currentCoins++;
            coinCounter.CoinCount(currentCoins);
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
        Slash.heal++;
        Enemy.enemyDmg++;
        currentHp = maxHp;

        currentLevel++;

        currentExp = 0;
        maxExp += 100;

        levelCounter.LevelCount(currentLevel);
        healthBar.SetMaxHealth(maxHp);
        expBar.SetStartExp(currentExp);
    }

    public void GainExp()
    {
        if (exp >= currentExp)
        {
            currentExp = exp;
        }
    }
    private void OverHeal()
    {
        if (currentHp > maxHp * 2)
        {
            currentHp = maxHp * 2;
        }

        if (currentHp > maxHp)
        {
            overHeal = currentHp - maxHp;
            float fillAmount = Mathf.SmoothDamp(overHealBar.fillAmount, overHeal / maxHp, ref vel, 200 * Time.deltaTime);
            overHealBar.fillAmount = fillAmount;
        }
        else
        {
            overHeal = 0;
            float fillAmount = Mathf.SmoothDamp(overHealBar.fillAmount, overHeal, ref vel, 200 * Time.deltaTime);
            overHealBar.fillAmount = fillAmount;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        overHeal = 0;
        currentHp = maxHp;
        healthBar.SetMaxHealth(maxHp);
        currentExp = exp;
        expBar.SetStartExp(currentExp);
    }

    // Update is called once per frame
    void Update()
    {
        OverHeal();
        textMeshHP.text = currentHp + "/" + maxHp;
        GainExp();
    }
}
