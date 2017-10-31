//
// Guardar.cs
//
// Author:
//       Roldan <Rodis2@hotmail.com>
//
// Date 2016 Roldan

using UnityEngine;
using System.Collections;

public class Guardar : MonoBehaviour {
	System.DateTime Fecha;
	// Use this for initialization
	void Start () {
		//RECUERDA ESTO HACE QUE LA PARTIDA SE GUARDE AUTOMATICAMENE RECUERDA ACTIVARLO TRAS EL DEBUGUEO!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		//InvokeRepeating ("GuardarPartida", 10,30);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        GuardarPartida();
    }
	public void GuardarPartida()
	{
		Fecha = System.DateTime.Now;
		PlayerPrefs.SetString("Cash", Partida.Cash.ToString());
//		PlayerPrefs.SetFloat ("CashDecimal", Partida.CashDecimal);
		PlayerPrefs.SetString("CosteMejoraClick", Partida.CosteMejoraClick.ToString());
		PlayerPrefs.SetString("Fecha",  Fecha.ToString());
		PlayerPrefs.SetString("DineroClick", Partida.DineroClick.ToString());
		PlayerPrefs.SetInt ("NivelYonky", Partida.NivelYonky);
		for (int i = 0; i < Partida.NivelDeMercenarios.Count; i++) {
			PlayerPrefs.SetString ("Mercenario"+i, Partida.NivelDeMercenarios [i].ToString ());		
		}
		Debug.Log("Guardado");
	}
}
