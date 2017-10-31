using UnityEngine;
using System.Collections;

public class TurnOffMercenarios : MonoBehaviour {
    /*
    *La variable "Panel" es el Panel de mercenarios, que empieza inicializado para que arranque los InvokeRepeating
    *
    */

    public GameObject Panel;
    public GameObject Panel2;
    // Use this for initialization
    void Start () {
        Panel.SetActive(false);
        Panel2.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
