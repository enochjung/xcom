using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//노정환이 구현
public class AlienBulletController : MonoBehaviour
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
        transform.Translate(0, -speed * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("플레이어 타격");
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.Damaged(damage);
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Cover")
        {
            Debug.Log("엄폐물 타격");
            CoverController coverController = other.GetComponent<CoverController>();
            coverController.Damaged(damage);
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
