//
// PanelMov.cs
//
// Author:
//       Roldan <Rodis2@hotmail.com>
//
// Date 2016 Roldan

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelMov : MonoBehaviour {
	public  GameObject panel;
	public GameObject panel2;
	public GameObject panel3;
    public GameObject panel4;
//    public GameObject Merc;



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown(){

		AlzarPanel(panel);
		}
	public  void AlzarPanel(GameObject panel)
	{
		if (panel.name == "PanelJuego")
		{
			panel.SetActive (true);
			panel2.SetActive (false);
            panel3.SetActive (false);
            panel4.SetActive(false);

        } else if(  panel.name == "PanelMercenarios")
		{
			panel.SetActive (true);
            panel2.SetActive (false);
            panel3.SetActive (false);
            panel4.SetActive(false);
            //  Merc.SetActive(false);
        


        }
        else if(  panel.name == "PanelMenu")
		{	panel.SetActive(true);		
			panel2.SetActive(false);
			panel3.SetActive(false);
            panel4.SetActive(false);

        }
        else if (panel.name == "PanelBorrar")
        {
            panel.SetActive(true);
            panel2.SetActive(false);
            panel3.SetActive(false);
            panel4.SetActive(false);

        }

    }
    public static void AlzarPanel(GameObject panel, GameObject panel2, GameObject panel3)
    {
        Debug.Log("HEYEHEY");
            if (panel.name == "PanelJuego")
        {
            panel.SetActive(true);


            panel2.SetActive(false);

            panel3.SetActive(false);


        }
        else if (panel.name == "PanelMercenarios")
        {
            panel.SetActive(true);


            panel2.SetActive(false);

            panel3.SetActive(false);


        }
        else if (panel.name == "PanelMenu")
        {
            panel.SetActive(true);


            panel2.SetActive(false);

            panel3.SetActive(false);
        }

    }
}