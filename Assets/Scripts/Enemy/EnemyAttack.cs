using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	private float attackInterval = 2f;
	private readonly float attackRange = 0.4f;
	public Collider2D colli;
	private Rigidbody2D rb;
	public GameObject player;
	public Stats stats;
	public GameObject pfSnowball;
	public Transform snowballLocation;
	public Animator animatorSnowman;

	private void NormalAtttack()
	{
        attackInterval -= Time.deltaTime;
		float distX = colli.transform.position.x - player.transform.position.x;
		float distY = colli.transform.position.y - player.transform.position.y;
        float distance = new Vector2(distX, distY).magnitude;
		//Debug.Log(distance);
        if (distance <= attackRange && attackInterval < 0 && !Movement.isDashing)
        {
            stats.TakeDamage(EnemyScript.enemyDmg);
            rb.AddForce(new Vector2(distX,distY).normalized * 200, ForceMode2D.Force);
            attackInterval = 2f;
        }
    }

	private void SnowmanAttack()
	{
        attackInterval -= Time.deltaTime;

        float distX = colli.transform.position.x - player.transform.position.x;
        float distY = colli.transform.position.y - player.transform.position.y;
        float distance = new Vector2(distX, distY).magnitude;

        if (distance <= 1.1f && attackInterval < 0)
        {
			if(name == "pfSnowman(Clone)")
            {
                animatorSnowman.Play("SnowmanThrow");
            }
            Instantiate(pfSnowball, snowballLocation.transform.position, Quaternion.identity);
            attackInterval = 3f;
        }
	}

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		player = GameObject.Find("Player");
		stats = player.GetComponent<Stats>();
	}

	// Update is called once per frame
	void Update()
	{
        if(name == "pfSnowman(Clone)" || name == "pfFireEnemy(Clone)")
        {
            SnowmanAttack();
        }
		else
        {
            NormalAtttack();
		}
    }
}
