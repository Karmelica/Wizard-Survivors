using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Properties")]
    public GameObject player;
    public Rigidbody2D rbody2D;

    static public int enemyDmg = 5;
    static public int enemyExp = 100;

    [Header("Ruch")]
    public float speed = 4;
    private float enemyMoveX;
    private float enemyMoveY;

    [SerializeField]
    public float despawnTime = 60f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 deadPreFabCoords = collision.gameObject.transform.position;
            Destroy(gameObject);
            EnemySpawn.spawned--;
            ExpManager.Instance.AddExp(enemyExp);
            FindAnyObjectByType<CoinDrop>().Drop(deadPreFabCoords);
        }
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyMove();
    }

    void Update()
    {
        despawnTime -= Time.deltaTime;
        if (despawnTime < 0)
        {
            Destroy(gameObject);
            EnemySpawn.spawned--;
        }
    }
}
