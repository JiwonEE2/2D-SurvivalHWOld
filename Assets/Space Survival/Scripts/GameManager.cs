using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ��ü ������ �Ѱ��ϴ� ������Ʈ
public class GameManager : MonoBehaviour
{
	// ���� ��ü�� �ϳ��� �����ؾ� �Ѵ�
	private static GameManager instance;
	public static GameManager Instance => instance;
	internal List<Enemy> enemies = new List<Enemy>();   // ���� �����ϴ� ��ü �� List
	internal Player player;		// ���� �����ϴ� �÷��̾� ��ü

	// ���� �ʱ�ȭ, �̱��� ���� awake����
	// ��� : ���̾��Ű���� ���ӸŴ����� ������ ���� dontdestroy ��¼������ ���� ������ ���ӸŴ����� �ö󰡰� �������� ��ũ��Ʈ�� �����ȴ�.(������Ʈ��)
	// ����Ƽ���� �̱��� ������ �����ϴ� ���
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			// ������Ʈ�� ���ش�. ������Ʈ ���ַ��� this ��ſ� gameObject �ϸ�ȴ�.
			DestroyImmediate(this);
			return;
		}
		DontDestroyOnLoad(gameObject);
	}

	private void Start()
	{

	}
}

// �������� C#�� �̱��� ��ü ����
public class DefaultSingleton
{
	// ���� ���μ��� ���� ������ ���� å���� �� �ν��Ͻ��� ������ ����
	private static DefaultSingleton instance;

	// �ܺο��� �����ڸ� ȣ���� �� ������ �⺻ ������ ������ ���´�.
	private DefaultSingleton() { }

	// �ܺο����� ���� ������ �ν��Ͻ��� �����Ͽ� ���� ������ ���� ����(�ٸ� ������ ������ �Ұ�)
	public static DefaultSingleton Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new DefaultSingleton();
			}
			return instance;
		}
	}
}

// �⺻���� ��ü������ ���� �̱��� ��ü�� ����� ���
public class MyClass
{
	private static MyClass nonCollectableMyClass;   // ������ ������ �ȵǴ� myclass �ν��Ͻ��� ����
	private MyClass() { }
	public int processCount;    // ��������(non-static). ����å�� ��Ģ

	public static MyClass GetMyClass()
	{
		if (nonCollectableMyClass == null)   // GetMyClass()�� ���� ȣ��Ǿ��� ��쿡�� true
		{
			nonCollectableMyClass = new MyClass();
			return nonCollectableMyClass;
		}
		else
		{
			return nonCollectableMyClass;
		}
	}
}