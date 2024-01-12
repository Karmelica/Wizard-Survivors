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
        attackInterval -= Time.deltaTime;
		float distance = (colli.transform.position - player.transform.position).magnitude;
		Debug.Log(distance);
        if (distance <= attackRange && attackInterval < 0 && !Movement.isDashing)
        {
            stats.TakeDamage(EnemyScript.enemyDmg);
			rb.AddForce((player.transform.position - colli.transform.position).normalized * -200, ForceMode2D.Force);
            attackInterval = 2f;
        }
    }
}
