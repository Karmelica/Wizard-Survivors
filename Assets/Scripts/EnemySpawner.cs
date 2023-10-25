using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    private float spawnRate = 1f;
    private bool canSpawn = true;
    public int spawned = 0;
    private int spawnMax = 5;
    private bool oneTime = false;
    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;

            int rand = Random.Range(0, enemyPrefabs.Length);

            GameObject enemyToSpawn = enemyPrefabs[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);

            spawned++;
        }
    }

    private void Update()
    {
        if (spawned >= spawnMax)
        {
            canSpawn = false;
            oneTime = true;
        }
        else if (oneTime == true)
        {
            canSpawn = true;
            StartCoroutine(Spawner());
            oneTime = false;
        }
    }
}
