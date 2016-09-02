using UnityEngine;
using System.Collections;

public class RenderController : MonoBehaviour {



	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.name == "Slime")
        {
            if (other is PolygonCollider2D || other is CircleCollider2D)
            {
                GameObject.FindGameObjectWithTag("NPC").GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
			if (other is BoxCollider2D || other is CircleCollider2D)
			{
            GameObject.FindGameObjectWithTag("Casa").GetComponent<MeshRenderer>().sortingOrder = 1;
            GameObject.FindGameObjectWithTag("Farol").GetComponent<MeshRenderer>().sortingOrder = 1;
			GameObject.FindGameObjectWithTag("Barrel").GetComponent<MeshRenderer>().sortingOrder = 1;
			GameObject.FindGameObjectWithTag("Sign").GetComponent<MeshRenderer>().sortingOrder = 2;
			GameObject.FindGameObjectWithTag("Bush").GetComponent<MeshRenderer>().sortingOrder = 2;
				GameObject.FindGameObjectWithTag("Arbol").GetComponent<MeshRenderer>().sortingOrder = 1;
				GameObject.FindGameObjectWithTag("Tronco").GetComponent<MeshRenderer>().sortingOrder = 1;
			}}

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.name == "Slime")
        {
            if (other is PolygonCollider2D || other is CircleCollider2D)
            {
                GameObject.FindGameObjectWithTag("NPC").GetComponent<SpriteRenderer>().sortingOrder = 4;
            }
			if (other is BoxCollider2D || other is CircleCollider2D)
			{
            GameObject.FindGameObjectWithTag("Casa").GetComponent<MeshRenderer>().sortingOrder = 5;
            GameObject.FindGameObjectWithTag("Farol").GetComponent<MeshRenderer>().sortingOrder = 5;
			GameObject.FindGameObjectWithTag("Barrel").GetComponent<MeshRenderer>().sortingOrder = 5;
			GameObject.FindGameObjectWithTag("Sign").GetComponent<MeshRenderer>().sortingOrder = 5;
			GameObject.FindGameObjectWithTag("Bush").GetComponent<MeshRenderer>().sortingOrder = 5;
				GameObject.FindGameObjectWithTag("Arbol").GetComponent<MeshRenderer>().sortingOrder = 5;
				GameObject.FindGameObjectWithTag("Tronco").GetComponent<MeshRenderer>().sortingOrder = 5;
			}
        }
    }
}
