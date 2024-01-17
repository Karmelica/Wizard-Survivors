using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform projectileSpawn;
    public GameObject player;
    public Rigidbody2D body;

    private Vector3 mousePos;
    private float mousePosX;
    private float mousePosY;
    private float time = 3f;

    void MousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosX = mousePos.x - projectileSpawn.position.x;
        mousePosY = mousePos.y - projectileSpawn.position.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        projectileSpawn = GameObject.Find("ProjectileSpawn").transform;
        MousePos();
        body = GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.LookRotation(transform.position - mousePos);
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
