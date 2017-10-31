//
// GanarCash.cs
//
// Author:
//       Roldan <Rodis2@hotmail.com>
//
// Date 2016 Roldan

using UnityEngine;
using System.Collections;

public class GanarCash : MonoBehaviour {

	//aunmenta el dinero en la cantidad de DineroClick(dinero per click)
    void OnMouseDown()
    {
      
		Partida.Cash = Partida.Cash + Partida.DineroClick;
    }
}
