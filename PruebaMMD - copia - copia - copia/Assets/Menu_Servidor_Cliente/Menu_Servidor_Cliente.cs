using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Servidor_Cliente : MonoBehaviour {

    public GameObject go_Admin_Xarxa;

	public  void Arranca_Red_Servidor()
    {
        GameObject go_adm_xrx = Instantiate(go_Admin_Xarxa);
        go_adm_xrx.GetComponent<Admin_Xarxa>().Iniciar(true);
        Destroy(gameObject);
    }

    public void Arranca_Red_Cliente()
    {
        GameObject go_adm_xrx = Instantiate(go_Admin_Xarxa);
        go_adm_xrx.GetComponent<Admin_Xarxa>().Iniciar(false);
        Destroy(gameObject);
    }


}
