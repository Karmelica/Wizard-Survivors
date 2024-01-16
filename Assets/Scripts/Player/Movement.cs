using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float moveX;
    private float moveY;

    private Stats stats;
    public AudioSource audioSourceLoop;
    public TrailRenderer trail;
    private Rigidbody2D rbody;
    public Collider2D collider2d;
    public Animator animator;
    static public bool dashUnlocked;

    [Header("Ruch")]
    private bool stopped;
    private float dashReducer = 1f; //controls dash power (0 - 1)
    public float setPlayerSpeed = 5f;
    public float setDashCooldown = 5f;
    public static float playerSpeed;
    static public float dashCooldown;
    static public float uiDashCooldown;
    static public bool isDashing = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("IceLake"))
        {
            dashReducer = 0.3f;
            rbody.drag = 1; //friction
        }

        if (collision.gameObject.CompareTag("LavaLake"))
        {
            dashReducer = 0.6f;
            rbody.drag = 10;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("IceLake"))
        {
            dashReducer = 1f;
            rbody.drag = 6;
        }

        if (collision.gameObject.CompareTag("LavaLake"))
        {
            dashReducer = 1f;
            rbody.drag = 6;
        }
    }

    public void IsInBorder()
    {
        rbody.velocity = Vector2.zero;
    }

    void Flip()
    {
        if (moveX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            trail.transform.position = transform.position + new Vector3(0, 0, 1f);
        }
        if (moveX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            trail.transform.position = transform.position + new Vector3(0, 0, 1f);
        }
    }
    IEnumerator DashHandler()
    {
        dashCooldown = setDashCooldown;
        isDashing = true;
        collider2d.isTrigger = true;
        animator.Play("Dash");
        trail.emitting = true;

        rbody.AddForce(playerSpeed * dashReducer * rbody.velocity.normalized, ForceMode2D.Impulse);

        yield return new WaitForSeconds(1.5f);
        collider2d.isTrigger = false;
        isDashing = false;
        trail.emitting = false;
    }
    void MyInput()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSourceLoop.enabled = true;
        dashUnlocked = false;
        playerSpeed = setPlayerSpeed;
        uiDashCooldown = setDashCooldown;
        stats = GetComponent<Stats>();
        rbody = GetComponent<Rigidbody2D>();
        rbody.freezeRotation = true;
        dashCooldown = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MyInput();
        rbody.AddForce(0.5f * playerSpeed * new Vector2(moveX, moveY).normalized, ForceMode2D.Force);
        if (rbody.velocity.magnitude * 10 > 1f && !isDashing && !AnimationEvents.attackAnim)
        {
            animator.Play("walk_anim");
        }
    }

    void Update()
    {
        /*if (AnimationEvents.hasStopped)
        {
            audioSourceLoop.enabled = false;
            stats.PlaySoundLoop(BiomeDetector.currentWalkClip, 1);
        }
        else
        {
            audioSourceLoop.enabled = true;
        }*/

        Flip();

        dashCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown <= 0 && dashUnlocked)
        {
            StartCoroutine(DashHandler());
        }
    }
}
