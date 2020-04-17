using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public CharacterController playercontroller ;
    private Collider collider;

    public float Lerptime = 10f;
    public float Gravity_multiplier = 1f;
    public float Distance_to_Ground = 0.1f;
    private float Fall_velocity = 0f;

    private bool IsGrounded;

    private Vector3 MoveDirection = Vector3.zero;
    private Vector3 TargetDirection = Vector3.zero;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        playercontroller = GetComponent<CharacterController>();
    }



    void Start()
    {
        Distance_to_Ground = collider.bounds.extents.y; // half size of the collider bounds
    
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = OnGroundCheck();
        MoveDirection = Vector3.Lerp(MoveDirection, TargetDirection, Time.deltaTime * Lerptime);
        MoveDirection.y = Fall_velocity; //its for bring back our plyr to ground

        playercontroller.Move(MoveDirection * Time.deltaTime);
        if (!IsGrounded)
        {
            Fall_velocity -= Gravity_multiplier * 90f * Time.smoothDeltaTime;
        }
    }

    //checking player whether he is onGround 
    private bool OnGroundCheck()
    {
        RaycastHit hit;
        if (playercontroller.isGrounded)
        {
            return true;
        }
        if(Physics.Raycast(collider.bounds.center,-Vector3.up,out hit,Distance_to_Ground + 0.1f))
        {
            return true;
        }
        return false;
    }
    public void move(Vector3 dir)
    {
        TargetDirection = dir;
    }
    public void stop()
    {
        MoveDirection = Vector3.zero;
        TargetDirection = Vector3.zero;
    }
    public void jump(float jumpspeed)
    {
        if (IsGrounded)   //if we r on Ground then fallvelocity equals to jumpspeed to make our player jump
        {
            Fall_velocity = jumpspeed;
        }

    }
    
}
