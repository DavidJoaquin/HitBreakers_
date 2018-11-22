using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirPlataforma : MonoBehaviour {

//    public GameObject jugador;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}




    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);

        if (collision.collider.tag == "Player")
        {
            collision.collider.transform.SetParent(this.transform);
        }
    }

}
