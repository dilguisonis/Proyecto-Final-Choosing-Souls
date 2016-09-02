using UnityEngine;
using System.Collections;

public class LoadNewArea : MonoBehaviour {
    public string LevelToLoad;
 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            //RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            yield return StartCoroutine(sf.FadeToBlack());
            Application.LoadLevel(LevelToLoad);
            yield return StartCoroutine(sf.FadeToClear());
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().enabled = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        }
    }

}
