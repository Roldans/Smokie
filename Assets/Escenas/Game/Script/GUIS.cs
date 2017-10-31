//
// GUIS.cs
//
// Author:
//       Roldan <Rodis2@hotmail.com>
//
// Date 2016 Roldan

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIS : MonoBehaviour
{
	public float aux2;
    public Text CosteGui;
    // Use this for initialization
    void Start ()
	{

        
	}
	
	// Update is called once per frame
	void Update ()
	{
        
       CosteGui.text = Partida.Cash.ToString();
    }

	/*void OnGUI ()
	{ 
		string aux = Partida.Cash.ToString ();
		GUI.Label (new Rect (aux2, 0, 670, 70), aux);
		GUI.skin.label.fontSize = 50;
        
	}*/
}
