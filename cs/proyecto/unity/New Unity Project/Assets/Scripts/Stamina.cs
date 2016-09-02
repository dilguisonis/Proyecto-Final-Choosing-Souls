using UnityEngine;
using System.Collections;

public class Stamina : MonoBehaviour {
	public int staminaIncrease;
    public int playerMaxStamina;
    public int playerCurrentStamina;
    public bool must = true;
    public float waitToReload;

    // Use this for initialization
    void Start () {
        playerCurrentStamina = playerMaxStamina;
        waitToReload = 0.5f;
    }
	
	// Update is called once per frame
	void Update () {
        if (playerCurrentStamina < 0 )
        {
            playerCurrentStamina = 0;
        }
        if (must)
        {
        if (playerCurrentStamina != playerMaxStamina)
        {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0)
            {
				playerCurrentStamina += staminaIncrease;
                waitToReload = 0.5f;
            }
        }

        }
    }
    public void WastingStamina(int StaminaToWaste)
    {
        playerCurrentStamina -= StaminaToWaste;
    }
}
