//
// Tienda.cs
//
// Author:
//       Roldan <Rodis2@hotmail.com>
//
// Date 2016 Roldan

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Numeros;
using System;

public class Yonky : MonoBehaviour {
	public List<BigInteger> CosteYonky= new List<BigInteger>();
	public List<BigInteger> MejoraYonky= new List<BigInteger>();
    public int Coste;
    public int NivelYonky;
	float cash;
	// Use this for initialization
	void Start () {
		/*CosteYonky.Add (new BigInteger(20));
		CosteYonky.Add (3000);
		CosteYonky.Add (10000);
		CosteYonky.Add (20000);
		CosteYonky.Add (50000);
		CosteYonky.Add (100000);
		CosteYonky.Add (200000);
		CosteYonky.Add (1000000);
		CosteYonky.Add (100000000);
		MejoraYonky.Add (1);
		MejoraYonky.Add (10);
		MejoraYonky.Add (20);
		MejoraYonky.Add (1);
		MejoraYonky.Add (2);
		MejoraYonky.Add (7);
		MejoraYonky.Add (2);
		MejoraYonky.Add (5);
		MejoraYonky.Add (10);*/
		 NivelYonky = Partida.NivelYonky;
        Coste = 50*(NivelYonky);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
		Debug.Log (NivelYonky);
        AumentarDineroClick();
        Debug.Log(NivelYonky);
    }
	 void AumentarDineroClick()
    {
        if (Partida.Cash >= Coste)
        {
            Partida.Cash = Partida.Cash - Coste;
            Partida.DineroClick = Partida.DineroClick + 1;
            NivelYonky++;
            Partida.NivelYonky++;
            Coste = (NivelYonky) * (50);
           
        }


            }
	//recuerda este primer if, es pork no hay mas cosas a partir de nivel 9
	/*{ if (NivelYonky > 10) {
			Debug.Log ("Ami ni me mires, emparanoya a Keli");
		}
	else// if (Partida.Cash >= this.CosteYonky[NivelYonky])
	{if (Partida.Cash >= this.CosteYonky [NivelYonky]) {
			
				Partida.Cash = Partida.Cash - this.CosteYonky [NivelYonky];		
				if (NivelYonky < 3) {
					Debug.Log ("nivel yonky menor 3");
					Partida.DineroClick = Partida.DineroClick + new BigInteger (MejoraYonky [NivelYonky].ToString ());
				} else if (NivelYonky < 6) {
					Debug.Log ("nivel yonky menor 6");
			
					BigInteger aux = (Partida.DineroClick % MejoraYonky [NivelYonky]);

					Partida.DineroClick = Partida.DineroClick + (aux);
				} else if (NivelYonky < 10) {
					Debug.Log ("nivel yonky menor 10");
			
					BigInteger aux = Partida.DineroClick * MejoraYonky [NivelYonky];
					Partida.DineroClick = Partida.DineroClick * aux;
				}
				NivelYonky++;
				Partida.NivelYonky++;
			}

			Debug.Log("------------------------------------------");
			Debug.Log("Ahora recibes: "+Partida.DineroClick+" por click");

			Debug.Log("Pero el coste de la proxima compra es: "+this.CosteYonky[NivelYonky]);

			Debug.Log("------------------------------------------");

		}
	}*/






}
