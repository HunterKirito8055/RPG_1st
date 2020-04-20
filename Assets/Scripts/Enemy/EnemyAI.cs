using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public float move_magnitude = 0.05f; 
    public float movement_speed = 0.5f;
    private float speed_multiplier = 1f;

    public float Distance_attack = 4.5f;
    public float Distance_MoveTo = 13f;
    public float TurnSpeed = 10f;
    public float patrol_range = 10f;

    private int ai_Time = 0;
    private int ai_state = 0;

    private Transform player;
    private Animator anim;
    private PlayerMovement movement;
    private Vector3 Move_position;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        AI();
    }

    void AI()
    {
        float distance = Vector3.Distance(Move_position, transform.position);
        Quaternion target_rotation = Quaternion.LookRotation(Move_position - transform.position);//look at player from our position
        target_rotation.x = 0;
        target_rotation.z = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, target_rotation, Time.deltaTime * TurnSpeed);

        if (player != null)
        {
            Move_position = player.position;
            if (ai_Time <= 0)
            {
                ai_state = Random.Range(0, 4);
                ai_Time = Random.Range(10, 100);

            }
            else
            {
                ai_Time--;
            }

            if (distance <= Distance_attack)
            {
                if (ai_state == 0)
                {
                    attack();
                }

            }
            else
            {
                if (distance <= Distance_MoveTo)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, target_rotation, TurnSpeed * Time.deltaTime);
                }
                else
                {
                    player = null;
                    if (ai_state == 0)
                    {
                        ai_state = 1; //the state of walk
                        ai_Time = Random.Range(10, 500);
                        Move_position = transform.position +
                            new Vector3(Random.Range(-patrol_range, patrol_range), 0f, Random.Range(-patrol_range, patrol_range));
                    }
                }
            }
        }
        else
        {
            GameObject target = GameObject.FindGameObjectWithTag("Player");
            float targetDistance = Vector3.Distance(target.transform.position, transform.position);

            if (targetDistance <= Distance_MoveTo || targetDistance <= Distance_attack)
            {
                player = target.transform;
            }
            if (ai_state == 0)
            {
                ai_state = 1;
                ai_Time = Random.Range(10, 200);
               
                Move_position = transform.position + 
                    new Vector3(Random.Range(-patrol_range,patrol_range), 0f, Random.Range(-patrol_range, patrol_range));
            }
            if (ai_Time <= 0)
            {
                ai_state = Random.Range(0, 1);
                ai_Time = Random.Range(10, 200);
            }
            else
            {
                ai_Time--;
            }
          

        }
        moveToPosition(Move_position, 1f, movement.playercontroller.velocity.magnitude);

    }
    void moveToPosition(Vector3 position,float speedmul,float magnitude)
    {
        float speed = movement_speed * speed_multiplier * 2 * 5 * speedmul;
 
        Vector3 direction = position - transform.position;
        Quaternion newrotation = transform.rotation;

        direction.y = 0f;


        if (direction.magnitude > 0.1f)
        {
            movement.move(direction.normalized * speed);

            newrotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, newrotation,TurnSpeed * Time.deltaTime);
        }
        else
        {
            movement.stop(); 
        }
        AnimationMove(magnitude * 0.1f);
        CheckifattackEnded();
    }
    void AnimationMove(float magnitude)
    {
        if(magnitude > move_magnitude)
        {
            float SpeedAnimation = magnitude * 2f;
            if (SpeedAnimation < 1f)
                SpeedAnimation = 1f;
            if (!anim.GetBool("Run"))
            {
                anim.SetBool("Run",true);
                anim.speed = SpeedAnimation;
            }
        }
        else
        {
            if (anim.GetBool("Run"))
            {
                anim.SetBool("Run", false);
            }
        }

    }

    void attack()
    {
        if (Random.Range(0, 2) > 0)
        {
            anim.SetBool("Attack1", true);

        }
        else
        {
            anim.SetBool("Attack2", true);
        }
    }

    void CheckifattackEnded()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
            {
                anim.SetBool("Attack1", false);
                anim.SetBool("Run", false);
            }

        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
            {
                anim.SetBool("Attack2", false);
                anim.SetBool("Run", false);
            }

        }

    }

}
       




















































































































