using UnityEngine;
using System.Collections;

public class DestroyElement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Destroy ()
	{
		//Instantiate(DPopUP, Vector3.zero, Quaternion.identity);
		Destroy(this.gameObject);
	}
}
