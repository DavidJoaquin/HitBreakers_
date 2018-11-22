using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class XTransformSync : NetworkBehaviour {

    
    Vector3 v3_posicio_sync;
    Quaternion q_rotacio_sync;
		
	// Update is called once per frame
	void Update () { 
        if(isLocalPlayer)
        {
            Cmd_Envia_Transform(transform.position, transform.rotation);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position,v3_posicio_sync,0.5f);
            transform.rotation = Quaternion.Lerp(transform.rotation,q_rotacio_sync,0.5f);
        }
	}

    [Command]
    void Cmd_Envia_Transform(Vector3 v3_posicio,Quaternion q_rotacio)
    {
        v3_posicio_sync = v3_posicio;
        q_rotacio_sync = q_rotacio;
        Rpc_Envia_Transform(v3_posicio, q_rotacio);
    }

    [ClientRpc]
    void Rpc_Envia_Transform(Vector3 v3_posicio, Quaternion q_rotacio)
    {
        v3_posicio_sync = v3_posicio;
        q_rotacio_sync = q_rotacio;
    }

}
