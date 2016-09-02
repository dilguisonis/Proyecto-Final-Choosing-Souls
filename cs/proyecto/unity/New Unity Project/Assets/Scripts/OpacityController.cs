using UnityEngine;
using System.Collections;

public class OpacityController : MonoBehaviour {
    private float waitToReload = 1;
    private float goopacity = 1; private float goneopacity = 0.84f;
    private bool hadenter = false;
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other is PolygonCollider2D)
        {
			MeshRenderer tronco = GameObject.FindGameObjectWithTag("Tronco").GetComponent<MeshRenderer>();
			MeshRenderer hojas = GameObject.FindGameObjectWithTag("Arbol").GetComponent<MeshRenderer>();
            if (other.gameObject.name == "Player")
            {
				tronco.material.SetColor("_Color", new Color(1, 1, 1, 0.8f));
				hojas.material.SetColor("_Color", new Color(1, 1, 1, 0.8f));
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        MeshRenderer tronco = GameObject.FindGameObjectWithTag("Tronco").GetComponent<MeshRenderer>();
		MeshRenderer hojas = GameObject.FindGameObjectWithTag("Arbol").GetComponent<MeshRenderer>();
        if (other.gameObject.name == "Player")
        {

            if (other is PolygonCollider2D)
            {
                tronco.material.SetColor("_Color", new Color(1, 1, 1, 1f));
				hojas.material.SetColor("_Color", new Color(1, 1, 1, 1f));
        }
        }

    }
}


