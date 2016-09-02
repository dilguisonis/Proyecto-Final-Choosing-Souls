using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
	public Animator anim;

	public float Timer;
	public float TimerAux;
	public float ElseTimer;
	public float TimeraMovement;
	public float TimeraMovementAux;

	public float TimerForAttack;

	public Transform target;
	public float speed = 8f;
	public float minDistance = 2f;
	private float range;
	public bool canfollow = true;

	public bool canmovetowards;
	public bool hadattacked;

	private bool cangetdamage;
	public bool isred;
	private GameObject mob;

	public bool canAttack;
	private Transform savePosition;

	public Transform uno;
	public Transform dos;
	private bool hadturn;
    public bool isTurned;

	void Start()
	{

        isTurned = false;
		isred = false;
		canAttack = false;
		cangetdamage = this.gameObject.GetComponent<SlimeController> ().gettingAttacked;
		TimeraMovement = 1f;
		ElseTimer = 1f;
		Timer = 0.5f;
		TimerAux = 1f;
		TimerForAttack = 1f;
		TimeraMovementAux = 2f;
		target = GameObject.Find ("Player").GetComponent<Transform> ();
		anim = GetComponent<Animator>();
		mob = this.gameObject;
		canmovetowards = true;
		hadattacked = false;
	}

	void Update()
	{
			this.gameObject.GetComponent<SlimeController>().canmove = false;
			range = Vector2.Distance(transform.position, target.position);
		if (transform.position.x < target.position.x) {
			uno.position = transform.position;
			dos.position = target.position;
            isTurned = true;
			var lookPos = transform.position - target.position;
			lookPos.y = 0;
			var rotation = Quaternion.LookRotation(lookPos);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 80);
		} else {
			uno = transform;
			dos = target;
            isTurned = false;

			var lookPos = target.position - transform.position;
			lookPos.y = 0;
			var rotation = Quaternion.LookRotation(lookPos);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 80);
		}

		if (canmovetowards) {
		if (canfollow)
		{ 	
				if (range > minDistance)
				{
					canAttack = false;
				TimeraMovement -= Time.deltaTime;
				if (TimeraMovement < 0) {
					TimeraMovementAux -= Time.deltaTime;
						if (TimeraMovementAux > 0) {

						anim.SetBool("isattacking", false);		
							isred = false;
							transform.position = Vector2.MoveTowards(transform.position, target.position, (speed) * Time.deltaTime);
						savePosition = this.transform;
					
						} else {
						TimeraMovementAux = 2f;
						TimeraMovement = 1f;
					}
					}
				  }
					{
		
		}
		if (range < minDistance)
			{
				TimeraMovement = 1f;
				//minDistance += 10f;
					isred = false;
			//canfollow = false; 
			Timer -= Time.deltaTime;
			if (Timer < 0f) {
						canAttack = true;
						anim.SetBool("isattacking", true);
						isred = true;
						transform.position = Vector2.MoveTowards(transform.position, target.position, (speed+(speed%20)) * Time.deltaTime);
				TimerAux -= Time.deltaTime;
				if (TimerAux  < 0f) {
							canAttack = false;
							isred = false;
							anim.SetBool("isattacking", false);
						transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
					TimerAux = 1f;
						Timer = 0.5f;
				}
				}



			//transform.position = Vector2.MoveTowards(savePosition, target.position, (speed*2) * Time.deltaTime);
			} else {
			TimerAux = 1f;
			Timer = 0.5f;
				anim.SetBool("isattacking", false);
	
			if (!canfollow) {

			ElseTimer -= Time.deltaTime;
			if (ElseTimer < 0) {
						
					ElseTimer = 1f;
				canfollow = true;
			}

			}

			//else
			//{
			//	this.gameObject.GetComponent<SlimeController>().canmove = true;
			//}
		

	}
		}
		else {
		//	transform.position = Vector2.MoveTowards(transform.position, savePosition.position, 1);
			TimerForAttack -= Time.deltaTime;
			if (TimerForAttack  < 0f)  {
				canmovetowards = true;
				TimerForAttack = 1f;

			}
		}
		}else	
			TimerForAttack -= Time.deltaTime;
		if (TimerForAttack  < 0f)  {
			canmovetowards = true;
			TimerForAttack = 1f;

		}
		}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Right" || other.name == "Left" || other.name == "Up" || other.name == "Down") {//el daño se rec	ibe cuando es en el pollyngon
			canmovetowards = false;
			TimerAux = 1f;
			anim.SetBool("isattacking", false);
			TimeraMovement = 1f;
			ElseTimer = 1f;
			Timer = 0.5f;
			TimerAux = 1f;
			TimerForAttack = 1f;
			TimeraMovementAux = 2f;
		}
		if (other.name == "sword") {

			if (!cangetdamage) {				
			anim.SetBool("isattacking", false);
			hadattacked = true;
			canmovetowards = false;
			TimeraMovement = 1f;
			ElseTimer = 1f;
			Timer = 0.5f;
			TimerAux = 1f;
			TimerForAttack = 1f;
			TimeraMovementAux = 2f;
						
			}
		}
	}
}
