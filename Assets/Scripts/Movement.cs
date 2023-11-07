using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [Header("Ruch")]
    public Rigidbody2D rbody;
    public float speed = 5;
    private float moveX;
    private float moveY;
    private float dashCooldown = 5f;
    public bool isDashing = false;

    void OnCollisionEnter2D(Collision2D collison)
    {
        if (isDashing && dashCooldown >= 4f)
        {
            Destroy(collison.gameObject);
        }
    }
    void Dash()
    {
        isDashing = true;
        rbody.AddForce(speed * new Vector2(moveX, moveY).normalized, ForceMode2D.Impulse);
    }
    void MyInput()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
    }

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MyInput();
        rbody.AddForce(0.5f * speed * new Vector2(moveX, moveY).normalized, ForceMode2D.Force);
    }

    void Update()
    {
        dashCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown <= 0)
        {
            dashCooldown = 5f;
            Dash();
        }
    }
}
