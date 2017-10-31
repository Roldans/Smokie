//
// Mercenario.cs
//
// Author:
//       Roldan <Rodis2@hotmail.com>
//
// Date 2016 Roldan
/*Guia Añadir un nuevo mercenario:
 * -En Libreria.InicializarMercenarios(), debes añadir a mano los valores basicos del mercenario, dado que se estos se inicializan cada vez arranca el juego
 * -
 * 
 * 
 * 
 * 
 * 
 */


using UnityEngine;
using System.Collections;
using Numeros;
using UnityEngine.UI;


public class Mercenario : MonoBehaviour
{
    /*un unico script para los 3 mercenarios
	 * se identifica el mercenario por su numero[1,2,3]
	 * se comprueba si el mercenario activo a traves de un metodo de la libreria, esta simplemente comprueba si el nivel es mayor que 0
	 * 
	 */
    public GameObject BarraProgreso;
    private Animator ani; //esta variable guardará el animator
    public Text ProduccionGui;
    public int NMercenario;
    public Text CosteGui;
    public Text NivelGui;
    private float CosteBase;
    private float CoeficienteCoste;
    public float NivelMercenario;
    private float Ganancias;
    private BigInteger CosteEnNivel;
    public float contador; 

    private float aux2;
    private float timing;
    public bool repro = false;

    /*En Start comprobamos si esta activo y en funcion del k sea se le añade un timing y se invoca al invokerepeating, 
	/en caso de no estar activo no se hace nada, despues se actualizan los valores locales
	*/

    void Start()
    {


        

         ani = BarraProgreso.GetComponent<Animator>();
        Debug.Log("Mercenario " + NMercenario + ".(0.2)-Iniciando variables privadas del mercenario");
        timing = 5;//Partida.TimingDeMercenarios[NMercenario];
        CosteBase = Partida.CostesBaseDeMercenarios[NMercenario];
        CoeficienteCoste = Partida.CoeficienteDeCostesDeMercenarios[NMercenario];
        NivelMercenario = Partida.NivelDeMercenarios[NMercenario];
        Ganancias = Partida.GananciasDeMercenarios[NMercenario];



        Debug.Log("Mercenario " + NMercenario + ".(0.0)-Start");

        Debug.Log("Mercenario " + NMercenario + ".(0.1)-Comprobacion de mercenario activo");
        if (Libreria.ComprobarMercenarioActivo(NMercenario))
        {
            aux2 = Mathf.Round(CosteBase * CoeficienteCoste * NivelMercenario);
            CosteEnNivel = new BigInteger(aux2.ToString());

            InvokeRepeating("AumentarCashMercenario", timing, timing);
            ani.SetBool("AnimationOn", true);
            repro = true;
            ani.SetFloat("Multiplicador", 1 / timing);
            ContadoresAnimacionMercenarios.mercenario0 = 5;
            Debug.Log("Mercenario " + NMercenario + ".(0.11)-Mercenario activo,Lanzado InvokeRepeating(AumentarCash)");
        }
        else
        {
            
            CosteEnNivel = new BigInteger(CosteBase.ToString());
            Debug.Log("Mercenario " + NMercenario + ".(0.12)-Mercenario no activo");
        }

        Debug.Log("Inicializar Mercenarios(0.4)-Costes bases inicializados");
        Debug.Log("Mercenario " + NMercenario + ".(0.3)-Fin de Start");
        Debug.Log("-------------------------------Fin De Automatico" + NMercenario + ".Start-------------------------------");
        CosteGui.text = CosteEnNivel.ToString();
        NivelGui.text = NivelMercenario.ToString();
        ProduccionGui.text = Mathf.Round(NivelMercenario * CoeficienteCoste * Ganancias).ToString();



    }
    void Update ()
    {

        if (repro)
        {
            if (ani.GetBool("AnimationOn") == false)
            {
                Debug.Log(ContadoresAnimacionMercenarios.mercenario0/5f);

                ani.Play("MercenariosProdcuccion",-1, ContadoresAnimacionMercenarios.mercenario0);
                
                ani.SetFloat("Multiplicador", 1/5f);
               ani.SetBool("AnimationOn", true);
               
            }
           
        }

    }


    //clickando en el se aumenta de nivel
    void OnMouseDown()
    {

        ContratarMercenario();


    }
    //aumenta el dinero, usado por el InvokeRepeating()
    private void AumentarCashMercenario()
    {
        //El calculo de Ganancia actual * coeficiente es substituido por la ganancia base *(coeficiente*nivel)

        aux2 = Mathf.Round(NivelMercenario * CoeficienteCoste * Ganancias);
        Partida.Cash = Partida.Cash + new BigInteger(aux2.ToString());
        //Debug.Log(Partida.Cash);
        if (repro)
        {

            //ani.SetBool("AnimationOn", true);
            // Application.LoadLevel("Prueba");


        }



    }
    //aumentar nivel de mercenario
    private void ContratarMercenario()
    {


        Debug.Log("Mercenario " + NMercenario + ".(1.0)-ContratarMercenario");
        Debug.Log("Mercenario " + NMercenario + ".(1.1)-Comprobacion de Mercenario activo");

        //comprobamos si hay dinero suficiente
        if (Partida.Cash >= (CosteEnNivel))
        {

            Debug.Log("Mercenario " + NMercenario + ".(1.111)-El valor de Cash es valido");
            //restamos el coste al dinero k tenemos
            Partida.Cash = Partida.Cash - CosteEnNivel;

            Debug.Log("Mercenario " + NMercenario + ".(1.112)-Restado coste a Cash");
            //actualizamos el coste en nivel
            aux2 = Mathf.Round(NivelMercenario * CoeficienteCoste * Ganancias);
            CosteEnNivel = new BigInteger(aux2.ToString());
            Debug.Log("Mercenario " + NMercenario + ".(1.113)-Aumentado el nivel del mercenario");
            //si el mercenario no esta activo se activa el invokeRepeating
            if (!Libreria.ComprobarMercenarioActivo(NMercenario))
            {
                Debug.Log("Mercenario " + NMercenario + ".(1.11)-Mercenario activo");
                InvokeRepeating("AumentarCashMercenario", timing, timing);
          //-------------------------------------------
                repro = true;
                ani.SetFloat("Multiplicador", 1 / 5f);
                ContadoresAnimacionMercenarios.mercenario0 = 5;
                ani.SetBool("AnimationOn", true);
            //******************************************
                Debug.Log("Mercenario " + NMercenario + ".(1.)-Lanzado el InvokeRepeating(AumentarCash) ");
            }
            //subimos el niveo al mercenario tanto en el script local como en la lista estatica
            NivelMercenario = NivelMercenario + 1;
            Partida.NivelDeMercenarios[NMercenario] = NivelMercenario;
            aux2 = Mathf.Round((NivelMercenario * CosteBase * CoeficienteCoste) + 1);
            CosteEnNivel = new BigInteger(aux2.ToString());
        }
        else
        {

            Debug.Log("Mercenario " + NMercenario + ".(1.111)-El valor de Cash no es valido");

        }
        Debug.Log("Mercenario " + NMercenario + ".(1.0)-Fin de ContratarMercenario");


        CosteGui.text = CosteEnNivel.ToString();
        NivelGui.text = NivelMercenario.ToString();
        ProduccionGui.text = Mathf.Round(NivelMercenario * CoeficienteCoste * Ganancias).ToString();



    }





}
