using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	private float attackInterval = 2f;
	private readonly float attackRange = 2.05f;
	public Collider2D colli;
	private Rigidbody2D rb;
	public GameObject player;
	public Stats stats;
	public GameObject pfSnowball;
	public Animator animatorSnowman;

	private void NormalAtttack()
	{
        attackInterval -= Time.deltaTime;
        float distance = (colli.transform.position - player.transform.position).magnitude;
        if (distance <= attackRange && attackInterval < 0 && !Movement.isDashing)
        {
            stats.TakeDamage(EnemyScript.enemyDmg);
            rb.AddForce((player.transform.position - colli.transform.position).normalized * -600, ForceMode2D.Force);
            attackInterval = 2f;
        }
    }

	private void SnowmanAttack()
	{
        attackInterval -= Time.deltaTime;
        float distance = (colli.transform.position - player.transform.position).magnitude;
        if (distance <= 2.4f && attackInterval < 0)
        {
			animatorSnowman.Play("SnowmanThrow");
            GameObject snowball = Instantiate(pfSnowball, transform.position, Quaternion.identity);
            snowball.GetComponent<Snowball>().snowman = transform;
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
        if(this.name != "pfSnowman(Clone)")
		{
			NormalAtttack();
		}
		else
		{
			SnowmanAttack();
		}
    }
}