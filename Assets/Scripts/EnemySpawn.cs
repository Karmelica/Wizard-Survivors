using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	public Transform holder;
	public GameObject[] enemyPrefabs;

	static public float spawnRate;
	static public int spawnMax;
	static public int spawned = 0;
	public float setSpawnRate = 6f;
	public int SetSpawnMax = 10;

	private bool oneTime = false;
	private bool canSpawn = true;

	private IEnumerator Spawner()
	{
		while (canSpawn)
		{
			yield return new WaitForSeconds(spawnRate);

			int randomlySelectedPrefabType = Random.Range(0, enemyPrefabs.Length);

			GameObject enemyToSpawn = enemyPrefabs[randomlySelectedPrefabType];

			Vector3 randomPos = Random.insideUnitCircle.normalized * 4;

			Instantiate(enemyToSpawn, holder.transform.position + randomPos, Quaternion.identity);

			spawned++;
		}
	}

	private void Start()
	{
		spawnRate = setSpawnRate;
		spawnMax = SetSpawnMax;
		StartCoroutine(Spawner());
		StartCoroutine(Spawner());
		StartCoroutine(Spawner());
		StartCoroutine(Spawner());
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
			StartCoroutine(Spawner());
			StartCoroutine(Spawner());
			StartCoroutine(Spawner());
			oneTime = false;
		}
	}
}
