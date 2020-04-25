using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public LayerMask player;
    public float damage = 1f;
    private bool IsCollided;
    public float radius = 1f;
    private PlayerHealth playerhealth;

    private void Update()
    {
        checkforDamage();
    }

    void checkforDamage()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, player);

        foreach(Collider h in hit)
        {
            playerhealth = h.GetComponent<PlayerHealth>();
            if (playerhealth)
            {
                IsCollided = true;
            }
        }

        if (IsCollided)
        {
            playerhealth.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
