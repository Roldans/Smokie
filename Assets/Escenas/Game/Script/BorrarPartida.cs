//
// BorrarPartida.cs
//
// Author:
//       Roldan <Rodis2@hotmail.com>
//
// Date 2016 Roldan

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BorrarPartida : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
		Partida.BorrarPartida();
       
        SceneManager.LoadScene(0);
     
    }
}
