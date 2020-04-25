using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;

    public GameObject Dead_FX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float howmuchdamage)
    {
        health -= howmuchdamage;
        
        if(health<= 0)
        {
            Instantiate(Dead_FX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
