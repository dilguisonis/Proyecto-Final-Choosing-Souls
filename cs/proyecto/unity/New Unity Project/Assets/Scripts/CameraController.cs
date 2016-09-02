using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float m_speed;
    Camera mycam;
    private static bool cameraExists;

	// Use this for initialization
	void Start () {

        mycam = GetComponent<Camera>();

   
        //if (!cameraExists)
        //{
          //  cameraExists = true;
           // DontDestroyOnLoad(transform.gameObject);
       // }
        //else
        //{
          //  Destroy(gameObject);
        //}
  
        //DontDestroyOnLoad(transform.gameObject); esto lo vi en https://youtu.be/tevpiu8CW6I?list=PLiyfvmtjWC_X6e0EYLPczO9tNCkm2dzkm&t=297 Lo borré porque me creaba 2 o 1 MainCamera más.
    }

    // Update is called once per frame
    void Update () {
        mycam.orthographicSize = (Screen.height / 50);

        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, m_speed) + new Vector3(0,0,-10);
        }
	}
}
