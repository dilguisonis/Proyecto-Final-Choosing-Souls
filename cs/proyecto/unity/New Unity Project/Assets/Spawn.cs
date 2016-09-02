using UnityEngine;
using System.Collections;

public class Spaw : MonoBehaviour {
	public Transform spawnPosition;
	public GameObject theMob;
	public bool haveStarted = false;
	public int quanty;

	//hacer otro playerstartpoint pero para cuando se inicie el juego. hacer bool piority, darle prioridad a cada uno. destruir el principal al hacer warp.

	// Use this for initialization
	void Start () {
		spawnPosition = this.transform;
		if (haveStarted == false)
		{
			for (int i = 1; i < quanty; i++) {
				Instantiate(theMob, spawnPosition.position, spawnPosition.rotation);
			}


			haveStarted = true;

		}
	}

	// Update is called once per frame
	void Update () {

	}
}
