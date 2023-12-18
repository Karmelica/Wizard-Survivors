using System.Collections;
using UnityEditor;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	[Header("Properties")]
	public GameObject player;
	public Collider2D colli;
	public Rigidbody2D rbody2D;
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

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			TakeDamage(2);
		}
		if (other.CompareTag("Weapon"))
		{
			TakeDamage(other.GetComponent<Damage>().attackDamage);
			if (other.gameObject.name == "pfProjectile(Clone)")
			{
				Destroy(other.gameObject);
			}
		}
	}

	public void TakeDamage(int damageTaken)
	{
		enemyCurrentHp -= damageTaken;
	}
	void EnemyDied()
	{
		Vector3 deadPreFabCoords = colli.transform.position;
		Destroy(gameObject);
		//EnemySpawn.spawned--;
		ExpManager.Instance.AddExp(enemyExp);
		FindAnyObjectByType<CoinDrop>().Drop(deadPreFabCoords);
	}

	void EnemyMove()
	{
		enemyPosX = colli.transform.position.x;
		enemyPosY = colli.transform.position.y;
		rbody2D.AddForce(0.5f * -speed * new Vector2(enemyPosX - player.transform.position.x, enemyPosY - player.transform.position.y).normalized, ForceMode2D.Force);
	}

	IEnumerator SlimeMove()
    {
		while (true)
		{
			yield return new WaitForSeconds(7/speed - 0.5f);
			enemyPosX = colli.transform.position.x;
			enemyPosY = colli.transform.position.y;
			slimeAnimator.Play("Slime");
            yield return new WaitForSeconds(0.5f);
            rbody2D.AddForce(-4 * new Vector2(enemyPosX - player.transform.position.x, enemyPosY - player.transform.position.y).normalized, ForceMode2D.Impulse);
		}
    }


	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
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
		if (enemyCurrentHp <= 0)
		{
			EnemyDied();
		}

		despawnTime -= Time.deltaTime;

		if (despawnTime < 20f)
		{
			speed = 14;
		}
        if (despawnTime < 0)
        {
            Destroy(gameObject);
            //EnemySpawn.spawned--;
        }

    }
}
