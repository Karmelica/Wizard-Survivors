using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]

    public EnemySpawner spawner;
    public Rigidbody2D body;
    public Vector3 mousePos;
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

    }
    // Start is called before the first frame update
    void Start()
    {
        spawner = EnemySpawner.FindObjectOfType<EnemySpawner>();
        MousePos();
        body = GetComponent<Rigidbody2D>();
        body.AddForce(50f * mousePos.normalized, ForceMode2D.Impulse);
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
