using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NewGame(int Level)
    {
        Application.LoadLevel(Level);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
