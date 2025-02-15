using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임 전체 진행을 총괄하는 오브젝트
public class GameManager : MonoBehaviour
{
	// 게임 전체에 하나만 존재해야 한다
	private static GameManager instance;
	public static GameManager Instance => instance;
	internal List<Enemy> enemies = new List<Enemy>();   // 씬에 존재하는 전체 적 List
	internal Player player;		// 씬에 존재하는 플레이어 객체

	// 값의 초기화, 싱글턴 등은 awake에서
	// 결과 : 하이어라키에서 게임매니저를 여러개 만들어도 dontdestroy 어쩌구에는 제일 마지막 게임매니저만 올라가고 나머지는 스크립트가 삭제된다.(컴포넌트가)
	// 유니티에서 싱글톤 패턴을 적용하는 방법
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			// 컴포넌트만 없앤다. 오브젝트 없애려면 this 대신에 gameObject 하면된다.
			DestroyImmediate(this);
			return;
		}
		DontDestroyOnLoad(gameObject);
	}

	private void Start()
	{

	}
}

// 전형적인 C#의 싱글톤 객체 형식
public class DefaultSingleton
{
	// 현재 프로세스 내에 생성될 단일 책임을 진 인스턴스를 저장할 변수
	private static DefaultSingleton instance;

	// 외부에서 생성자를 호출할 수 없도록 기본 생성자 접근을 막는다.
	private DefaultSingleton() { }

	// 외부에서는 단일 생성된 인스턴스에 접근하여 값을 가져올 수만 있음(다른 값으로 대입은 불가)
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

// 기본적인 객체지향형 언어에서 싱글톤 객체를 만드는 방법
public class MyClass
{
	private static MyClass nonCollectableMyClass;   // 참조를 잃으면 안되는 myclass 인스턴스를 저장
	private MyClass() { }
	public int processCount;    // 전역변수(non-static). 단일책임 원칙

	public static MyClass GetMyClass()
	{
		if (nonCollectableMyClass == null)   // GetMyClass()가 최초 호출되었을 경우에만 true
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