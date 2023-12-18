using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{

	[Header("Stats")]
	public int maxHp = 20;
	static public int currentHp;
	public static int exp = 0;
	public int maxExp = 100;
	public int currentExp;
	static public int currentLevel = 1;
	public int currentCoins;
	public int playerDmg = 1;
	//private float overHeal;
	//private float vel = 1f;

	[Header("Components")]
	public ShopUIManager shopUIManager;
	public TextMeshProUGUI textMeshHP;
	public HealthBar healthBar;
	public ExpBar expBar;
	public LevelCounter levelCounter;
	public CoinCounter coinCounter;
	public Image overHealBar;
	public GameObject MagnetCollider;
	public MagnetText magnetText;

    /* nie wiem skad sie to wzielo wiec narazie zostawie
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Coin"))
		{
			Destroy(other.gameObject);
			currentCoins++;
			coinCounter.CoinCount(currentLevel);
		}
	}
	*/
	/*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            currentCoins++;
            coinCounter.CoinCount(currentCoins);
        }
    }
	*/
    public void TakeDamage(int damage)
	{
		currentHp -= damage;
        textMeshHP.text = currentHp + "/" + maxHp;
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
		//Slash.heal++;
		EnemyScript.enemyDmg++;

		currentLevel++;

        maxExp += 100;
        currentExp = 0;
		levelCounter.LevelCount(currentLevel);
		expBar.SetStartExp(currentExp);

        maxHp += 10;
        currentHp = maxHp;
        healthBar.SetMaxHealth(maxHp);
        healthBar.SetHealth(currentHp);
        textMeshHP.text = currentHp + "/" + maxHp;

        if (currentLevel % 3 == 0)
		{
			shopUIManager.UnlockShop();
			if (EnemySpawn.spawnRate > 1f)
			{
				EnemySpawn.spawnRate -= 1f;
			}
			else if (EnemySpawn.spawnRate > 0.5f)
			{
				EnemySpawn.spawnRate -= 0.1f;
			}
		}

		if (currentLevel == 5)
		{
			MagnetCollider.SetActive(true);
			StartCoroutine(magnetText.Text());
		}

		if(currentLevel == 30)
		{
			EnemySpawn.spawnRate = 0.5f; //po 30lvl wrogowie spawni¹ siê szybko
		}
	}

	public void GainExp()
	{
		if (exp >= currentExp)
		{
			currentExp = exp;
		}
	}

	/* leczenie atakiem i tak na razie jest wy³¹czone
	 * private void OverHeal()
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
	}*/

	// Start is called before the first frame update
	void Start()
	{
		//overHeal = 0;
		currentHp = maxHp;
		healthBar.SetMaxHealth(maxHp);

		currentExp = exp;
		expBar.SetStartExp(currentExp);
	}
}
