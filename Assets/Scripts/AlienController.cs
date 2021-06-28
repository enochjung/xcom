using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * AlienController
 *
 * alien 객체의 controller
 * 
 * made by EnochJung
 * 2021/06/26 생성
 **/


/**
 * 추가 구현이 필요한 기능 :
 * 사망 이펙트 추가
 **/

public class AlienController : MonoBehaviour
{
	[SerializeField]
	[Tooltip("현재 체력")]
	int hp = 3;

	[SerializeField]
	[Tooltip("공격 주기(초)")]
	float shootPeriod = 5f;

	[SerializeField]
	[Tooltip("이동 속도")]
	float speed = 3f;

	[SerializeField]
	[Tooltip("x축 이동 반경")]
	float xBound = 7.6f;

	[SerializeField]
	[Tooltip("한 번 내려갈 때의 y축 이동 거리")]
	float yBound = 1.5f;

	[SerializeField]
	[Tooltip("게임오버 판정이 일어나는 y좌표. 해당 좌표 밑으로 에일리언이 내려가면 게임 오버")]
	float gameOverYBound = -3.5f;

	[SerializeField]
	GameObject alienBullet;

	GameManager gameManager;

	// 에일리언의 이동 방향. 0은 왼쪽, 1은 왼쪽 이후 아래, 2는 오른쪽, 3은 오른쪽 이후 아래
	int goingWay;

	// 에일리언이 y축으로 이동을 시작하기 직전의 y좌표
	float yMoving;

	// 호출 시 damage 값 만큼 피해를 받음
	// 체력이 0 이하로 떨어지면 사망
	public void Damaged(int damage)
	{
		hp -= damage;
		if (hp <= 0)
			Die();
	}

	void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		goingWay = 0;

		StartCoroutine(ShootCoroutine());
	}

	void Update()
	{
		Move();
		if (IsInGameOverZone())
		{
			gameManager.GameOver();
			Debug.Log("Game Over");
		}
	}

	private IEnumerator ShootCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(shootPeriod);
			Shoot();
		}
	}

	private void Shoot()
	{
		GameObject bullet = Instantiate(alienBullet) as GameObject;
		bullet.transform.position = this.transform.position;
	}

	private void Move()
	{
		switch (goingWay)
		{
			case 0:
				transform.Translate(-speed * Time.deltaTime, 0, 0);
				if (transform.position.x < -xBound)
				{
					yMoving = transform.position.y;
					goingWay = 1;
				}
				break;

			case 1:
				transform.Translate(0, -speed * Time.deltaTime, 0);
				if (yMoving - transform.position.y > yBound)
					goingWay = 2;
				break;

			case 2:
				transform.Translate(speed * Time.deltaTime, 0, 0);
				if (transform.position.x > xBound)
				{
					yMoving = transform.position.y;
					goingWay = 3;
				}
				break;

			case 3:
				transform.Translate(0, -speed * Time.deltaTime, 0);
				if (yMoving - transform.position.y > yBound)
					goingWay = 0;
				break;
		}
	}

	private bool IsInGameOverZone()
	{
		return transform.position.y < gameOverYBound;
	}

	private void Die()
	{
		// dying effect
		Destroy(gameObject);
	}
}
