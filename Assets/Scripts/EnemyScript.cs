using System.Collections;
using UnityEditor;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	[Header("Properties")]
	[SerializeField] private GameObject player;
    [SerializeField] private Collider2D colli;
    private Rigidbody2D rbody2D;
	private Stats stats;

    [SerializeField] private float despawnTime = 30f;
	[SerializeField] private Animator slimeAnimator;

	[Header("Stats")]
	static public int enemyDmg = 5;
	static public int enemyExp = 100;
	public int enemyMaxHp = 2;
	public int enemyCurrentHp = 2;

	[Header("Ruch")]
	public float speed = 4;
	private float enemyPosX;
	private float enemyPosY;
	private float playerPosX;
	private float playerPosY;

	private void OnTriggerEnter2D(Collider2D other)
	{
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
		}
	}

	public void TakeDamage(int damageTaken)
	{
		enemyCurrentHp -= damageTaken;
		if (enemyCurrentHp <= 0)
        {
            EnemyDied();
        }
    }
	void EnemyDied()
	{
		Vector3 deadPreFabCoords = colli.transform.position;
		Destroy(gameObject);
		ExpManager.Instance.AddExp(enemyExp);
		stats.GainExp();
		FindAnyObjectByType<CoinDrop>().Drop(deadPreFabCoords);
	}

	void EnemyMove()
	{
		enemyPosX = colli.transform.position.x;
		enemyPosY = colli.transform.position.y;
		playerPosX = player.transform.position.x;
		playerPosY = player.transform.position.y;

		rbody2D.AddForce(0.5f * -speed * new Vector2(enemyPosX - playerPosX, enemyPosY - playerPosY).normalized, ForceMode2D.Force);
	}

	IEnumerator SlimeMove()
    {
		while (true)
		{
			yield return new WaitForSeconds(7/speed - 0.5f);
			slimeAnimator.Play("Slime");
            yield return new WaitForSeconds(0.5f);

            enemyPosX = colli.transform.position.x;
            enemyPosY = colli.transform.position.y;
			playerPosX = player.transform.position.x;
            playerPosY = player.transform.position.y;

            rbody2D.AddForce(-4 * new Vector2(enemyPosX - playerPosX, enemyPosY - playerPosY).normalized, ForceMode2D.Impulse);
		}
    }

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.Find("Player");
		stats = player.GetComponent<Stats>();
		rbody2D = GetComponent<Rigidbody2D>();
		rbody2D.freezeRotation = true;
		enemyCurrentHp = enemyMaxHp;

        if (gameObject.name == "pfSlime(Clone)")
        {
            StartCoroutine(SlimeMove());
        }
    }

	// Update is called once per frame
	void FixedUpdate()
	{
		if (gameObject.name != "pfSlime(Clone)")
		{
			EnemyMove();
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
