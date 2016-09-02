using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    GameObject PauseMenu;
    bool paused;
	private PlayerMovement thePlayer;
	private bool waspaused = false;
	private GameObject hover;
	private GameObject lv;
	// Use this for initialization
	void Start () {
        paused = false;
        PauseMenu = GameObject.Find("PauseMenu");
		lv = GameObject.Find("Level Up");
		thePlayer = FindObjectOfType<PlayerMovement>();
		hover = GameObject.Find ("SHOPPING");

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
			if (hover.activeInHierarchy == false || lv.activeInHierarchy == false) {
				paused = !paused;
			}
         
        }
        if (paused)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
			thePlayer.anim.SetBool("iswalking", false);
			thePlayer.canMove = false;
			waspaused = true;
        }
        else if (!paused)
        {
            PauseMenu.SetActive(false);
			//Time.timeScale = 1;
			if (waspaused == true) {
				Time.timeScale = 1;
				thePlayer.canMove = true;
				waspaused = false;
				return;
			}
		}
	}

    public void Resume()
    {
        paused = false;
    }
    public void MainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
	public void CaveGenerator()
	{
		//Application.Ope("CaveGeneratorV1.1");
		SceneManager.LoadScene (3);
	}
    public void Quit()
    {
        Application.Quit();
    }
		
}
