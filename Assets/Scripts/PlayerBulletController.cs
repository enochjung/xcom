using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
	[SerializeField]
	private float speed = 8f;
	[SerializeField]
	private int damage = 1;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(0, speed * Time.deltaTime, 0);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Alien(Clone)")
		{
			AlienController alienController = other.GetComponent<AlienController>();
			alienController.Damaged(damage);
			Destroy(gameObject);
			Debug.Log("공격");
		}
	}

	void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}
}
