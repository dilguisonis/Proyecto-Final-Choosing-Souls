using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueManagerScript : MonoBehaviour {
	private DestroyElement destroy;
	DialogueParser parser;
	DialogueHolder DHol;
	public string dialogue, characterName;
	public int lineNum;
	int pose;
	string position;
	string[] options;
	public bool playerTalking;
	List<Button> buttons = new List<Button> ();

	public Text dialogueBox;
	public Text nameBox;
	public GameObject choiceBox;

	private GameObject DialogueHolder;

	public bool hadTalked;
	public bool canExit = false;
	// Use this for initialization
	void Start () {
		hadTalked = false;
		dialogue = "";
		characterName = "";
		pose = 0;
		position = "L";
		playerTalking = false;
		parser = GameObject.Find("DialogueParser").GetComponent<DialogueParser>();
		lineNum = 0;
	}

	// Update is called once per frame
	void Update () {
		if (!playerTalking && hadTalked == false) {
			ShowDialogue();
			hadTalked = true;
		}
		if (Input.GetMouseButtonDown (0) && playerTalking == false && hadTalked == true) {
			lineNum++;
			ShowDialogue();
		}

		UpdateUI ();
	}

	public void ShowDialogue() {
		//ResetImages ();
		ParseLine ();
	}

	void UpdateUI() {
		if (!playerTalking) {
			ClearButtons();
		}
		dialogueBox.text = dialogue;
		nameBox.text = characterName;
	}

	public void ClearButtons() {
		for (int i = 0; i < buttons.Count; i++) {
			print ("Clearing buttons");
			Button b = buttons[i];
			buttons.Remove(b);
			Destroy(b.gameObject);
		}
	}

	void ParseLine() {
		if (parser.GetName (lineNum) != "Player") {
			ClearButtons ();
			playerTalking = false;
			characterName = parser.GetName (lineNum);
			dialogue = parser.GetContent (lineNum);
			pose = parser.GetPose (lineNum);
			position = parser.GetPosition (lineNum);
			//DisplayImages();
			if (parser.GetName (lineNum+1) == "Player") {
				ClearButtons ();
				playerTalking = true;
				lineNum++;
				options = parser.GetOptions(lineNum);
				Debug.Log (options[0]);
				CreateButtons();
			}
		} 
	}
	public void Clear()
	{
	hadTalked = false;
	playerTalking = false;
	dialogue = "";
	characterName = "";
	pose = 0;
	position = "";
	lineNum = 0;
	canExit = true;

	}

	void CreateButtons() {
		for (int i = 0; i < options.Length; i++) {
			GameObject button = (GameObject)Instantiate(choiceBox);
			Button b = button.GetComponent<Button>();
			ChoiceButton cb = button.GetComponent<ChoiceButton>();
			cb.SetText(options[i].Split(':')[0]);
			cb.option = options[i].Split(':')[1];
			cb.box = this;
			b.transform.SetParent(this.transform);
			b.transform.localPosition = new Vector3(0,-25 + (i*50));
			b.transform.localScale = new Vector3(1, 1, 1);
			buttons.Add (b);
		}
	}

	void ResetImages() {
		if (characterName != "") {
			GameObject character = GameObject.Find (characterName);
			SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>();
			currSprite.sprite = null;
		}
	}

	void DisplayImages() {
		if (characterName != "") {
			GameObject character = GameObject.Find(characterName);

			SetSpritePositions(character);

			SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>();
			//currSprite.sprite = character.GetComponent<Character>().characterPoses[pose];
		}
	}


	void SetSpritePositions(GameObject spriteObj) {
		if (position == "L") {
			spriteObj.transform.position = new Vector3 (-6, 0);
		} else if (position == "R") {
			spriteObj.transform.position = new Vector3 (6, 0);
		}
		spriteObj.transform.position = new Vector3 (spriteObj.transform.position.x, spriteObj.transform.position.y, 0);
	}

	public void GetHolder(DialogueHolder DHolder)
	{
		this.DHol = DHolder;
	}
}