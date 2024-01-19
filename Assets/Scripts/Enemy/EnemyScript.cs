using System.Collections;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	[SerializeField] private CooldownUI cooldownUI;

	[Header("Properties")]
	[SerializeField] private GameObject player;
    [SerializeField] private Collider2D colli;
	[SerializeField] private SpriteRenderer spriteRenderer;
    private Rigidbody2D rbody2D;
	private Stats stats;

    [SerializeField] private float despawnTime = 30f;
	[SerializeField] private Animator slimeAnimator;
	[SerializeField] private EnemyHealthBar healthBar;

	[Header("Stats")]
	static public int enemyDmg = 5;
	static public int enemyExp = 100;
	public int enemyMaxHp = 2;
	public int enemyCurrentHp;

	[Header("Ruch")]
	public float speed = 4;
	private float distanceX;
	private float distanceY;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name == "IceField")
		{
			if(Attack.IceUnlocked)
			{
				speed /= 3;
			}
		}

		if (other.gameObject.CompareTag("Player"))
		{
			TakeDamage(stats.dashDmg);
		}

		if (other.CompareTag("Weapon"))
		{
			int damage = other.GetComponentInParent<Damage>().attackDamage;

            TakeDamage(damage);

			if (other.gameObject.name == "pfProjectile(Clone)")
			{
				Destroy(other.gameObject);
			}

			if(other.gameObject.name == "pfEarthAttack(Clone)")
			{
                rbody2D.AddForce(new Vector2(distanceX, distanceY).normalized * 200, ForceMode2D.Force);
            }
		}
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "IceField")
        {
            if (Attack.IceUnlocked)
            {
                speed *= 3;
            }
        }
    }

    public void IsInBorder()
	{
		colli.isTrigger = true;
		Color alpha = spriteRenderer.color;
		alpha.a -= 0.5f;
		spriteRenderer.color = alpha;
		speed /= 2;
	}

	public void BorderExit()
    {
        colli.isTrigger = false;
        Color alpha = spriteRenderer.color;
        alpha.a += 0.5f;
        spriteRenderer.color = alpha;
		speed *= 2;
    }

    public void TakeDamage(int damageTaken)
	{
		enemyCurrentHp -= damageTaken;
		healthBar.UpdateText();
		if (enemyCurrentHp <= 0)
        {
            EnemyDied();
        }
    }
	void EnemyDied()
	{
		CooldownUI.enemiesKilled++;
		if (CooldownUI.enemiesKilled == 100)
        {
            cooldownUI.Josh();
        }
        Vector3 deadPreFabCoords = colli.transform.position;
		Destroy(gameObject);
		ExpManager.Instance.AddExp(enemyExp);
		stats.GainExp();
		FindAnyObjectByType<CoinDrop>().Drop(deadPreFabCoords);
	}

	void EnemyMove()
	{
		distanceX = colli.transform.position.x - player.transform.position.x;
		distanceY = colli.transform.position.y - player.transform.position.y;
		
		Vector2 distance = new(distanceX, distanceY);

        rbody2D.AddForce(0.5f * -speed * distance.normalized, ForceMode2D.Force);
	}
    void EnemyMoveSnowman()
    {
        distanceX = colli.transform.position.x - player.transform.position.x;
        distanceY = colli.transform.position.y - player.transform.position.y;

		Vector2 distance = new(distanceX, distanceY);

		if (distance.magnitude > 1.1f){
			rbody2D.AddForce(0.5f * -speed * distance.normalized, ForceMode2D.Force);

		}
		else if (distance.magnitude < 1f)
		{
            rbody2D.AddForce(0.25f * speed * distance.normalized, ForceMode2D.Force);
        }
    }

    IEnumerator SlimeMove()
    {
		while (true)
		{
			yield return new WaitForSeconds(7/speed - 0.3f);
			slimeAnimator.Play("Slime");
            yield return new WaitForSeconds(0.5f);

            distanceX = colli.transform.position.x - player.transform.position.x;
            distanceY = colli.transform.position.y - player.transform.position.y;

            Vector2 distance = new(distanceX, distanceY);

            rbody2D.AddForce(-4 * distance.normalized, ForceMode2D.Impulse);
		}
    }

	// Start is called before the first frame update
	void Start()
	{
		cooldownUI = GameObject.Find("Canvas").GetComponent<CooldownUI>();
        healthBar.UpdateText();
        player = GameObject.Find("Player");
		stats = player.GetComponent<Stats>();
		rbody2D = GetComponent<Rigidbody2D>();
		rbody2D.freezeRotation = true;
		enemyCurrentHp = enemyMaxHp;

        if (gameObject.name == "pfSlimeFire(Clone)" || gameObject.name == "pfSlimeGreen(Clone)" || gameObject.name == "pfSlimeIce(Clone)")
        {
            StartCoroutine(SlimeMove());
        }
    }

	// Update is called once per frame
	void FixedUpdate()
	{
		if (gameObject.name != "pfSlimeFire(Clone)" && gameObject.name != "pfSlimeGreen(Clone)" && gameObject.name != "pfSlimeIce(Clone)" && gameObject.name != "pfFireEnemy(Clone)" && gameObject.name != "pfSnowman(Clone)")
		{
			EnemyMove();
        }
		if (gameObject.name == "pfSnowman(Clone)" || gameObject.name == "pfFireEnemy(Clone)")
		{
			EnemyMoveSnowman();
		}
	}

	void Update()
	{
		despawnTime -= Time.deltaTime;

		if (despawnTime < 20f)
		{
			speed = 14;
		}
        if (despawnTime < 0)
        {
            Destroy(gameObject);
        }

    }
}
