using System.Collections;
using TMPro;
using Unity.VisualScripting;
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

	public int projectileDmg = 1;
	public int slashDmg = 2;
	public int dashDmg = 2;
	public int earthDmg = 1;

	static public string biome;
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
	public AudioClip lvlUp;
	public AudioClip magnetUnlocked;
	public AudioClip takeDamage;
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioSource audioSourceLoop;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "pfSnowball(Clone)")
        {
            TakeDamage(EnemyScript.enemyDmg);
            Destroy(collision.gameObject);
        }
    }

	IEnumerator AudioLoop(AudioClip sound, float volume)
	{
		while (true)
		{
			float lenght = sound.length;
			audioSourceLoop.PlayOneShot(sound, volume);
			yield return new WaitForSeconds(lenght - 0.1f);
		}
	}

	public void PlaySoundOneShot(AudioClip sound, float volume)
	{
        audioSource.PlayOneShot(sound, volume);
    }

	public void PlaySoundLoop(AudioClip sound, float volume)
    {
        StopAllCoroutines();
        audioSourceLoop.Stop();
		StartCoroutine(AudioLoop(sound, volume));
	}

    public void UpdateHealthBar()
    {
        healthBar.SetMaxHealth(maxHp);
        healthBar.SetHealth(currentHp);
        textMeshHP.text = currentHp + "/" + maxHp;
    }

    public void TakeDamage(int damage)
	{
		PlaySoundOneShot(takeDamage, 1);
		currentHp -= damage;
		UpdateHealthBar();
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
		PlaySoundOneShot(lvlUp, 1);

		//Slash.heal++;
		EnemyScript.enemyDmg++;

		currentLevel++;

        maxExp += 100;
        currentExp = 0;
		levelCounter.LevelCount(currentLevel);
		expBar.SetStartExp(currentExp);

        maxHp += 10;
        currentHp = maxHp;
		UpdateHealthBar();

        if (currentLevel % 3 == 0)
		{
			shopUIManager.UnlockShop();
            PlaySoundOneShot(magnetUnlocked, 1);

            if (EnemySpawn.spawnRate > 1f)
			{
				EnemySpawn.spawnRate -= 1f;
			}
			else if (EnemySpawn.spawnRate > 0.5f) //wrogowie spawnia sie czybko ale skala jest liniowa
			{
				EnemySpawn.spawnRate -= 0.1f;
			}
		}

		if (currentLevel == 5)
        {
            MagnetCollider.SetActive(true);
			StartCoroutine(magnetText.Text());
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

		currentExp = 1;

		currentLevel = 1;
	} //usunąłem cały update i wrzuciłem funkcje do kodu tam gdzie są wywoływane np. udpate healthbar
}
