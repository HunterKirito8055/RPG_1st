using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_Script : MonoBehaviour
{
    public LayerMask enemylayer;
    public float damage = 40f;
    public float Radius = 2f;
    private bool isCollided;
    private EnemyHealth enemyhealth;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkfordamage();
    }

    void checkfordamage()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, Radius, enemylayer);

        foreach(Collider h in hit)
        {
            enemyhealth = h.GetComponent<EnemyHealth>();
            if (enemyhealth)
            {
                isCollided = true;
            }
        }
        if (isCollided)
        {
            isCollided = false;
            enemyhealth.TakeDamage(damage);
            Destroy(gameObject); 
        }
    }

}
