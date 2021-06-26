using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public GameObject bulletPrefab;
    public float spawnRate;
    private float timeAfterSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        transform.Translate(xInput * speed * Time.deltaTime, yInput * speed * Time.deltaTime, 0);

        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn >= spawnRate && Input.GetKey(KeyCode.Space) == true)
        {
            timeAfterSpawn = 0f;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}
