using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]

    public GameObject[] enemyPrefabs;

    [SerializeField]

    private float spawnRate = 1f;
    private bool canSpawn = true;
    public int spawned = 0;
    private int spawnMax = 5;

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
        }
        else
        {
            canSpawn = true;
        }
    }




}
