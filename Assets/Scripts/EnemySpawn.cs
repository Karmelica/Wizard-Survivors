using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    public float spawnRate = 1f;
    private bool canSpawn = true;
    public static int spawned = 0;
    private int spawnMax = 10;
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

            int randomlySelectedPrefabType = Random.Range(0, enemyPrefabs.Length);

            GameObject enemyToSpawn = enemyPrefabs[randomlySelectedPrefabType];

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
