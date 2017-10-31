using UnityEngine;
using System.Collections;

public class ContadoresAnimacionMercenarios : MonoBehaviour {
    static public float mercenario0;
	// Use this for initialization
	void Start () {
        mercenario0 = 5;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(mercenario0);
        mercenario0 -= Time.deltaTime;
       // Debug.Log(mercenario0);
        if (mercenario0 <= 0)
        {

            mercenario0 = 5;
        }
    }
}
