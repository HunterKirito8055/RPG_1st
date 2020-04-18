using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //special attack
    public GameObject firetornado;

    //player movement
    private Animator P_anim;
    private Camera maincamera;

    private PlayerMovement player;
    private Vector3 direction;

   
    public float speed_Whileattacking = 0.1f; 
    public float speed = 0.7f;
    public float turnspeed =50f;
    public float jumpspeed = 20f;
    public float move_magnitude = 0.05f;

    private float speed_movemultiplier = 1f;

    //attack
    public AttackAnimation[] attack_animations;
    public string[] combo_List_attack;
    public float speed_attack = 0.05f;

    public int ComboType;
    private int Attack_Index = 0;

    private string[] combo_list;
    private int attack_Stack;
    private float attack_Stack_Temptime;

    private bool attacking;
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
       
        HandletheAttackAnimations();

        if (MouseLock.MouseLocked)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                
                playerattack();
            }
            if (Input.GetButtonDown("Fire2"))
            {
                playerattack();
                StartCoroutine(tornado());
            }
            specialattack();
        }
        
           Movementandjumping();
       
;    }
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
        //speed_movemultiplier = mult * 1f;
        //MoveDirection = dir;

        if (attacking)
        {
          
            speed_movemultiplier = speed_Whileattacking * mult ;
        }
        else
        {
            speed_movemultiplier = 1f * mult;

        }
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
    void Resetcombo()
    {
        Attack_Index = 0;
        attack_Stack = 0;
        attacking = false;
    }
    void FightAnimations()
    {
       
        if(combo_list != null && Attack_Index >= combo_list.Length)
        {
            Resetcombo(); 
        }
        if(combo_list != null && combo_list.Length > 0)
        {
            int motion_Index = int.Parse(combo_list[Attack_Index]);

            if(motion_Index < attack_animations.Length)
            {
                P_anim.SetInteger("State", 2);
                P_anim.SetInteger("AttackType", ComboType);
                P_anim.SetInteger("AttackIndex", Attack_Index);
            }
        }
    }
    void HandletheAttackAnimations() {
    if(Time.time > attack_Stack_Temptime + 0.5f)
        {
            attack_Stack = 0;
        }
        combo_list = combo_List_attack[ComboType].Split("," [0]);

        if (P_anim.GetInteger("State") == 2)
        {
            P_anim.speed = speed_attack;

            AnimatorStateInfo stateinfo = P_anim.GetCurrentAnimatorStateInfo(0);

            if (stateinfo.IsTag("Attack"))
            {
                int motionindex = int.Parse(combo_list[Attack_Index]);

                if(stateinfo.normalizedTime > 0.9f)
                {
                    P_anim.SetInteger("State", 0);

                    attacking = false;
                    Attack_Index++;

                    if (attack_Stack > 1)
                    { 
                        FightAnimations();
                    }
                    else
                    {
                        if (Attack_Index >= combo_list.Length)
                        {
                            Resetcombo();
                        }
                    }
                }
            }
        }

    }

    void playerattack()
    {
      
        if (attack_Stack < 1 || (Time.time > attack_Stack_Temptime + 0.2f && Time.time < attack_Stack_Temptime + 1f))
        {
            attack_Stack++;
            attack_Stack_Temptime = Time.time;

        }
        FightAnimations();
    }
    IEnumerator tornado()
    {
        yield return new WaitForSeconds(0.4f);
       
        Instantiate(firetornado, transform.position + transform.forward * 2.5f, Quaternion.identity);
    }

    void specialattack()
    {
        if (Input.GetKey(KeyCode.P))
        {
            P_anim.speed = 1f;
            P_anim.SetInteger("State", 2);
            P_anim.SetInteger("AttackType", 1);
            

            AnimatorStateInfo stateinf = P_anim.GetCurrentAnimatorStateInfo(0);
            if (stateinf.IsTag("skill"))
            {
                if(stateinf.normalizedTime > 0.9f)
                {
                    P_anim.SetInteger("State",0);
                    Movementandjumping();
                }
            }
        }
       
    }
}
