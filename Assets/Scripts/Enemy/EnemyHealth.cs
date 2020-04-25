using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;

    public GameObject Dead_FX;
    public void TakeDamage(float HowMuchDamage)
    {
        health -= HowMuchDamage;
        
        if(health <= 0f)
        {

            Instantiate(Dead_FX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
