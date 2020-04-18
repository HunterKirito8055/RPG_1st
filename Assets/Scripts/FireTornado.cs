using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTornado : MonoBehaviour
{
    public float speed = 250f;
    public float speed_max = 350f;
    public float speedmultiplier = 1f;

    private float lifetime = 4f;

    private Transform player;
    private Rigidbody body;
    private Vector3 direction;
    void Awake()
    {
        body = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        direction = player.forward;  
    }

     void Start()
    {
        Destroy(gameObject, lifetime);
    }
    // Update is called once per frame
    void Update()
    {
        speed += speedmultiplier;

        if (speed > speed_max)
            speed = speed_max;
        body.velocity = speed * Time.deltaTime * direction;
    }
}
