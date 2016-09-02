using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour {
	public int gold;
	public Text goldTXT;
	// Use this for initialization
	void Start () {
		gold = 0;
	}
	
	// Update is called once per frame
	void Update () {
		goldTXT.text = gold + " monedas"; 
	}
	public void AddGold(int quanty)
	{
		gold += quanty;
	}
	public void RestGold(int quanty)
	{
		gold -= quanty;
	}
}
