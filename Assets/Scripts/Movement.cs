using System.Collections;
using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float moveX;
    private float moveY;

    [SerializeField]
    private TrailRenderer tr;
    private Rigidbody2D rbody;
    public Collider2D collider2d;

    [Header("Ruch")]
    public float speed = 5;
    static public float dashCooldown = 5f;
    public bool isDashing = false;

    //void OnCollisionEnter2D(Collision2D collison)
    //{
    //    if (isDashing)
    //    {
    //        Destroy(collison.gameObject);
    //    }
    //}
    void Dash()
    {
        isDashing = true;
        tr.emitting = true;
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
        tr = GetComponent<TrailRenderer>();
        rbody = GetComponent<Rigidbody2D>();
        rbody.freezeRotation = true;
        dashCooldown = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MyInput();
        rbody.AddForce(0.5f * speed * new Vector2(moveX, moveY).normalized, ForceMode2D.Force);
    }

    IEnumerator DashHandler()
    {
        dashCooldown = 5f;
        Dash();
        yield return new WaitForSeconds(1.5f);
        tr.emitting = false;
        isDashing = false;
    }
    void Update()
    {
        if (isDashing)
        {
            collider2d.isTrigger = true;
        }
        else if (!isDashing)
        {
            collider2d.isTrigger = false;
        }
        

        dashCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown <= 0)
        {
            StartCoroutine(DashHandler());
        }
    }
}
