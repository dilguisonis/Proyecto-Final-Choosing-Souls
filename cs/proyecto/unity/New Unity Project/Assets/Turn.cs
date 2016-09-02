using UnityEngine;
using System.Collections;

public class Turn : MonoBehaviour {
    private bool canTurn;

	private Transform UNO;
	private Transform DOS;
	// Use this for initialization
	void Start () {
		UNO = this.gameObject.transform;
		DOS = this.gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.GetComponentInParent<FollowPlayer>().isTurned == true) {
			UNO= this.gameObject.GetComponentInParent<FollowPlayer> ().uno;
			DOS= this.gameObject.GetComponentInParent<FollowPlayer> ().dos;

			var lookPos = UNO.position - UNO.position;
			lookPos.y = 0;
			var rotation = Quaternion.LookRotation(lookPos);
			transform.rotation = Quaternion.Slerp(UNO.rotation, rotation, Time.deltaTime * 80);
		} else {
			UNO= this.gameObject.GetComponentInParent<FollowPlayer> ().uno;
			DOS= this.gameObject.GetComponentInParent<FollowPlayer> ().dos;
			 
			var lookPos = UNO.position - UNO.position;
			lookPos.y = 0;
			var rotation = Quaternion.LookRotation(lookPos);
			transform.rotation = Quaternion.Slerp(UNO.rotation, rotation, Time.deltaTime * 80);
		}
	}
}
