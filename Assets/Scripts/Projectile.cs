using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D body;

    private Vector3 mousePos;
    private float mousePosX;
    private float mousePosY;
    private float time = 3f;

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
