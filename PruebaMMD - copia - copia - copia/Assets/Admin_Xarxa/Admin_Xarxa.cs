using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


class MsgB_string:MessageBase
{
    public string str_frase;
}



public class Admin_Xarxa : NetworkManager {

    bool b_servidor = true;
    public string str_ip_servidor = "127.0.0.1";

   
    public InputField if_Enviar;
    public InputField if_Rec;


	
	public void Iniciar (bool b_srvd) {
        b_servidor = b_srvd;
        if (b_servidor)
            Arranca_Servidor();
        else
            Arranca_Cliente();
	}

    public void Enviar_Texto()
    {
        if (b_servidor)
        {
            Servidor_Envia_Msg(if_Enviar.text);
        }
        else
        {
            Client_Envia_Msg(if_Enviar.text);
        }
    }


    ///////////////////////////////////////////////
    ///  SERVIDOR
    ///  

    void Arranca_Servidor()
    {
        Debug.Log("SOY SERVIDOR");
        NetworkManager.singleton.StartServer();
        NetworkServer.RegisterHandler(1000, Servidor_Rec_Msg);

    }

    void Servidor_Rec_Msg(NetworkMessage networkMessage)
    {
        if_Rec.text = "CLIENT DICE: " + networkMessage.ReadMessage<MsgB_string>().str_frase;
    }

    void Servidor_Envia_Msg (string str_frase)
    {
        MsgB_string msgB_String = new MsgB_string();
        msgB_String.str_frase = str_frase;
        NetworkServer.SendToAll(1000, msgB_String);      
    }


    public override void OnServerConnect(NetworkConnection conn)
    {
        Debug.Log("Tengo un cliente desde " + conn.address);
    }



    ///////////////////////////////////////////////
    ///  CLIENTE
    ///  

    NetworkClient nc_client;

    void Arranca_Cliente()
    {
        Debug.Log("SOY CLIENTE");
        if (str_ip_servidor == string.Empty)
            str_ip_servidor = "127.0.0.1";

        NetworkManager.singleton.networkAddress = str_ip_servidor;

        nc_client = NetworkManager.singleton.StartClient();
        nc_client.RegisterHandler(1000, Cliente_Rec_Msg);

    }

    void Cliente_Rec_Msg(NetworkMessage networkMessage)
    {
        string str_frase = networkMessage.ReadMessage<MsgB_string>().str_frase;
        if_Rec.text =  "Servidor DICE: " + str_frase;
    }

    void Client_Envia_Msg(string str_frase)
    {
        MsgB_string msgB_String = new MsgB_string();
        msgB_String.str_frase = str_frase;

        nc_client.Send(1000, msgB_String);
    }


}
