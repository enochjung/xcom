using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverController : MonoBehaviour
{
    [SerializeField]
    private int health = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damaged(int damage)
    {
        health = health - damage;
        Debug.Log("엄폐물 피격");

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
