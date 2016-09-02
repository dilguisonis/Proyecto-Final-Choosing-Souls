using UnityEngine;
using System.Collections;

public class PlayerStartPoint : MonoBehaviour {

    private PlayerMovement thePlayer;
    private CameraController theCamera;
    public Vector2 startDirection;
    public bool haveStarted = false;

    //hacer otro playerstartpoint pero para cuando se inicie el juego. hacer bool piority, darle prioridad a cada uno. destruir el principal al hacer warp.

	// Use this for initialization
	void Start () {

        if (haveStarted == false)
        {
			DontDestroyOnLoad(transform.gameObject);
            thePlayer = FindObjectOfType<PlayerMovement>();
            thePlayer.transform.position = transform.position;

            thePlayer.lastMove = startDirection;
            // startDirection = thePlayer.lastMove;
           theCamera = FindObjectOfType<CameraController>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
            haveStarted = true;
      
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
