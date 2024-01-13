using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class LavaDmg : MonoBehaviour
{
    private float attackInterval = 1f;

    [Header("Lava Damage")]
    public static int lavaDmg = 1;
   
    [HideInInspector]public Stats stats;
    [HideInInspector]public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        stats = player.GetComponent<Stats>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            LavaAttack();
        }
    }

    private void LavaAttack()
    {
        attackInterval -= Time.deltaTime;

        if (attackInterval < 0 && !Movement.isDashing )
        {
            stats.TakeDamage(lavaDmg);
            attackInterval = 1f;
        }
    }
}
