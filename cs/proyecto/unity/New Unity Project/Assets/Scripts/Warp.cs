using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {
	private SpawnPositionManager SPW;
    public Transform warpTarget;
	public bool WARPEO;
	void Start () {
		SPW = FindObjectOfType <SpawnPositionManager>();


	}

    IEnumerator OnTriggerEnter2D (Collider2D other)
    {
		if (SPW.win && !SPW.wantcontinue) {
			//TIENE QUE APARECER UN CARTEL
			//SPW.win
		if (other.name == "Player" && other is BoxCollider2D)
        {
     
	
		ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();


        GameObject.Find("Player").GetComponent<Animator>().enabled = false;
        GameObject.Find("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        yield return StartCoroutine(sf.FadeToBlack());


        Debug.Log("An Object Collied");
			other.gameObject.transform.position = new Vector3 (warpTarget.position.x, warpTarget.position.y, -50);
		
        Camera.main.transform.position = warpTarget.position;
				if (SPW.continuar.activeInHierarchy == false) {
					SPW.continuar.SetActive (true);
				} else {
					SPW.continuar.SetActive (false);	
				}

        yield return StartCoroutine(sf.FadeToClear());
        
			GameObject.Find("Player").GetComponent<Animator>().enabled = true;
			GameObject.Find("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
			GameObject.Find("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
		
    }
		}
}
}

