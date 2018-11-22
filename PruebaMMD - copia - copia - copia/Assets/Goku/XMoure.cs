using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class XMoure : NetworkBehaviour {

    Vector3 v3_velocitat_vertical = Vector3.zero;
    Vector3 v3_velocitat_horitzontal = Vector3.zero;



    public Vector3 v3_gravetat = new Vector3(0, -9.8f, 0);
    public float f_velocitat = 1f;
    public float f_salto = 1f;
    public float f_sensibilidad_raton = 10f;


    CharacterController cc_control;


    Vector3 v3_posicion_inicio;


    // Use this for initialization
    void Start()
    {
        if (!isLocalPlayer)
            return;
        cc_control = gameObject.GetComponent<CharacterController>();
        v3_posicion_inicio = transform.position;
    }



    // Update is called once per frame
    void LateUpdate()
    {
        if (!isLocalPlayer)
            return;
        //si toco suelo
        if (cc_control.isGrounded)
        {

            v3_velocitat_horitzontal = Vector3.zero;
            v3_velocitat_vertical = Vector3.zero;

            //moviento horizontal
            if (Input.GetKey(KeyCode.UpArrow))
            {
                v3_velocitat_horitzontal += new Vector3(0, 0, f_velocitat);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                v3_velocitat_horitzontal += new Vector3(0, 0, -f_velocitat);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                v3_velocitat_horitzontal += new Vector3(-f_velocitat, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                v3_velocitat_horitzontal += new Vector3(f_velocitat, 0, 0);
            }

            //salto
            if (Input.GetMouseButtonDown(1))
            {
                v3_velocitat_vertical += new Vector3(0, f_salto, 0);
            }

            float f_mov_raton = Input.GetAxis("Mouse X") * f_sensibilidad_raton;
            transform.Rotate(new Vector3(0, f_mov_raton, 0) * Time.deltaTime);
        }
        else //si estoy en el aire
        {
            v3_velocitat_vertical += (v3_gravetat * Time.deltaTime);
        }

        cc_control.Move(transform.TransformDirection(v3_velocitat_horitzontal + v3_velocitat_vertical) * Time.deltaTime);


        if (transform.position.y < -10)
            transform.position = v3_posicion_inicio;

    }
}
