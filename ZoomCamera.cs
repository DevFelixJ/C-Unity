using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    //Ajustes de velocidad y limites del zoom en el eje Z(Profundidad)
    public float zoomSpeed = 10f;
    public float minZ = -5f;
    public float maxZ = -3;
    public float smoothTime = 0.3f;
    private float movePosition;
    private float smoothVelocity = 0;
    //Variables para controlar las posiciones de los ejes
    private float posX, posY, posZ;



    public void Start()
    {
        //Obtener los valores locales de los ejes X e Y.
        posX = transform.localPosition.x;
        posY = transform.localPosition.y;

        //Obtencion del valor del eje Z para poder realizar las modificaciones.
        movePosition = transform.localPosition.z;
        posZ = movePosition;

    }

    public void Update()
    {
        float wheel = Input.GetAxis("Mouse ScrollWheel");

        if (wheel != 0)
        {
            //Se establece el limite en el que se puede desplazar el eje Z.
            movePosition += wheel * zoomSpeed;
            movePosition = Mathf.Clamp(movePosition, minZ, maxZ);
        }
        //En cuanto la rueda del raton se mueva para hacer Zoom, se cumple la condicion.
        if (Mathf.Abs(movePosition - posZ) > 0.001f)
        {
            //Movimiento suavizado para que no sea brusco.
            posZ = Mathf.SmoothDamp(posZ, movePosition, ref smoothVelocity, smoothTime);

            //Movimiento del eje Z, dejando el valor local del eje X e Y para que no se altere.
            Vector3 targetPosition = new Vector3(posX, posY, posZ);
            transform.localPosition = targetPosition;
        }
    }
}
