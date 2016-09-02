using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestAnswer : MonoBehaviour {
	public AnswerObject Answers;
	public AnswerObject Answers1;
	public AnswerObject Answers2;
	public AnswerObject Answers3;

	public int which;

	public DialogueManager theDM;

	public string cero;
	public string uno;
	public string dos;
	public string tres;

	//public string startText;
	//public string endText;
	// Use this for initialization
	void Start () {
		Answers.button.GetComponentInChildren<Text>().text = cero;
		Answers1.button.GetComponentInChildren<Text> ().text = uno;
		Answers2.button.GetComponentInChildren<Text> ().text = dos;
		Answers3.button.GetComponentInChildren<Text> ().text = tres;
	}

	// Update is called once per frame
	void Update () {

	}

}

