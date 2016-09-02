using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class WSManager : MonoBehaviour {
	public Slider healthBar;
	public Text textito;
	public GameObject Player;
	private EnemyHealth playerHealth;

	// Use this for initialization
	void Start () {
		playerHealth = Player.GetComponent<EnemyHealth>();
	}

	// Update is called once per frame
	void Update () {
		textito.text = playerHealth.CurrentHealth + "/" + playerHealth.MaxHealth;
		healthBar.maxValue = playerHealth.MaxHealth;
		healthBar.value = playerHealth.CurrentHealth;
		this.transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y + 2f, Player.transform.position.z );
	}
		
}
