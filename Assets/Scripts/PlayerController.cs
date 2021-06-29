using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 작업자 : 박한샘
public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float speed = 20f;
	[SerializeField]
	private int health = 3;
	[SerializeField]
	private GameObject bullet;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		// 플레이어 이동
		transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);
		// 플레이어 이동 범위 제한
		//transform.position = new Vector
		// 발사 (스페이스바)
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
		}

	}

	// 피격시 호출
	public void Damaged(int damage)
	{
		health = health - damage;
		Debug.Log("플레이어 피격");
		//ChangeLife(health);

		if (health <= 0)
		{
			Destroy(this.gameObject);
			//GameOver();
		}
	}

}