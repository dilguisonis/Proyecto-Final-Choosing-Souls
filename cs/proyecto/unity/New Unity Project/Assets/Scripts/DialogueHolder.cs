using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueHolder : MonoBehaviour {
	private DestroyElement destroy;
    public string dialogue;
	private DialogueParser dMAn;
	public GameObject Parser;
	public GameObject Manager;
    private  GameObject dPopUp;
    public bool indialogue;
	public bool inzone;

	private UIManager UIMan;

	public bool HadPopUp;

    // Use this for initialization
    void Start () {
		dMAn = FindObjectOfType<DialogueParser>();
		UIMan = FindObjectOfType<UIManager>();
		indialogue = false;
		inzone = false;
		HadPopUp = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (indialogue == false && inzone == true)
        {
            //dPopUp.SetActive(true);
			if (HadPopUp == false) {
				UIMan.PopUp(dPopUp);
				HadPopUp = true;
			}


			//Debug.Log("setactive");
            if (Input.GetKeyUp(KeyCode.E))
            {
				if (dialogue != "") {
					
					if (this.gameObject.tag == "NPC") {
						this.gameObject.GetComponent<VillagerMovement>().canmove = false;
						this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
					}

					GameObject.Find("Player").GetComponent<PlayerMovement>().canMove = false;
					//hay que arreglar el tema del arma
					GameObject.Find("Player").GetComponent<Animator>().SetFloat("lastmove_x", 0);
					GameObject.Find("Player").GetComponent<Animator>().SetFloat("lastmove_y", 1f);

				DestroyPopUp ();

				Manager.SetActive (true);
				Parser.SetActive (true);

			
				Parser.GetComponent<DialogueParser>().setDialogue(dialogue);

				indialogue = true;  
				}
            }
        }
		else
        {
            //dPopUp.SetActive(false);
			if (HadPopUp == true) {
				DestroyPopUp ();
				indialogue = false;  
			
			}

        }
		if (Manager.GetComponent<DialogueManagerScript>().canExit == true)
		{
			Manager.GetComponent<DialogueManagerScript> ().canExit = false;

			Parser.GetComponent<DialogueParser> ().setDialogue ("");
			Parser.SetActive (false);
			Manager.SetActive (false);
			indialogue = false;
			if (this.gameObject.tag == "NPC") {
				this.gameObject.GetComponent<VillagerMovement>().canmove = true;
			}GameObject.Find ("Player").GetComponent<PlayerMovement> ().canMove = true;
		}

    }

    void OnTriggerStay2D (Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            inzone = true;

            
        }
       // if (transform.parent.GetComponent<VillagerMovement>() != null)
        //{
          // transform.parent.GetComponent<VillagerMovement>().canMove = false;
        //}
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            inzone = false;
			indialogue = false;
          //  transform.parent.GetComponent<VillagerMovement>().canMove = true;
        }
    }

	public void DestroyPopUp()
	{
		destroy = FindObjectOfType<DestroyElement>();
		destroy.Destroy();
		HadPopUp = false;
		indialogue = false;
	}

}
