using UnityEngine;
using System.Collections;

public class GoldAdd : MonoBehaviour {
	private GameObject goldie;
	public int quanty; 
	public GameObject damageBurst;
	// Use this for initialization
	void Start () {
		goldie = GameObject.Find ("Player");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player" && other is PolygonCollider2D) {
			
			Instantiate(damageBurst, transform.position, transform.rotation);
		goldie.gameObject.GetComponent<GoldManager> ().AddGold(quanty);
		Destroy(this.gameObject);
		}
	}
}
