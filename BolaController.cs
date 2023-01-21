using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaController : MonoBehaviour
{
    public GameObject Bola;//El gameobject de la bola
    Vector3 posicionInicial = new Vector3(4.82f, 2.2f, -4.58f);//Posicion inicial de la bola
    Vector3 posicion2 = new Vector3(-2.92f, 2.2f, -4.62f);//Segunda posicion
    Vector3 posicion3 = new Vector3(-2.92f, 2.2f, 3.07f);//Tercera posicion
    Vector3 posicion4 = new Vector3(4.94f, 2.2f, 3.08f);//Cuarta posicion
    void Start()
    {
        Bola.transform.position = posicionInicial;//Al iniciar la escena colocamos la bola en la posicion inicial
    }

    // Update is called once per frame
    void Update()
    {
        moverBola();//Llamamos al metodo.
        
    }

    void moverBola()//Creamos un metodo para que haga los if y modifique la posicion de la bola dependiendo de donde se encuentre
    {
       

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Bola.transform.position == posicionInicial)//Si la Bola esta en la posicion Inicial indicada en la variable, cambia a la 2
            {
                Bola.transform.position = posicion2;
            }
            else if(Bola.transform.position == posicion2)//Si la bola esta en la posicion 2, cambia a la 3
            {
                Bola.transform.position = posicion3;
            }
            else if(Bola.transform.position == posicion3)//Si la bola esta en la posicion 3, cambia a la 4
            {
                Bola.transform.position = posicion4;
            }
            else                                        //Si no, da por hecho que esta en la posicion 4,
                                                        //entonces hacemos que vuelva a la posicion Inicial para que vuelva al primer if de las posiciones
                                                        //y se repita el proceso                            
            {
                Bola.transform.position = posicionInicial;
            }
        }
    }
}
