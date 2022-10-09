using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionObjeto : MonoBehaviour
{
    private int layer = 8, layerMask;

    private float rotationRate = 0.8f;
    private bool touchAnywhere;
    private float m_previousX;
    private Camera m_camera;
    private bool m_rotating = false;

    private void Awake()
    {
        //Transformar el numero de la capa a bits con desplazamiento para poder realizar el raycast
        layerMask = (1 << layer);
        m_camera = Camera.main;
    }
    private void Update()
    {
        //Se realiza estas condiciones para que a la hora de rotar el objeto no se pare en seco al cambiar de cara del cubo y detectar si esta usando el raton
        //o el touch del dispositivo Android.
        if (!touchAnywhere)
        {
            if (!m_rotating)
            {
                RaycastHit hit;
                Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
                if (!Physics.Raycast(ray, out hit, 1000, layerMask))
                {
                    return;
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            m_rotating = true;
            m_previousX = Input.mousePosition.x;
        }
        // get the user touch input

        //Al mantener pulsado el raton primario(click izquierdo) se cumple la condicion de que se puede rotar el objeto
        if (Input.GetMouseButton(0))
        {

            //Logica para capturar el valor de la rotacion del eje X
            var deltaX = -(Input.mousePosition.x - m_previousX) * rotationRate;

            //Modificar la posicion X con un transform para que se actualice la rotacion
            transform.Rotate(0, deltaX, 0, Space.World);

            //Se actualiza la rotacion del eje X
            m_previousX = Input.mousePosition.x;
        }
        //Al dejar de mantener pulsado el boton primario(Click izquierdo) Se cumple la condicion de que ya no hay que rotar el objeto
        if (Input.GetMouseButtonUp(0))
            m_rotating = false;
    }
}
