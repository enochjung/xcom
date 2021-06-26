using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 10f;
	public GameObject bulletPrefab;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
			transform.Translate(-speed * Time.deltaTime, 0, 0);
		if (Input.GetKey(KeyCode.RightArrow))
			transform.Translate(+speed * Time.deltaTime, 0, 0);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameObject bullet = Instantiate(bulletPrefab) as GameObject;
			bullet.transform.position = transform.position;
		}
	}
}
