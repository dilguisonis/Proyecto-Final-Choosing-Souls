using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnPositionManager : MonoBehaviour {
	public Transform spawnPosition;

	public GameObject theMob;

	public bool haveStarted = false;
	private GameObject thePlayer;
	public int quanty;
	private int quantySecondary;
	private int aux;



	public GameObject[] mobs;

	public float SpawnTime;
	private float SpawnTimeBC;
	public bool wantcontinue;
	public bool win;
	public int level;
	private float up;
	public GameObject continuar;
	public Text nivel; //esto tiene que ir en uimanager
	public Text STime; //esto tmb
	//hacer otro playerstartpoint pero para cuando se inicie el juego. hacer bool piority, darle prioridad a cada uno. destruir el principal al hacer warp.
	private bool WEWANT;
	// Use this for initialization
	private GameObject GO;
	private PlayerStats PS;

	void Start () {
		GO = theMob;
		PS = FindObjectOfType<PlayerStats>();
		wantcontinue = false;
		level = 1;
		spawnPosition = this.transform;
		WEWANT = true;
		SpawnTimeBC = SpawnTime;
		win = false;
		up = 0;
		thePlayer = GameObject.Find ("Player");
		continuar.SetActive(false);

	}

	// Update is called once per frame
	void Update () {
		nivel.text ="Wave: " + level;
		if (win) {
			if (WEWANT) {
				continuar.SetActive(true);	
				WEWANT = false;
			}
			if (wantcontinue) {
			STime.text = "Faltan " + SpawnTime + " segundos";
			SpawnTime -= Time.deltaTime;
			if (SpawnTime < 0f) {
				SpawnTime = SpawnTimeBC;
				level++;
				STime.text = "";
				win = false;
					quanty++;
					continuar.SetActive(false);
					wantcontinue = false;
					mobs = new GameObject[quanty];
					WEWANT = true;
			}
			}
		}


		if (!win) {
		if (haveStarted == false)
		{
				
				mobs = new GameObject[quanty];
				for (int i = 0; i < quanty; i++) 
			{
					//mobs[quantySecondary] = Instantiate (theMob, new Vector3(spawnPosition.position.x , spawnPosition.position.y + up,spawnPosition.position.z ), spawnPosition.rotation) as GameObject; 
					GO= (GameObject) Instantiate (theMob, new Vector3(spawnPosition.position.x , spawnPosition.position.y + up,spawnPosition.position.z ), spawnPosition.rotation);
					mobs [quantySecondary] =GO;
					//mobs[quantySecondary].gameObject.GetComponent<EnemyHealth> ().MaxHealth += level * 2;
					EnemyHealth EH = GO.transform.FindChild("Slime").GetComponent<EnemyHealth>();
					EH.MaxHealth += level * 2;
					EH.CurrentHealth = EH.MaxHealth;
					mobs [quantySecondary] =GO;
					quantySecondary++;
					up = up + 3;
			}

				//NO SE QUE HACER CON ESTO
				if (level == 100) {
					foreach (GameObject item in mobs) {
						item.gameObject.GetComponent<EnemyHealth> ().MaxHealth += level * 2;
						item.gameObject.GetComponent<EnemyHealth> ().CurrentHealth = theMob.gameObject.GetComponent<EnemyHealth> ().MaxHealth;
					}	
				}
			
				up = 0;
				quantySecondary = 0;
				haveStarted = true;

		}
		if (haveStarted) {
			aux = 0;
			foreach (GameObject item in mobs) {
				if (item.activeSelf == false) {
					aux++;
			}
				if (aux == quanty) {
					Debug.Log ("ganaste");
					win = true;
					haveStarted = false;
				}
		}
		}
		}
	}
	public void ToContinue()
	{
		//ya veo que hago con esto
		if (true) {
			continuar.SetActive(false);
			wantcontinue = true;			
			PS.PSAuxliarBool = true;
		}

		else {
			Debug.Log("Sali de la casa antes!!!");
		}
	}

}

		
	

