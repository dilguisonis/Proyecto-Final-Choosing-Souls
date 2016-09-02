using UnityEngine;
using System.Collections;

public class SlimeController : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D rbody;

    private bool moving;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;

    public Vector3 moveDirection;

    public float waitToReload;
    private bool reloading;
    private GameObject thePlayer;
	public bool gettingAttacked;
	public float time;
	public bool canmove;
	private bool istimeQ; 
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
		istimeQ = this.gameObject.GetComponent<HurtPlayer> ().isnotime;
        //imeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
		canmove = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (canmove) {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            rbody.velocity = moveDirection;

            if (timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
                //timeBetweenMoveCounter = timeBetweenMove;
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            rbody.velocity = Vector2.zero;
            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                //timeToMoveCounter = timeToMove;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }
        if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 1)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            if (waitToReload < 0)
            {
                thePlayer.SetActive(true);
            }
        }
		}
		if(gettingAttacked)
		{
			time -= Time.deltaTime *4f;
			if (time < 0) 
			{
				rbody.velocity= Vector2.zero;
				gettingAttacked = false;
				canmove = true;
				time = 0.1f;
                this.gameObject.GetComponent<FollowPlayer>().canfollow = true;
                //TAMBIÉN SE TIENE QUE ACTIVAR EL ESTADO DE "HURT"
            }
		}
	}


	public void GettingAttacked(float x, float y, float seconds)  
	{
			canmove = false;
			time = seconds; 
			rbody.velocity= new Vector2(x, y);
		    gettingAttacked = true;
		istimeQ = false;
	}
}
