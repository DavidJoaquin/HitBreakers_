using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toca_Suelo : MonoBehaviour {

    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update () {

        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, 
            transform.TransformDirection(Vector3.down), 
            out hit,
            cc.height/2 + 0.1f ))
        {
            transform.parent = hit.transform;
        }
        else
        {
            transform.parent = null;
        }


    }
}
