using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour {

    public int damageToGive;
    public GameObject damageBurst;
	public Rigidbody2D rbody;
	public float seconds;
    public GameObject damageNumber;
	public Animator anim;
	private int currentDamage;
	private PlayerStats thePS;

	public bool Left = false;
	public bool Right = false;
	public bool Up = false;
	public bool Down = false;

	public float smoothTime = 0.3F;

	private GameObject mob;

	private bool istime;

	public bool isnotime;

	public Health thePlayer;

	private bool isright;
	private bool isleft;
	private bool isup;
	private bool isdown;
	private bool CanAttack;
	private bool isredo;public bool  damaged; public bool hurti;
	public Vector3 moveDirection;
    // Use this for initialization
	void Start () {

		Left = false;
		Right = false;
		Up = false;
		Down = false;
		seconds = 1f;
		isnotime = false;
		thePS = FindObjectOfType<PlayerStats> ();
		thePlayer = FindObjectOfType<Health> ();
		istime = false; 
		mob = this.gameObject;
		CanAttack = true;

		CanAttack = this.gameObject.GetComponent<FollowPlayer> ().canAttack;
		isredo = this.gameObject.GetComponent<FollowPlayer> ().isred;
		damaged = thePlayer.isdamaged;
		//hurti = thePlayer.gameObject.GetComponent<Health> ().canbehurt;
    }
	
	// Update is called once per frame
	void Update () {
		if (istime) {
			if (!CanAttack) {
			seconds -= Time.deltaTime;
			if (seconds < 0) {
				//anim.SetBool("gettingAttacked", false);
				seconds = 1f;
				istime = false;
				CanAttack = true;
			
			}
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other)
    {

		if (other.tag== "Player" && other is BoxCollider2D)
        {
			if (CanAttack) {
				if (!damaged) {
					
					if (thePlayer.isdamaged == false) {
						currentDamage = damageToGive - thePS.currentDefense;
						Instantiate(damageBurst, transform.position, transform.rotation); //DEOS MEEI
					
			
					var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
					clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
					}


					thePlayer.gameObject.GetComponent<Health>().HurtPlayer(currentDamage);
				//clone.transform.parent = other.gameObject.transform.parent;
				}
				}

				if (currentDamage < 0 ) 
				{
					currentDamage = 0;
				}
				//thePlayer.GetComponent<PolygonCollider2D>().isTrigger = false;

			      
			if (GameObject.Find("Player").GetComponent<PlayerMovement>().lastMove.x == 1f && Right) //Derecha
            {
				CanAttack = false;
				isnotime = true;
				Right = false;
				istime = true;

				//anim.SetBool("gettingAttacked", true);

				mob.GetComponent<SlimeController>().GettingAttacked(20f,0f,2);
				mob.GetComponent<FollowPlayer>().canfollow = false;
			}
            
			if (GameObject.Find("Player").GetComponent<PlayerMovement>().lastMove.x == 1f && Left) //Derecha
			{
				CanAttack = false;
				CanAttack = false;
				isnotime = true;
				Left = false;
				istime = true;

				//anim.SetBool("gettingAttacked", true);

				mob.GetComponent<SlimeController>().GettingAttacked(-20f,0f,2);
				mob.GetComponent<FollowPlayer>().canfollow = false;
			}
			if (GameObject.Find("Player").GetComponent<PlayerMovement>().lastMove.x == -1f && Left) //Izquierda
            {
				CanAttack = false;
				isnotime = true;
				Left = false;
				istime = true;

				//anim.SetBool("gettingAttacked", true);

				mob.GetComponent<SlimeController>().GettingAttacked(-20f,0f,2);
				mob.GetComponent<FollowPlayer>().canfollow = false;
            }
			if (GameObject.Find("Player").GetComponent<PlayerMovement>().lastMove.x == -1f && Right) //Izquierda
			{
				CanAttack = false;
				isnotime = true;
				Right = false;
				istime = true;

				//anim.SetBool("gettingAttacked", true);

				mob.GetComponent<SlimeController>().GettingAttacked(20f,0f,2);
				mob.GetComponent<FollowPlayer>().canfollow = false;
			}
			if (GameObject.Find("Player").GetComponent<PlayerMovement>().lastMove.y == -1f && Down)//Abajo
			{
				CanAttack = false;
				isnotime = true;
				Down = false;
				istime = true;

				//anim.SetBool("gettingAttacked", true);

				mob.GetComponent<SlimeController>().GettingAttacked(0f,-20f,2);
				mob.GetComponent<FollowPlayer>().canfollow = false;
			}
			if (GameObject.Find("Player").GetComponent<PlayerMovement>().lastMove.y == -1f && Up)//Abajo
			{
				CanAttack = false;
				isnotime = true;
				Up = false;
				istime = true;

				//anim.SetBool("gettingAttacked", true);

				mob.GetComponent<SlimeController>().GettingAttacked(0f,20f,2);
				mob.GetComponent<FollowPlayer>().canfollow = false;
			}
			if (GameObject.Find("Player").GetComponent<PlayerMovement>().lastMove.y == 1f && Up)//Arriba
            {
				CanAttack = false;
				isnotime = true;
				Up = false;
				istime = true;

				//anim.SetBool("gettingAttacked", true);

				mob.GetComponent<SlimeController>().GettingAttacked(0f,20f,2);
				mob.GetComponent<FollowPlayer>().canfollow = false;
            }
			if (GameObject.Find("Player").GetComponent<PlayerMovement>().lastMove.y == 1f && Down)//Arriba
			{
				CanAttack = false;
				isnotime = true;
				Down = false;
				istime = true;

				//anim.SetBool("gettingAttacked", true);

				mob.GetComponent<SlimeController>().GettingAttacked(0f,-20f,2);
				mob.GetComponent<FollowPlayer>().canfollow = false;
			}
			if (GameObject.Find("Player").GetComponent<PlayerMovement>().lastMove.x == 0f && GameObject.Find("Player").GetComponent<PlayerMovement>().lastMove.y == 0f)//Arriba
			{
				CanAttack = false;
				isnotime = true;
				istime = true;

				//anim.SetBool("gettingAttacked", true);

				mob.GetComponent<SlimeController>().GettingAttacked(0f,20f,2);
				mob.GetComponent<FollowPlayer>().canfollow = false;
			}

          
	

            //Vector3.Reflect(other.relativeVelocity * -1, other.contacts[0].normal);
            /*
                                                                                ESTO ES PARA HACER LA ANIMACIÓN DE INJURED
            seconds -= Time.deltatime;
            if (seconds == 4)
            {
                other.gameObject.GetComponent<Animator>().SetBool("gettingAttacked", true);
            }
            if (seconds == 3)
            {
                other.gameObject.GetComponent<Animator>().SetBool("gettingAttacked", false);
            }
            if (seconds == 2)
            {
                other.gameObject.GetComponent<Animator>().SetBool("gettingAttacked", true);
            }
            if (seconds == 1)
            {
                other.gameObject.GetComponent<Animator>().SetBool("gettingAttacked", false);
            }*/
        }


    }

		



	void OnCollisionEnter2D(Collision2D other)
	{

	}


}