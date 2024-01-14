using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeDetector : MonoBehaviour
{
    [SerializeField] private Stats stats;
	public EnemySpawn enemySpawn;
    public GameObject iceField;
    public AudioClip iceWalk;
    public AudioClip greenWalk;
    public AudioClip rockWalk;
    public AudioClip bridgeWalk;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Air"))
        {
            stats.PlaySoundLoop(rockWalk, 1);
            Movement.dashUnlocked = true;
            EnemySpawn.rangeStart = 0;
            EnemySpawn.rangeEnd = 1;
        }
        if (collision.CompareTag("Fire"))
        {
            stats.PlaySoundLoop(rockWalk, 1);
            Attack.slashUnlocked = true;
            EnemySpawn.rangeStart = 2;
            EnemySpawn.rangeEnd = 2;
        }
        if (collision.CompareTag("Ice"))
        {
            stats.PlaySoundLoop(iceWalk, 1);
            Attack.IceUnlocked = true;
            iceField.SetActive(true);
            EnemySpawn.rangeStart = 5;
            EnemySpawn.rangeEnd = 6;
        }
        if (collision.CompareTag("Green"))
        {
            stats.PlaySoundLoop(greenWalk, 1);
            Attack.earthUnlocked = true;
            EnemySpawn.rangeStart = 3;
            EnemySpawn.rangeEnd = 4;
        }
        if (collision.CompareTag("Bridge"))
        {
            stats.PlaySoundLoop(bridgeWalk, 1);
        }
    }
}
