using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public int playerMaxHealth;
    public int playerCurrentHealth;
    public float waitToReload;
    private bool reloading;
	private SpriteRenderer spri;
	public bool isdamaged;
	public float auxfloat;

	public bool canbehurt;
    // Use this for initialization
    void Start () {
		canbehurt = true;
		spri = this.gameObject.GetComponent<SpriteRenderer>();
        playerCurrentHealth = playerMaxHealth;
		isdamaged = false;
		auxfloat = 1f;

	}
	
	// Update is called once per frame
	void Update () {

        if (playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
			Yield ();
  
                waitToReload -= Time.time;
                if (waitToReload < 1)
                {
				Application.LoadLevel(1);

                }
                if (waitToReload < 0)
                {
                    gameObject.SetActive(true);

                }

        }   
		if (isdamaged) {
			if (auxfloat < 1f) {
				spri.color = new Color (spri.color.r, spri.color.g, spri.color.b, 0f);
				//1
			}
			auxfloat -= Time.deltaTime;
		
			if (auxfloat <0.75f) {
				spri.color = new Color (spri.color.r, spri.color.g, spri.color.b, 1f);
				//1
			}
			if (auxfloat <0.25f) {
				spri.color = new Color (spri.color.r, spri.color.g, spri.color.b, 0f);
				//1
			}
			if (auxfloat < 0f) {
				spri.color = new Color (spri.color.r, spri.color.g, spri.color.b, 1f);
				auxfloat = 1f;
				canbehurt = true;
				isdamaged = false;
			}

		}

	}
    public void HurtPlayer(int damageToGive)
    {
		if (canbehurt) {
		isdamaged = true;
        playerCurrentHealth -= damageToGive;
			canbehurt = false;
		}
    }
    public void SetMaxHealth()
    {
		playerCurrentHealth = playerMaxHealth;
    }

	
IEnumerator Yield()
	{
		yield return new WaitForSeconds (waitToReload);
	}
            
}
