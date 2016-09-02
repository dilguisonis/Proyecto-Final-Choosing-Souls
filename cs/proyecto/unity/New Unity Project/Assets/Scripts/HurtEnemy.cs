using UnityEngine;
using System.Collections;

public class HurtEnemy : MonoBehaviour {
	public float seconds = 0.1f;
    public int damageToGive;
    public GameObject damageBurst;
	private Rigidbody2D rbody;
    public Transform hitPoint;
    public GameObject damageNumber;

	private int currentDamage;
	private bool isgettingattacked = false;
	private PlayerStats thePS;
	private GameObject mob;
	private SlimeController mobMovement;
	float x;
	float y;

	public float timeToAttack;
	private bool hadAttacked = false;

    // Use this for initialization
    void Start()
    {
		thePS = FindObjectOfType<PlayerStats>();
//		rbody = mob.GetComponent<Rigidbody2D>();
		timeToAttack = 0f; //respetar el time attack del had attacked
    }

    // Update is called once per frame
    void Update()
    {
		if (hadAttacked) {
			timeToAttack -= Time.deltaTime;
			if (timeToAttack <0) {
				hadAttacked = false;
				//timeToAttack = 0.3f;
			}
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemie")
		{
			if (hadAttacked == false) {
			rbody = other.GetComponent<Rigidbody2D>();
			currentDamage = damageToGive + thePS.currentAttack;

			other.gameObject.GetComponent<EnemyHealth>().HurtEnemy(currentDamage);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject )Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;

            //ESTO DE ACÁ SON TRANFORMS QUE ORDENAN AL SLIME MOVERSE 1 TILE EN LA DIRECCION EN LA QUE GOLPEO EL PLAYER. HAY QUE HACER ALGO DIFERENTE, ALGO QUE EJECUTE UNA ANIMACIÓN DEL SLIME MOVIENDOSE A ESE LADO. UN SCRIPT.
           	//Acá debería ir un Switch
			if (GameObject.Find("Player").GetComponent<PlayerMovement>().lastMove.x == 1) //Derecha
            {
                //other.gameObject.transform.position = new Vector3((other.gameObject.transform.position.x + 1), other.gameObject.transform.position.y, Time.deltaTime);
				rbody.velocity= Vector2.zero;
				x=8f;
				y = 0f;
				other.gameObject.GetComponent<SlimeController>().GettingAttacked(x,y,seconds);
                    other.gameObject.GetComponent<FollowPlayer>().canfollow = false;
					isgettingattacked = true;

                }   
            if (GameObject.Find("Player").GetComponent<PlayerMovement>().lastMove.x == -1) //Izquierda
            {
                //other.gameObject.transform.position = new Vector3((other.gameObject.transform.position.x - 1), other.gameObject.transform.position.y, Time.deltaTime);
				rbody.velocity= Vector2.zero;
				x=-8f;
				y = 0f;
				other.gameObject.GetComponent<SlimeController>().GettingAttacked(x,y,seconds);
                    other.gameObject.GetComponent<FollowPlayer>().canfollow = false;
					isgettingattacked = true;
                }
            if (GameObject.Find("Player").GetComponent<PlayerMovement>().lastMove.y == 1)//Arriba
            {
                //other.gameObject.transform.position = new Vector3((other.gameObject.transform.position.x), other.gameObject.transform.position.y + 1, Time.deltaTime);
				rbody.velocity= Vector2.zero;
				x=0f;
				y = 8f;
				other.gameObject.GetComponent<SlimeController>().GettingAttacked(x,y,seconds);
                    other.gameObject.GetComponent<FollowPlayer>().canfollow = false;
					isgettingattacked = true;
                }
            if (GameObject.Find("Player").GetComponent<PlayerMovement>().lastMove.y == -1)//Abajo
            {
                //other.gameObject.transform.position = new Vector3((other.gameObject.transform.position.x), other.gameObject.transform.position.y - 1, Time.deltaTime);
				rbody.velocity= Vector2.zero;
				x=0f;
				y = -8f;
				other.gameObject.GetComponent<SlimeController>().GettingAttacked(x,y,seconds);
                other.gameObject.GetComponent<FollowPlayer>().canfollow = false;
					isgettingattacked = true;
                }
			hadAttacked = true;
			}
		}
     }
}

