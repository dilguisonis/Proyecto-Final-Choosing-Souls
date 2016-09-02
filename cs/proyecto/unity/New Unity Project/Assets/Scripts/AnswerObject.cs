using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnswerObject : MonoBehaviour {
	private DialogueManager dMan;

	public Button button;
	public string ViewText;
	public int Choice;


	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogueManager>();
	}


	// Update is called once per frame
	void Update () {

	}
	public void WhichAnswer () {
		dMan.choice = Choice;
		dMan.hadAnswered = true;
	}
}
