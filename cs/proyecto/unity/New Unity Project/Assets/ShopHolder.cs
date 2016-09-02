using UnityEngine;
using System.Collections;

public class ShopHolder : MonoBehaviour {
	public bool isinzone;
	private UIManager UIMan;
	private DestroyElement destroy;
	private SpawnPositionManager SPW;
	private  GameObject dPopUp;
	private bool HadPopUp;
	public GameObject hover;
	// Use this for initialization
	void Start () {
		HadPopUp = false;
		UIMan = FindObjectOfType<UIManager>();
		SPW = FindObjectOfType<SpawnPositionManager>();
		hover.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (isinzone) {
			
			if (HadPopUp == false) {
				UIMan.PopUp(dPopUp);
				HadPopUp = true;
			}

		if (Input.GetKeyUp(KeyCode.E))
		{
				hover.SetActive(true);
				DestroyElement[] hinges = FindObjectsOfType(typeof(DestroyElement)) as DestroyElement[];
				foreach (DestroyElement hinge in hinges) {
					hinge.Destroy ();
				}
				HadPopUp = true;
				Time.timeScale = 0;
			

		}
			if (Input.GetKeyUp(KeyCode.Escape))
			{
				hover.SetActive(false);
				if (HadPopUp) {
					HadPopUp = false;
				}
				Time.timeScale = 1;


			}

		}
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other is BoxCollider2D && other.name == "Player") 
		{
			isinzone = true;
		
		}
	}
	void OnTriggerExit2D (Collider2D other)
	{
		if (other is BoxCollider2D && other.name == "Player") 
		{
			DestroyElement[] hinges = FindObjectsOfType(typeof(DestroyElement)) as DestroyElement[];
			foreach (DestroyElement hinge in hinges) {
				hinge.Destroy ();
			}
			isinzone = false;
			HadPopUp = false;
		}
	}
}
