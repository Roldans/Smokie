//
// Libreria.cs
//
// Author:
//       Roldan <Rodis2@hotmail.com>
//
// Date 2016 Roldan

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Numeros;

public class Libreria : MonoBehaviour {
	static decimal a;
  
	static System.TimeSpan Fecha2;
	static float TiempoPasado;



  
	//--------------------------------------
	//Mercenarios
	public static bool ComprobarMercenarioActivo(int n){
		return Partida.NivelDeMercenarios[n] > 0;
	}
	public static void InicializarMercenarios(){
		/*Inicializacion de las listas de mercenarios
		 *
		 * 
		 */

	
		Partida.NivelDeMercenarios.Add (0);
		Partida.NivelDeMercenarios.Add (0);
		Partida.NivelDeMercenarios.Add (0);
		Partida.NivelDeMercenarios.Add (0);
		Debug.Log ("Inicializar Mercenarios(0.1)-Niveles inicializados a 0");

		Partida.CoeficienteDeCostesDeMercenarios.Add (1.02f);
		Partida.CoeficienteDeCostesDeMercenarios.Add (1.105f);
		Partida.CoeficienteDeCostesDeMercenarios.Add (1.08f);
		Partida.CoeficienteDeCostesDeMercenarios.Add (1.10f);

		Debug.Log ("Inicializar Mercenarios(0.2)-Coeficientes de costes inicialzados");

		Partida.GananciasDeMercenarios.Add (2f);
		Partida.GananciasDeMercenarios.Add (150f);
		Partida.GananciasDeMercenarios.Add (720f);
		Partida.GananciasDeMercenarios.Add (3600f);
		Debug.Log ("Inicializar Mercenarios(0.3)-Ganancias inicilizadas a valores base");
	
		Partida.CostesBaseDeMercenarios.Add (20f);
		Partida.CostesBaseDeMercenarios.Add (100f);
		Partida.CostesBaseDeMercenarios.Add (1000f);
		Partida.CostesBaseDeMercenarios.Add (10000f);
		Debug.Log ("Inicializar Mercenarios(0.4)-Costes bases inicializados");
	
		Partida.TimingDeMercenarios.Add (2f);
		Partida.TimingDeMercenarios.Add (30f);
		Partida.TimingDeMercenarios.Add (60f);
		Partida.TimingDeMercenarios.Add (120f);

	}
    //--------------------------------------
    //Controladores de dinero por click
   

    /*public static void AumentarDineroClick()
    {
		if (Partida.Cash >= Partida.CosteMejoraClick)
        {
			Partida.Cash = Partida.Cash - Partida.CosteMejoraClick;
			Partida.CosteMejoraClick = 3 * Partida.CosteMejoraClick;
            Partida.DineroClick = 2 * Partida.DineroClick;
            Debug.Log("------------------------------------------");
			Debug.Log("Ahora recibes: "+Partida.DineroClick+" por click");
           
			Debug.Log("Pero el coste de la proxima compra es: "+Partida.CosteMejoraClick);
           
            Debug.Log("------------------------------------------");

        }
    }*/

    
	//Fechas
	public static float CalculoDeTiempo(System.DateTime a){
		Fecha2 = System.DateTime.Now.Subtract(a);
		Debug.Log ("Ha pasado "+Fecha2+" Tiempo");
	    return	(float)Fecha2.TotalSeconds;
			
	}

	public static  int CalculoYAumentoDeDinero(float tiempoPasado){
		int i = 0;
		int numEnero=0;
		float numDecimal;
		float dineroGanadoPorMercenario;
		string numStr;
		Debug.Log("Cargar Partida(1.71)-comienzo de bucle calcula dinero ganado");
		while(i<Partida.GananciasDeMercenarios.Count){

			Debug.Log("Cargar Partida(1.71"+i+")-Vuelta del mercenario "+i+" en el bucle");
			dineroGanadoPorMercenario = (Partida.GananciasDeMercenarios[i]/Partida.TimingDeMercenarios[i]) *(Partida.NivelDeMercenarios[i]*Partida.CoeficienteDeCostesDeMercenarios[i])* tiempoPasado;
		//Esta parte de aqui separa la parte decimal de la parte entera
			dineroGanadoPorMercenario=dineroGanadoPorMercenario+0.1f;
			 numStr = dineroGanadoPorMercenario.ToString();
		
			numEnero = numEnero+int.Parse(numStr.Split('.')[0]);
			numDecimal = float.Parse( numStr.Split('.')[1].Substring(0,1));

			if(numDecimal>6){
				numEnero++;
			}
		
			i++;
		}
		Debug.Log("Cargar Partida(1.72)-fin de bucle calcula dinero ganado");
		Debug.Log(numEnero);
		Partida.Cash=Partida.Cash+new BigInteger(numEnero.ToString());
		Debug.Log("Cargar Partida(1.73)-dinero aumentado");
		return 0;
	}
}