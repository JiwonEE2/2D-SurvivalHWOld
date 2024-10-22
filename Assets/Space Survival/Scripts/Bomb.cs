using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Contact();
			Destroy(gameObject);
		}
	}

	public void Contact()
	{
		// ���� �Ŵ������� ��� ������ ���ִ޶�� ��Ź����
		// enemies�� �ִ� ��� enemy�� die
		for (int i = GameManager.Instance.enemies.Count - 1; i >= 0; i--)
		{
			GameManager.Instance.enemies[i].TakeDamage(1000000);
		}
	}
}
