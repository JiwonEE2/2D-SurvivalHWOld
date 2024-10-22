using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	private float maxHp;
	public float hp = 100f; //ü��
	public float damage = 5f; //���ݷ�
	public float moveSpeed = 5f; //�̵��ӵ�

	public Projectile projectilePrefab; //����ü ������

	public float HpAmount { get => hp / maxHp; }    // ���� ü�� ����

	public int killCount = 0;
	public Text killCountText;
	public Image hpBarImage;

	private Transform moveDir;
	private Transform fireDir;

	private void Awake()
	{
		moveDir = transform.Find("MoveDir");
		fireDir = transform.Find("FireDir");
	}

	void Start()
	{
		maxHp = hp;   // �ִ� ü�� ����
		GameManager.Instance.player = this;
	}

	void Update()
	{
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		Vector2 moveDir = new Vector2(x, y);

		// ���콺 ��ġ�� ��� ������ ���ؾ� �� ��
		//Vector2 mousePos = Input.mousePosition;
		//Vector2 mouseScreenPos = Camera.main.ScreenToWorldPoint(mousePos);
		//Vector2 fireDir = mouseScreenPos - (Vector2)transform.position;
		//Vector3 -> Vector2�� ĳ���� �� �� : z���� ����

		// ���� ����� ���� Ž���Ͽ� ��� ������ ���� ��
		Enemy targetEnemy = null;   // ������� ������ ��
		float targetDistance = float.MaxValue;    // ������ �Ÿ�
		foreach (Enemy enemy in GameManager.Instance.enemies)
		{
			float distance = Vector3.Distance(enemy.transform.position, transform.position);
			if (distance < targetDistance)    // ������ ���� ������ ������
			{
				targetDistance = distance;
				targetEnemy = enemy;
			}

		}
		Vector2 fireDir = Vector2.zero;
		if (targetEnemy != null)
		{
			fireDir = targetEnemy.transform.position - transform.position;
		}

		Move(moveDir);

		if (Input.GetButtonDown("Fire1"))
		{
			Fire(fireDir);
		}

		killCountText.text = killCount.ToString();
		hpBarImage.fillAmount = HpAmount;

		// transform.up/right/forward�� ���� ���͸� ������ ���� ���� ������ magnitude�� ���� 1�� �������� �ʾƵ� �ȴ�
		this.moveDir.up = moveDir;
		this.fireDir.up = fireDir;

		//print(this.moveDir.up);		// normalized�Ǿ� magnitude�� 1�� ������ ���� ���Ͱ� ��ȯ��
	}

	/// <summary>
	/// Transform�� ���� ���� ������Ʈ�� �����̴� �Լ�.
	/// </summary>
	/// <param name="dir">�̵� ����</param>
	public void Move(Vector2 dir)
	{
		transform.Translate(dir * moveSpeed * Time.deltaTime);
	}

	/// <summary>
	/// ����ü�� �߻�.
	/// </summary>
	public void Fire(Vector2 dir)
	{
		Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

		projectile.transform.up = dir;
		projectile.damage = damage;
	}

	public void TakeDamage(float damage)
	{
		print($"�ƾ�! : {damage}");
		hp -= damage;
		if (hp <= 0)
		{
			// ���� ���� ó��

		}
	}
}
