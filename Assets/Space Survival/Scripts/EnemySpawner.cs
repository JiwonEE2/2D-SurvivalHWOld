using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;      // �� ������
	public float spawnInterval;         // ���� ����

	private void Start()
	{
		StartCoroutine(SpawnCoroutine());
	}

	private IEnumerator SpawnCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnInterval);
			Spawn();		// ���� ����
		}
	}

	private void Spawn()
	{
		Instantiate(enemyPrefab);
	}
}
