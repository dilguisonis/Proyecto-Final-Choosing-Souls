using UnityEngine;
using System.Collections;

public class QuestObject : MonoBehaviour {
	public int questNumber;
	public string startText;
	public string endText;
	public QuestManager theQM;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartQuest()
	{
		theQM.ShowQuestText(startText);
	}
	public void EndQuest()
	{
		theQM.ShowQuestText (endText);
		theQM.questCompleted [questNumber] = true;
		gameObject.SetActive(false);
	}

}
