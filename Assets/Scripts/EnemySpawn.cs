using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	public Transform holder;
	public GameObject[] enemyPrefabs;

    static public int rangeStart;
    static public int rangeEnd;

	static public float spawnRate;
	public float setSpawnRate = 6f;

	private IEnumerator Spawner()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnRate);

			int randomlySelectedPrefabType = Random.Range(rangeStart, rangeEnd + 1);

			//Debug.Log(rangeStart + ", " + rangeEnd + ", " + randomlySelectedPrefabType);

			GameObject enemyToSpawn = enemyPrefabs[randomlySelectedPrefabType];

			Vector3 randomPos = Random.insideUnitCircle.normalized * 2.5f;

			Instantiate(enemyToSpawn, holder.transform.position + randomPos, Quaternion.identity);
		}
	}

	private void Start()
	{
		spawnRate = setSpawnRate;
		StartCoroutine(Spawner());
        StartCoroutine(Spawner());
        StartCoroutine(Spawner());
    }
}
