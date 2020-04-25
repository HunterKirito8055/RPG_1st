using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   

    public LayerMask enemylayer;
    public float radius = 0.3f;
    public float damage = 1f;
    private bool isCollided;
    private EnemyHealth enemyhealth;


   
    // Update is called once per frame
    void Update()
    {
        CheckFordamage();
    }
    void CheckFordamage()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, enemylayer);

        foreach(Collider hits in hit)
        {
            enemyhealth = hits.GetComponent<EnemyHealth>();

            if (enemyhealth)
            {
                isCollided = true;
            }
           
        }
        if (isCollided)
        {
            isCollided = false;
            enemyhealth.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
