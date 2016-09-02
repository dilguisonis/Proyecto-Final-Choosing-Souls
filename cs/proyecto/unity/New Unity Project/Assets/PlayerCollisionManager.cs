using UnityEngine;
using System.Collections;

public class PlayerCollisionManager : MonoBehaviour {
	private HurtPlayer HurtP; 
	public string lol;
	// Use this for initialization
	void Start () {
		lol = this.gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{ 
		if((other.gameObject.GetComponent("SlimeController") as SlimeController) != null) {
			switch (lol)
			{
			case "Left":
				other.GetComponent<HurtPlayer> ().Left = true;
				//Debug.Log ("funciona left");
				break;
			case "Right":
				other.GetComponent<HurtPlayer> ().Right = true;
				//Debug.Log ("funciona right");
				break;
			case "Up":
				other.GetComponent<HurtPlayer> ().Up = true;
				//Debug.Log ("funciona up");
				break;
			case "Down":
				other.GetComponent<HurtPlayer> ().Down = true;
				//Debug.Log ("funciona down");
				break;
			}

		}


	}
		
}
