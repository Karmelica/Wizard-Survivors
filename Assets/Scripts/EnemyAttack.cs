using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	private float attackInterval = 2f;
	public GameObject player;
	public Stats stats;
	public LayerMask playerMask;

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.Find("Player");
		stats = player.GetComponent<Stats>();
	}

	// Update is called once per frame
	void Update()
	{
        attackInterval -= Time.deltaTime;
        Vector2 direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.3f, playerMask);
        Debug.DrawRay(transform.position, direction);
        if (hit && attackInterval < 0 && !Movement.isDashing)
        {
            stats.TakeDamage(EnemyScript.enemyDmg);
            attackInterval = 2f;
        }
    }
}
