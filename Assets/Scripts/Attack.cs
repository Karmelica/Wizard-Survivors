using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
	public Transform pfSlash;
	public Transform pfFireball;
	public Animator animator;
	public GameObject player;

	static public bool attackUpgraded = false;
	static public bool projectileUpgraded = false;

	public float setAttackCooldown = 3f;
	public float setFireballCooldown = 1f;
	static public float uiAttackCooldown;
	static public float uiFireballCooldown;
	static public float attackCooldown;
	static public float fireballCooldown;

	IEnumerator Fireball()
	{
		if (Input.GetMouseButtonDown(1) && fireballCooldown <= 0f && Time.timeScale != 0)
		{
			if (projectileUpgraded)
			{
				animator.Play("Attack");
				fireballCooldown = setFireballCooldown;
				Instantiate(pfFireball, player.transform.position, Quaternion.identity);
				yield return new WaitForSeconds(0.2f);
				Instantiate(pfFireball, player.transform.position, Quaternion.identity);
				yield return new WaitForSeconds(0.2f);
				Instantiate(pfFireball, player.transform.position, Quaternion.identity);
				yield return new WaitForSeconds(0.2f);
			}
			else
			{
				animator.Play("Attack");
				fireballCooldown = setFireballCooldown;
				Instantiate(pfFireball, player.transform.position, Quaternion.identity);

			}
		}
	}

	void Slash()
	{
		if (Input.GetMouseButton(0) && attackCooldown <= 0f && Time.timeScale != 0)
		{
			if (attackUpgraded)
			{
				animator.Play("Attack");
				attackCooldown = setAttackCooldown;
				if (transform.rotation.y == 0)
				{
					Instantiate(pfSlash, transform.position + new Vector3(0.5f, 0, 0), transform.rotation);
					Instantiate(pfSlash, transform.position + new Vector3(0.5f, 0, 0) * -1, transform.rotation * Quaternion.Euler(180, 180, 0));
				}
				else
				{
					Instantiate(pfSlash, transform.position + new Vector3(0.5f, 0, 0) * -1, transform.rotation);
					Instantiate(pfSlash, transform.position + new Vector3(0.5f, 0, 0), transform.rotation * Quaternion.Euler(180, 180, 0));
				}
			}
			else
			{
				animator.Play("Attack");
				attackCooldown = setAttackCooldown;
				if (transform.rotation.y == 0)
				{
					Instantiate(pfSlash, transform.position + new Vector3(0.5f, 0, 0), transform.rotation);
				}
				else
				{
					Instantiate(pfSlash, transform.position + new Vector3(0.5f, 0, 0) * -1, transform.rotation);
				}
			}

		}
	}

	// Start is called before the first frame update
	void Start()
	{

		attackUpgraded = false;
		projectileUpgraded = false;

		uiAttackCooldown = setAttackCooldown;
		attackCooldown = 0f;

		uiFireballCooldown = setFireballCooldown;
		fireballCooldown = 0f;

		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
	{
		attackCooldown -= Time.deltaTime;
		fireballCooldown -= Time.deltaTime;

		StartCoroutine(Fireball());
		Slash();
	}
}
