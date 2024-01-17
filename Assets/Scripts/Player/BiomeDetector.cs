using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeDetector : MonoBehaviour
{
    [SerializeField] private Stats stats;
	public EnemySpawn enemySpawn;
    public GameObject iceField;
    public AudioClip[] walking;
    static public AudioClip currentWalkClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Air"))
        {
            currentWalkClip = walking[2];
            if(Movement.dashUnlocked != true)
            {
                Movement.dashUnlocked = true;
            }

            EnemySpawn.rangeStart = 0;
            EnemySpawn.rangeEnd = 1;
        }
        if (collision.CompareTag("Fire"))
        {
            currentWalkClip = walking[2];
            if(Attack.slashUnlocked != true)
            {
                Attack.slashUnlocked = true;
            }

            EnemySpawn.rangeStart = 2;
            EnemySpawn.rangeEnd = 3;
        }
        if (collision.CompareTag("Green"))
        {
            currentWalkClip = walking[1];

            if (Attack.earthUnlocked != true)
            {
                Attack.earthUnlocked = true; 
            } 

            EnemySpawn.rangeStart = 4;
            EnemySpawn.rangeEnd = 5;
        }
        if (collision.CompareTag("Ice"))
        {
            currentWalkClip = walking[0];

            if (Attack.IceUnlocked != true)
            {
                Attack.IceUnlocked = true;
                iceField.SetActive(true);
            }
            EnemySpawn.rangeStart = 6;
            EnemySpawn.rangeEnd = 7;
        }
        
        if (collision.CompareTag("Bridge"))
        {
            currentWalkClip = walking[3];
        }
    }
}
