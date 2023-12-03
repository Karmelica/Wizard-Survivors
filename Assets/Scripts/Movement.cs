using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
	private float moveX;
	private float moveY;

	public GameObject trailRenderer;
	private Rigidbody2D rbody;
	public Collider2D collider2d;
	public Animator animator;

	[Header("Ruch")]
	public float setPlayerSpeed = 5f;
	public float setDashCooldown = 5f;
	public static float playerSpeed;
	static public float dashCooldown;
	static public float uiDashCooldown;
	static public bool isDashing = false;

	void Flip()
	{
		if (Input.GetAxis("Horizontal") < 0)
		{
			transform.rotation = Quaternion.Euler(0, 180, 0);
			trailRenderer.transform.position = transform.position + new Vector3(0, 0, 1f);
		}
		if (Input.GetAxis("Horizontal") > 0)
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
			trailRenderer.transform.position = transform.position + new Vector3(0, 0, 1f);
		}
	}
	IEnumerator DashHandler()
	{
		dashCooldown = setDashCooldown;
		collider2d.isTrigger = true;
		isDashing = true;
		animator.Play("Dash");
		trailRenderer.GetComponent<TrailRenderer>().emitting = true;

		rbody.AddForce(playerSpeed * new Vector2(moveX, moveY).normalized, ForceMode2D.Impulse);

		yield return new WaitForSeconds(1);
        collider2d.isTrigger = false;
        isDashing = false;
        trailRenderer.GetComponent<TrailRenderer>().emitting = false;
	}
	void MyInput()
	{
		moveX = Input.GetAxis("Horizontal");
		moveY = Input.GetAxis("Vertical");
	}

	// Start is called before the first frame update
	void Start()
	{
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
	}

	void Update()
	{
		Flip();

		dashCooldown -= Time.deltaTime;
		if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown <= 0)
		{
			StartCoroutine(DashHandler());
		}
	}
}
