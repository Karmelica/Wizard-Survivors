using UnityEditor;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	[Header("Properties")]
	public GameObject player;
	public Rigidbody2D rbody2D;
	[SerializeField] private float despawnTime = 30f;

	[Header("Stats")]
	static public int enemyDmg = 5;
	static public int enemyExp = 100;
	public int enemyMaxHp = 2;
	public int enemyCurrentHp = 2;


	[Header("Ruch")]
	public float speed = 4;
	private float enemyMoveX;
	private float enemyMoveY;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			TakeDamage(2);
		}
		if (collision.CompareTag("Weapon"))
		{
			TakeDamage(collision.GetComponent<Damage>().attackDamage);
			if (collision.gameObject.name == "pfProjectile(Clone)")
			{
				Destroy(collision.gameObject);
			}
		}
	}

	public void TakeDamage(int damageTaken)
	{
		enemyCurrentHp -= damageTaken;
	}
	void EnemyDied()
	{
		Vector3 deadPreFabCoords = transform.position;
		Destroy(gameObject);
		//EnemySpawn.spawned--;
		ExpManager.Instance.AddExp(enemyExp);
		FindAnyObjectByType<CoinDrop>().Drop(deadPreFabCoords);
	}

	void EnemyMove()
	{
		enemyMoveX = transform.position.x;
		enemyMoveY = transform.position.y;
		rbody2D.AddForce(0.5f * -speed * new Vector2(enemyMoveX - player.transform.position.x, enemyMoveY - player.transform.position.y).normalized, ForceMode2D.Force);
	}


	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		rbody2D = GetComponent<Rigidbody2D>();
		rbody2D.freezeRotation = true;
		enemyCurrentHp = enemyMaxHp;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		EnemyMove();
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
			speed = 12;
		}
        if (despawnTime < 0)
        {
            Destroy(gameObject);
            //EnemySpawn.spawned--;
        }

    }
}
