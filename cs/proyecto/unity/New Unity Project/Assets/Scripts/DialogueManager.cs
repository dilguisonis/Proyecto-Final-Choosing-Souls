using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour {
    public GameObject dBox;
	public int choice;
	public bool hadAnswered = false;
	public Text dText;
    private DialogueHolder dPopUp;



    public string[] dialogLines;
	public bool[] dialogs;
	public bool[] dialogsSecret;
    public int currentLine; 

    public bool dialogActive;

    private PlayerMovement thePlayer;




	// Use this for initialization
	void Start () {
        dPopUp = FindObjectOfType<DialogueHolder>();


	

        thePlayer = FindObjectOfType<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update () {
		if (dialogActive && hadAnswered) {
			if (!dialogs[0]) {
				switch (choice) {
				case 0:
					currentLine = 1;
					break;
				case 1:
					currentLine = 2;
					break;
				case 2:
					currentLine = 3;
					break;
				case 3:
					currentLine = 4;
					break;
				}
				dialogsSecret [0] = true;
				hadAnswered = false;
			}
				if (dialogs[0] && !dialogs[1] ) {
					switch (choice) {
					case 0:
						currentLine = 6;
					dialogsSecret [1] = true;
						break;
					case 1:
						currentLine = 7;
					dialogsSecret [1] = true;
						break;
					case 2:
						currentLine = 8;
					dialogsSecret [1] = true;
						break;
					case 3:
						currentLine = 9;
					dialogsSecret [1] = true;
						break;
					}
				dialogsSecret [1] = true;
				hadAnswered = false;
			}
					if (dialogs[1] && !dialogs[2]) {
						switch (choice) {
						case 0:
							currentLine = 11;
							break;
						case 1:
							currentLine = 12;
							break;
						case 2:
							currentLine = 13;
							break;
						case 3:
							currentLine = 14;
							break;
						}	
				dialogsSecret [2] = true;	
				hadAnswered = false;

			}
						if (dialogs[2] && !dialogs[3]) {
							switch (choice) {
							case 0:
								currentLine = 16;
								break;
							case 1:
								currentLine = 17;
								break;
							case 2:
								currentLine = 18;
								break;
							case 3:
								currentLine = 19;
								break;
								dialogsSecret [3] = true;
							}	
				dialogsSecret [3] = true;
				hadAnswered = false;
			}
						if (dialogs[3] && !dialogs[4]) {
							switch (choice) {
							case 0:
								currentLine = 21;
								break;
							case 1:
								currentLine = 22;
								break;
							case 2:
								currentLine = 23;
								break;
							case 3:
								currentLine = 24;
								break;
					dialogsSecret [4] = true;
					hadAnswered = false;
							}	
			}

			if (dialogsSecret[0] && !dialogs[0]) {
								dialogs [0] = true;
				Debug.Log ("0");
							}
			if (dialogsSecret[1] && !dialogs[1]) {	
								dialogs [1] = true;
				Debug.Log ("1");
							}
			if (dialogsSecret[2] && !dialogs[2]) {
								dialogs [2] = true;
				Debug.Log ("2");
							}
			if (dialogsSecret[3] && !dialogs[3]) {
								dialogs [3] = true;
				Debug.Log ("3");
							}
			if (dialogsSecret[4] && !dialogs[4]) {
								dialogs [4] = true;
				Debug.Log ("4");				
			}	
							

				
			

		}
      
        if (currentLine >= dialogLines.Length)
        {
          //  dPopUp.dPopUp.SetActive(false);
            dPopUp.indialogue = false;
            dBox.SetActive(false);
            dialogActive = false;

            currentLine = 0;
            thePlayer.canMove = true;
			Time.timeScale = 1;
        }

        dText.text = dialogLines[currentLine];
	}

    public void ShowBox(string dialogue)
    {
		
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
		thePlayer.canMove = false;
		thePlayer.anim.SetBool ("iswalking", false);
		Time.timeScale = 0;
	
    }
}