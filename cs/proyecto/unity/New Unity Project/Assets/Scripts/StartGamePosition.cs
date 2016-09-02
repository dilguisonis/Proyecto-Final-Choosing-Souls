using UnityEngine;
using System.Collections;

public class StartGamePosition : MonoBehaviour {

    private PlayerMovement thePlayer;
    private CameraController theCamera;
    public Vector2 startDirection; 
    public bool isStarted = false;

    //hacer otro playerstartpoint pero para cuando se inicie el juego. hacer bool piority, darle prioridad a cada uno. destruir el principal al hacer warp.

    // Use this for initialization
    void Start()
    {
        if (isStarted = false)
        {
            thePlayer = FindObjectOfType<PlayerMovement>();
            thePlayer.transform.position = transform.position;
            theCamera = FindObjectOfType<CameraController>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
            isStarted = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
