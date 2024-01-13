using System.Collections;
using System.Text;
using UnityEngine;

public class Movement : MonoBehaviour
{
	private float moveX;
	private float moveY;

	public TrailRenderer trail;
	private Rigidbody2D rbody;
	public Collider2D collider2d;
	public Animator animator;
	static public bool dashUnlocked;

	[Header("Ruch")]
	private float slippery = 1f;
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
			slippery = 0.3f;
			rbody.drag = 1;
		}

		if (collision.gameObject.CompareTag("LavaLake"))
		{
			slippery = 2f;
			rbody.drag = 10;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("IceLake"))
		{
			slippery = 1f;
			rbody.drag = 6;
		}

		if (collision.gameObject.CompareTag("LavaLake"))
		{
			slippery = 1f;
			rbody.drag = 6;
		}
	}

    public void IsInBorder()
	{
		rbody.velocity = Vector3.zero;
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

		rbody.AddForce(playerSpeed * slippery * rbody.velocity.normalized, ForceMode2D.Impulse);

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
		dashUnlocked = false;
		playerSpeed = setPlayerSpeed;
		uiDashCooldown = setDashCooldown;
		rbody = GetComponent<Rigidbody2D>();
		rbody.freezeRotation = true;
		dashCooldown = 0f;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		MyInput();
		rbody.AddForce(0.5f * playerSpeed * new Vector2(moveX, moveY).normalized, ForceMode2D.Force);
		if (rbody.velocity.magnitude * 10 > 1f && !isDashing)
		{
			animator.Play("walk_anim");
		}
	}

	void Update()
	{
		Flip();

		dashCooldown -= Time.deltaTime;
		if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown <= 0 && dashUnlocked)
		{
			StartCoroutine(DashHandler());
		}
	}
}
