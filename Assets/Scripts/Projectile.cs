using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]

    public GameObject player;
    public EnemySpawner spawner;
    public Rigidbody2D body;

    [SerializeField]
    
    private Vector3 mousePos;
    private float mousePosX;
    private float mousePosY;
    private float time = 3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
        spawner.spawned--;

    }
    void MousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosX = mousePos.x - player.transform.position.x;
        mousePosY = mousePos.y - player.transform.position.y;

    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawner = EnemySpawner.FindObjectOfType<EnemySpawner>();
        MousePos();
        body = GetComponent<Rigidbody2D>();
        body.AddForce(2f * (new Vector2(mousePosX, mousePosY)).normalized, ForceMode2D.Impulse);
    }


    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }
}
