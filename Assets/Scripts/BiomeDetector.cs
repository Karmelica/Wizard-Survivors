using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeDetector : MonoBehaviour
{
	public EnemySpawn enemySpawn;
    public GameObject iceField;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Air"))
        {
            Movement.dashUnlocked = true;
            EnemySpawn.rangeStart = 0;
            EnemySpawn.rangeEnd = 1;
        }
        if (collision.CompareTag("Fire"))
        {
            Attack.slashUnlocked = true;
            EnemySpawn.rangeStart = 2;
            EnemySpawn.rangeEnd = 2;
        }
        if (collision.CompareTag("Ice"))
        {
            Attack.IceUnlocked = true;
            iceField.SetActive(true);
            EnemySpawn.rangeStart = 5;
            EnemySpawn.rangeEnd = 5;
        }
        if (collision.CompareTag("Green"))
        {
            EnemySpawn.rangeStart = 3;
            EnemySpawn.rangeEnd = 4;
        }
    }
}
