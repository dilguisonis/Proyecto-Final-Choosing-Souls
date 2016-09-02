using UnityEngine;
using System.Collections;

public class VillagerMovement : MonoBehaviour {

    public float moveSpeed;
    private Vector2 maxWalkPoint;
    private Vector2 minWalkPoint;

    private Rigidbody2D rbody;

    public bool iswalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int WalkDirection;

    private bool hasWalkZone;
	public bool canmove = true;
    public Collider2D walkZone;
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();

        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }


    }

    // Update is called once per frame
    void Update()
    {

		if (canmove) {
			
		
        if (iswalking)
        {
            walkCounter -= Time.deltaTime;


            switch (WalkDirection)
            {
                case 0:
                    rbody.velocity = new Vector2(0, moveSpeed);
                    if (hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                     
                        iswalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 1:
                    rbody.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone && transform.position.x > minWalkPoint.x)
                    {
                     
                        iswalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 2:
                    rbody.velocity = new Vector2(0, -moveSpeed);
                    if (hasWalkZone && transform.position.y < maxWalkPoint.y)
                    {
                     
                        iswalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 3:
                    rbody.velocity = new Vector2(-moveSpeed, 0);
                    if (hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                  
                        iswalking = false;
                        waitCounter = waitTime;
                    }
                    break;
            }
            if (walkCounter < 0)
            {
                iswalking = false;
                waitCounter = waitTime;
            }

        }
        else
        {
            waitCounter -= Time.deltaTime;

            rbody.velocity = Vector2.zero;
            if (waitCounter < 0)
            {
                ChooseDirection();
            }

        }
		}
    }

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        iswalking = true;
        walkCounter = walkTime;
    }
    public void RE()
    {
        iswalking = false;
        waitCounter = waitTime;
    }
}



