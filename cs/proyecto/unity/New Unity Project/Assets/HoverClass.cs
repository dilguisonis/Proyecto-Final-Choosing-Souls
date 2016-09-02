using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HoverClass : MonoBehaviour {

    public string Nombre;
    public string Descripcion;
    public int Precio;
    
    public Text  text;

    void Start () {
       // text.enabled = false;
    }
    
	void OnMouseEnter()
    {
        if (text.enabled == false)
        {
            text.enabled = true;
			Debug.Log("exit");
            
        }
        

    }
    
	void  OnMouseExit()
    { 
        text.enabled = false;
        
		Debug.Log("enter");

    }
    

   

}
