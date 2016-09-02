using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	public int currentLevel;
	public int currentLevelFalse;
	public int currentExp;
	public int[] toLevelUp;

	public int[] HPLevels;
	public int[] attacksLevels;
	public int[] staminaLevels;
	public int[] defenseLevels;
	public int[] luckLevels;
	public float[] speedLevels;

	private int HPNoNull;
	private int ATQNoNull;
	private int STAMINANoNull;
	private int RESNoNull;
	private int LUCKNoNull;
	private float SPEEDNoNull;

	public bool PSAuxliarBool;

	private int HPLegit;
	private int ATQLegir;
	private int STAMINALegit;
	private int RESLegit;
	private int LUCKLegit;
	private float SPEEDLegit;

	public int SkillPoints;
	public int currentHP;
	public int currentStamina;
	public int currentAttack;
	public int currentDefense;
	public int currentLuck;
	public float currentSpeed;

	public Rigidbody2D TheRB2D;
	private PlayerMovement PV;
	private Health theH;
	private Stamina theS;
	public int Points; 
	public int FalsePoints; 
	public GameObject LV;
	public GameObject ConfirmS;

	public Input Field;
	public bool HadConfirm;
	private SpawnPositionManager SPM;
	private bool isActive;
	private bool isFirstTime;

	public Text puntos;
	private bool LevelEarn;

	public int falselevel;
	public bool isReset;

	private int[] Count;
	private int[] FalseCount;
	public int limit;

	public bool SConfirm;

	// Use this for initialization
	void Start () {
		SConfirm = false;

		limit = 8;
	
		isReset = false;
		falselevel = 1;
		LevelEarn = false;
		currentLevel = 1;
		currentLevelFalse = 1;
		isFirstTime = true;
		PV = FindObjectOfType<PlayerMovement>();
		HadConfirm = true;
		isActive = false;

		HPNoNull = 0;
		ATQNoNull = 0;
		STAMINANoNull = 0;
		RESNoNull = 0;
		LUCKNoNull = 0;
		SPEEDNoNull = 0;

		HPLegit = 0;
		ATQLegir = 0;
		STAMINALegit = 0;
		RESLegit = 0;
		LUCKLegit = 0;
		SPEEDLegit = 0;
	
		PSAuxliarBool = true;

		currentSpeed = 8;
		//LV.SetActive (false); ESTO SE TIEWNE QUE ACTIVAR CUANDO LEVEL UP
		currentStamina = staminaLevels [currentLevel];
		currentHP = HPLevels [currentLevel];
		currentAttack = attacksLevels [currentLevel];
		currentDefense = defenseLevels [currentLevel];
		Points = 0; //tENGO QUE SACAR ESTO
		FalsePoints = 0;
		theH = FindObjectOfType <Health>();
		theS = FindObjectOfType <Stamina>();
		SPM = FindObjectOfType <SpawnPositionManager>();

	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.P)) {
			if (LV.activeSelf) {
				LV.SetActive(false);
				GameObject.Find ("Confirmar").SetActive (true);
				GameObject.Find ("Reset").SetActive (true);
				GameObject.Find ("Exit").SetActive (true);
			} else {
				LV.SetActive(true);
				GameObject.Find ("Confirmar").SetActive (false);
				GameObject.Find ("Reset").SetActive (false);
				GameObject.Find ("Exit").SetActive (false);
			}
		
		}

		puntos.text = "Puntos restantes: " + Points;
		if (currentExp >= toLevelUp[falselevel]) 
		{
			falselevel++;
			Points++;
			FalsePoints = Points;
		}

		if (SPM.wantcontinue) {
			
		}
		if (SPM.win && !isActive && HadConfirm && PSAuxliarBool && !SPM.wantcontinue) {
				LevelUp ();
				currentLevel = falselevel;
				LV.SetActive (true);
			PSAuxliarBool = false;
				HadConfirm = false;
				isActive = true;

				if (isFirstTime) {
				Count = new int[6];
				for (int i = 0; i < Count.Length; i++) {
					Count [i] = 0;
				}

				FalseCount = new int[6];
				for (int i = 0; i < FalseCount.Length; i++) {
					FalseCount [i] = 0;
				}

					HP (1, null);
					HPNoNull++;
					HPLegit++;
					STAMINA (1, null);
					STAMINANoNull++;
					STAMINALegit++;
					RES (1, null);
					RESNoNull++;
					RESLegit++;
					ATQ (1, null);
					ATQNoNull++;
					ATQLegir++;
					//			SPEED (0, null);
					LUCK (1, null);
					LUCKNoNull++;
					LUCKLegit++;
					isFirstTime = false;
				}
		}
		if (LV.activeSelf) {
			Time.timeScale = 0;
		} else {

			//ESTO INTERFIERE CON LA VERDADERA PAUSA
			if (HadConfirm) {
				Time.timeScale = 1;
			}

		}
	}

	public void AddExperience(int experienceToAdd)
	{
		currentExp += experienceToAdd;
    }
	public void LevelUp()
	{
		currentLevelFalse++;

	}
	public void Confirm()
	{
		//tiene que avisar que tiene puntos por gastar
		if (SConfirm) {
			
		
		if (!HadConfirm) {
			HadConfirm = true;
			isActive = false;
			/*
			HPLegit = currentHP;
			ATQLegir = currentAttack;
			STAMINALegit = currentStamina;
			RESLegit = currentDefense;
			LUCKLegit = currentLuck;
*/

			HPLegit= HPNoNull;
			ATQLegir= ATQNoNull;
			STAMINALegit=STAMINANoNull;
			RESLegit= RESNoNull;
			LUCKLegit=LUCKNoNull;
			SPEEDLegit= SPEEDNoNull;
			//SPEEDLegit = currentSpeed;
			isActive = false;
			FalsePoints = Points; //ESTO CAUSA PROBLEMAS SI O SI
	
			for (int i = 0; i < FalseCount.Length; i++) {
				FalseCount[i] = Count[i];
			}
			SConfirm = false;
			ConfirmS.SetActive(false);
			LV.SetActive (false);

		}
		}
	}
	public void Reset()
	{
		if (!HadConfirm) {
			
			Points = FalsePoints;

			currentHP = HPLevels[HPLegit];
			currentAttack = attacksLevels[ATQLegir];
			currentStamina = staminaLevels[STAMINALegit];
			currentDefense= defenseLevels[RESLegit];
			currentLuck=luckLevels[LUCKLegit];

			HPNoNull = HPLegit;
			ATQNoNull = ATQLegir;
			STAMINANoNull = STAMINALegit;
			RESNoNull = RESLegit;
			LUCKNoNull = LUCKLegit;
			SPEEDNoNull = SPEEDLegit;
			//currentSpeed= SPEEDLegit;
			isFirstTime = true;
			for (int i = 0; i < Count.Length; i++) {
				Count[i] = FalseCount[i];
			}
			HP (HPLegit, null);
			STAMINA (STAMINALegit, null);
			RES (RESLegit, null);
			ATQ (ATQLegir, null);
//			SPEED (SPEEDLegit, null);
			LUCK (LUCKLegit, null);
			isFirstTime = false;



		}
	}
	public void Exit()
	{
		if (!HadConfirm) {
			currentHP= HPLegit ;
			currentAttack= ATQLegir;
			currentStamina = STAMINALegit;
			currentDefense= RESLegit;
			currentLuck=LUCKLegit;
			//currentSpeed= SPEEDLegit;

			LV.SetActive (false);
		}
	}
	public void HP(int points, Text text)
	{
		if (Count[1] != limit) {
		if (!isFirstTime) {
			if (Points >  0) {
		text = GameObject.Find ("HPText").GetComponent<Text>();
		currentHP = HPLevels[points];
		theH.playerMaxHealth = currentHP;
		Points--;
		text.text = "" +  currentHP;
		HPNoNull++;
		Count [1]++;
							}
		} else {
			text = GameObject.Find ("HPText").GetComponent<Text>();
			currentHP = HPLevels[points];
			theH.playerMaxHealth = currentHP;
			text.text = "" +  currentHP;
			//HPNoNull++;
		}
	/*	if (isReset) {
			text = GameObject.Find ("HPText").GetComponent<Text>();
			currentHP = HPLevels[points];
			theH.playerMaxHealth = currentHP;
			text.text = "" +  currentHP;

		}*/
	}
	}
	public void STAMINA(int points, Text text)
	{
		if (Count[2] != limit) {
		if (!isFirstTime) {
			if (Points >  0) {
		text = GameObject.Find ("STAText").GetComponent<Text>();
		theS.playerMaxStamina = staminaLevels[points];
		Points--;
		text.text ="" +  theS.playerMaxStamina;
		STAMINANoNull++;
		Count [2]++;
			}	
		} else {
			text = GameObject.Find ("STAText").GetComponent<Text>();
			theS.playerMaxStamina = staminaLevels[points];
			text.text ="" +  theS.playerMaxStamina;
			//STAMINANoNull++;
		}
	}
		}

	public void RES(int points, Text text)
	{
		if (Count[3] != limit) {
		if (!isFirstTime) {
			if (Points >  0) {
		text = GameObject.Find ("RESText").GetComponent<Text>();
		currentDefense = defenseLevels[points];
		Points--;
		text.text = "" + currentDefense;
		RESNoNull++;
		Count [3]++;
			} 
		} else {
			text = GameObject.Find ("RESText").GetComponent<Text>();
			currentDefense = defenseLevels[points];
			text.text = "" + currentDefense;
		//	RESNoNull++;
		}
	}
	}

	public void ATQ(int points, Text text)
	{
			if (Count[4] != limit) {
		if (!isFirstTime) {
			if (Points >  0) {
		text = GameObject.Find ("ATQText").GetComponent<Text>();
		currentAttack = attacksLevels[points];
		Points--;
		text.text = "" + currentAttack;
		ATQNoNull++;
		Count [4]++;
			}
		} else {
			text = GameObject.Find ("ATQText").GetComponent<Text>();
			currentAttack = attacksLevels[points];
			text.text = "" + currentAttack;
		//	ATQNoNull++;
		}
	}

	}
	public void SPEED(int points, Text text)
	{
		//currentSpeed = speedLevels[points];
		Points--;
		//PV.moveSpeed = currentSpeed;
		//text.text = "" + currentSpeed;
	}

	public void LUCK(int points, Text text)
	{
				if (Count[5] != limit) {
		if (!isFirstTime) {
			if (Points > 0) {
		text = GameObject.Find ("LUCKText").GetComponent<Text>();
		currentLuck = luckLevels[points];
		Points--;
		text.text = "" + currentLuck;
		LUCKNoNull++;
		Count [5]++;
			} 
		} else {
			text = GameObject.Find ("LUCKText").GetComponent<Text>();
			currentLuck = luckLevels[points];
			text.text = "" + currentLuck;
		//	LUCKNoNull++;
		}
		}
	}

	public void INCREASE(string parent)
	{
		switch (parent) {
		case "HP":
			HP (HPNoNull + 1, null);
			break;
		case "STAMINA":
			STAMINA (STAMINANoNull + 1, null);
			break;
		case "RES":
			RES (RESNoNull + 1, null);
			break;
		case "ATQ":
			ATQ (ATQNoNull + 1, null);
			break;
		case "SPEED":
			//SPEED (SPEEDNoNull + 1, null);
			break;
		case "LUCK":
			LUCK (LUCKNoNull + 1, null);
			break;

		}
	}

	public void SuperConfirm()
	{
		SConfirm = true;
		ConfirmS.SetActive(true);
	}
	public void NoSuperConfirm()
	{
		ConfirmS.SetActive(false);
	}
}
