using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Numeros;
public class Partida : MonoBehaviour {

    //Dinero Total
	public static Numeros.BigInteger Cash;
    //Ganancias por click
	public static Numeros.BigInteger DineroClick;
    //Coste de mejorar DineroClick
	public static Numeros.BigInteger CosteMejoraClick;
    //coste de mejorar el mercenario
	public static Numeros.BigInteger Contratar;
    //Lista de nivel de Mercenarios
	public static List<float> NivelDeMercenarios = new List<float>();
	//Lista de por cuanto hay que multiplicar el nivel de cada mercenario para ver cuanto cuesta
	public static List<float> CoeficienteDeCostesDeMercenarios = new List<float>();
	//Lista de por cuanto hay que multiplicar el nivel de cada mercenario para ver cuanto produce
	public static List<float> GananciasDeMercenarios = new List<float>();
	//Lista de coste bases de los mercenarios
	public static List<float> CostesBaseDeMercenarios = new List<float>();
	//Lista de los timings de los mercenarios
	public static List<float> TimingDeMercenarios = new List<float>();
	//Nivel Yonky
	public static int NivelYonky;


	static System.TimeSpan Fecha2;
	static float TiempoPasado;

/*
*Cargar la partida, lo primero mira si hay una partida guardada, en caso de que la haya, instancia "Cash","DineroClick", "CostemejoraCLick", los valores de las varibles son el valor guardado,
*Comprueba uno a uno los mercenarios a ver si estan guardados, recuerda que los valores basicos ya estan guardados en las variables, porque hemos instaciados lo mercenarios antes de cargar partida
*por ultimo se llama calculo de tiempo y calculoYAumentoDeDinero, que lo k hacen es calcular el tiempo desde la ultima conección y calcular cuanto habian producido tus mercenarios
*
*En caso de que no hubiera partida guardada, simplemente inicializa "Cash", "DineroClick" y "CosteMejoraClick" a sus valores basicos
*/

	public static void CargarPartida()
	{	
		
		Debug.Log ("Cargar Partida(1.1)-Partida guardada o no?");
		if (PlayerPrefs.HasKey("Cash"))
		{	
			Debug.Log ("Cargar Partida(1.2)-Partida Guardada");

			Partida.Cash =  new BigInteger(PlayerPrefs.GetString("Cash"));
			Partida.DineroClick = new BigInteger(PlayerPrefs.GetString("DineroClick"));
			Partida.CosteMejoraClick = new BigInteger(PlayerPrefs.GetString("CosteMejoraClick"));
			Partida.NivelYonky = PlayerPrefs.GetInt ("NivelYonky");
			Debug.Log ("Cargar Partida(1.3)-Variables BI cargadas");
			//revisa si hay un nivel de mercenario guardado
			for(int i=0;i<=Partida.NivelDeMercenarios.Count;i++){
				if (PlayerPrefs.HasKey ("Mercenario" + i.ToString())) {
					Partida.NivelDeMercenarios [i] = float.Parse (PlayerPrefs.GetString ("Mercenario"+i.ToString()));
				}
			}		
	

			Debug.Log ("Cargar Partida(1.4)-Nivel de Mercenarios cargados");
			print("Cargar Partida(1.5)-Comienza Calculo de tiempo pasado en segundos");
			TiempoPasado=Libreria.CalculoDeTiempo(System.DateTime.Parse(PlayerPrefs.GetString("Fecha")));
			Debug.Log("Cargar Partida(1.6)-Final de Calculo de tiempo pasado en segundos");
			Debug.Log("Cargar Partida(1.7)-Comienzo de calculo y aumento de dinero ganado durante el tiempo pasado");
			Libreria.CalculoYAumentoDeDinero(TiempoPasado);
			Debug.Log("Cargar Partida(1.8)-Final de calculo y aumento de dinero ganado durante el tiempo pasado");
		}
		else
		{
			Debug.Log ("Cargar Partida(1.2)-No hay partida Guardada");
			Partida.Cash = new BigInteger ("100");
			Partida.DineroClick = 1;
			Partida.CosteMejoraClick = 10;
            Partida.NivelYonky = 1;
            Debug.Log ("Cargar Partida(1.3)-Variables BI instaciadas a valores bases");
		}

	}



//Simplemente borra los datos almacenados en el 
	public static void BorrarPartida()
	{	 Debug.Log("Partida Borrada");
		PlayerPrefs.DeleteAll();

	}
}
