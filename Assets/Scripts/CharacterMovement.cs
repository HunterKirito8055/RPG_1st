using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Animator P_anim;
    private Camera maincamera;

    private PlayerMovement player;
    private Vector3 direction;

    public float speed_attack = 0.05f;
    public float speed_Whileattacking = 0.1f; 
    public float speed = 0.7f;
    public float turnspeed =50f;
    public float jumpspeed = 20f;
    public float move_magnitude = 0.05f;

    private float speed_movemultiplier = 1f;

    private void Awake()
    {
        P_anim = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
    }
    void Start()
    {
        P_anim.applyRootMotion = false;
        maincamera = Camera.main;
    }

    void Update()
    {
        Movementandjumping();
    }
    private Vector3 MoveDirection
    {
        get { return direction;  }
        set
        {
            direction = value * speed_movemultiplier;
            if(direction.magnitude > 0.1f)
            {
                var newRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * turnspeed);
            }
            direction *= speed *(Vector3.Dot(transform.forward,direction ) + 1f)  * 5f;
            player.move(direction);
            animationmove(player.playercontroller.velocity.magnitude * 0.1f);
        }
    }
    void moving(Vector3 dir, float mult)
    {
        speed_movemultiplier = mult * 1f;
        MoveDirection = dir;
    }
    void animationmove(float magnitude)
    {
        if (magnitude > move_magnitude)
        {
            float Speed_animation = 2f * magnitude;

            if (Speed_animation < 1f)
                Speed_animation = 1f;
            if (P_anim.GetInteger("State") != 2)
            {
                P_anim.SetInteger("State", 1);
                P_anim.speed = Speed_animation;
            }

        }
        else if (P_anim.GetInteger("State") != 2)
        {
            P_anim.SetInteger("State", 0);

        }
    }
    void jumping()
    {
        player.jump(jumpspeed);
    }
    void Movementandjumping()
    {
        Vector3 moveinput = Vector3.zero;
        Vector3 forward = Quaternion.AngleAxis(-90f, Vector3.up) * maincamera.transform.right;

        moveinput += forward * Input.GetAxis("Vertical");
        moveinput += maincamera.transform.right * Input.GetAxis("Horizontal");

        moveinput.Normalize();
        moving(moveinput.normalized, 1f);
        if (Input.GetKey(KeyCode.Space))
        {
            jumping();
        }
    }
}
