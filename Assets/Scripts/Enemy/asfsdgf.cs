using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asfsdgf : MonoBehaviour
{
	public float moveMagnitude = 0.05f;
	public float movement_Speed = 0.5f;
	private float speed_Move_Multiplier = 1f;

	public float distance_Attack = 4.5f;
	public float distance_MoveTo = 13f;
	public float turnSpeed = 10f;
	public float patrolRange = 10f;

	private int ai_Time = 0;
	private int ai_State = 0;

	private Transform player_Target;
	private Vector3 movement_Position;

	private PlayerMovement motor;

	private Animator anim;
	private string PARAMETER_RUN = "Run";

	void Awake()
	{
		anim = GetComponent<Animator>();
		motor = GetComponent<PlayerMovement>();
	}

	void Update()
	{
		EnemyAI();
	}

	void EnemyAI()
	{
		float distance = Vector3.Distance(movement_Position, transform.position);

		Quaternion target_Rotation = Quaternion.LookRotation(movement_Position - transform.position);
		target_Rotation.x = 0f;
		target_Rotation.z = 0f;

		transform.rotation = Quaternion.Lerp(transform.rotation, target_Rotation,
			turnSpeed * Time.deltaTime);

		if (player_Target != null)
		{
			movement_Position = player_Target.position;

			if (ai_Time <= 0)
			{
				ai_State = Random.Range(0, 3);
				ai_Time = Random.Range(10, 100);
			}
			else
			{
				ai_Time--;
			}

			if (distance <= distance_Attack)
			{
				if (ai_State == 0)
				{
					//Attack();
				}
			}
			else
			{
				if (distance <= distance_MoveTo)
				{
					transform.rotation = Quaternion.Lerp(transform.rotation, target_Rotation,
						turnSpeed * Time.deltaTime);

				}
				else
				{
					player_Target = null;

					if (ai_State == 0)
					{
						ai_State = 1;
						ai_Time = Random.Range(10, 500);

						movement_Position = transform.position +
						new Vector3(Random.Range(-patrolRange, patrolRange), 0f,
							Random.Range(-patrolRange, patrolRange));

					}
				}
			}

		}
		else
		{
			GameObject target = GameObject.FindGameObjectWithTag("Player");

			float targetDistance = Vector3.Distance(target.transform.position, transform.position);

			if (targetDistance <= distance_MoveTo ||
			   targetDistance <= distance_Attack)
			{

				player_Target = target.transform;
			}

			if (ai_State == 0)
			{
				ai_State = 1;
				ai_Time = Random.Range(10, 200);

				movement_Position = transform.position +
					new Vector3(Random.Range(-patrolRange, patrolRange), 0f,
						Random.Range(-patrolRange, patrolRange));
			}

			if (ai_Time <= 0)
			{
				ai_State = Random.Range(0, 3);
				ai_Time = Random.Range(10, 200);
			}
			else
			{
				ai_Time--;
			}
		}

		MoveToPosition(movement_Position, 1f, motor.playercontroller.velocity.magnitude);

	}

	void MoveToPosition(Vector3 position, float speedMult, float magnitude)
	{
		float speed = movement_Speed * speed_Move_Multiplier * 2 * 5 * speedMult;

		Vector3 direction = position - transform.position;

		Quaternion newRotation = transform.rotation;

		direction.y = 0f;

		if (direction.magnitude > 0.1f)
		{
			motor.move(direction.normalized * speed);

			newRotation = Quaternion.LookRotation(direction);

			transform.rotation = Quaternion.Slerp(transform.rotation, newRotation,
				turnSpeed * Time.deltaTime);

		}
		else
		{
			motor.stop();
		}

		AnimationMove(magnitude * 0.1f);

		//CheckIfAttackEnded();
		//CheckIfAttackEnded();

	}

	void AnimationMove(float magnitude)
	{
		if (magnitude > moveMagnitude)
		{

			float speedAnimation = magnitude * 2f;

			if (speedAnimation < 1)
				speedAnimation = 1f;

			if (!anim.GetBool(PARAMETER_RUN))
			{
				anim.SetBool(PARAMETER_RUN, true);
				anim.speed = speedAnimation;
			}

		}
		else
		{
			if (anim.GetBool(PARAMETER_RUN))
			{
				anim.SetBool(PARAMETER_RUN, false);
			}
		}
	}
}
