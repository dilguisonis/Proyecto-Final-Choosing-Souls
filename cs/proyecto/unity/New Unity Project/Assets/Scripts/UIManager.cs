using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class UIManager : MonoBehaviour {
    public Slider healthBar;
    public Slider StaminaBar;

    public Text HPText;
	public Text LevelText;
	public Text ExpText;

    public GameObject Player;
    private Health playerHealth;
    private Stamina playerStamina;

    private PlayerStats thePS;

	public GameObject DPopUP;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
		thePS = FindObjectOfType <PlayerStats>();
        playerHealth = Player.GetComponent<Health>();
        playerStamina = Player.GetComponent<Stamina>();

    }
	
	// Update is called once per frame
	void Update () {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;

        StaminaBar.maxValue = playerStamina.playerMaxStamina;
        StaminaBar.value = playerStamina.playerCurrentStamina;

        HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
		LevelText.text = "Nvl: " + thePS.falselevel;
		ExpText.text = "Exp: " + thePS.currentExp + "/" + thePS.toLevelUp [thePS.falselevel];
	}

	public void PopUp (GameObject Popi)
	{
		Popi = ((GameObject)Instantiate (DPopUP, new Vector3 (transform.localPosition.x, 400, 0), Quaternion.identity) as GameObject);
		Popi.transform.parent =  this.gameObject.transform;

	}
}
