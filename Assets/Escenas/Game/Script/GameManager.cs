//
// GameManager.cs
//
// Author:
//       Roldan <Rodis2@hotmail.com>
//
// Date 2016 Roldan

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameObject Panel;
    public GameObject Panel2;
    public GameObject Panel3;
    // Use this for initialization
    void Start () {  
		Debug.Log ("Inicializar Mercenarios(0.0)-Comienzo");
		Libreria.InicializarMercenarios();
		Debug.Log ("Inicializar Mercenarios(0.5)-Inicializacion de mercenarios completa");
		Debug.Log ("Cargar Partida(1.0)-Comienzo");
        Partida.CargarPartida();
       // PanelMov.AlzarPanel(Panel2, Panel, Panel3);
        //PanelMov.AlzarPanel(Panel, Panel2, Panel3);
        Debug.Log ("Cargar Partida(2.0)-Fin de carga y arranque de juego");
		Debug.Log ("-------------------------------Fin De GameManager.Start-------------------------------");
        
    }
	
	// Update is called once per frame
	void Update () {
      
    }
   
   
  

   
     

}
