using UnityEngine;
using System.Collections;

public class NPCLayerController : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            GameObject.FindGameObjectWithTag("NPC").GetComponent<SpriteRenderer>().sortingOrder = 1;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            GameObject.FindGameObjectWithTag("NPC").GetComponent<SpriteRenderer>().sortingOrder = 5;
        }
    }
}
