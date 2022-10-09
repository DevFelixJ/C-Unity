using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DragDrop3D : MonoBehaviour
{
    //Se crea una variable para que se obtenga la informacion del GameObjec, en este caso el Collider.
    private GameObject selectedObject;



   private void Update()
    {
        //Si le das click entramos en la siguiente funcion
        if (Input.GetMouseButtonDown(0))
        {
            //Esto es una condicion en el que si no se ha hecho el Hit del Raycast,darle con el click al GameObject,
            //Este lo selecciona y llama al metodo de abajo para poder obtener la informacion del GameObject a traves del RayCast.
            if(selectedObject == null)
            {
                RaycastHit hit = CastRay();
                //Al llegar aqui, significa que ya le hemos dado un click al GameObject, por lo cual va a coger el Collider
                //para luego poder desplazarlo
                if(hit.collider != null)
                {
                    //Para que no haya un desastre monumental, se le indica a los GameObjects que pertenecen a la etiqueta "drag" 
                    //Para que a la hora de jugar no se arrastre cualquier GameObject.
                    if (!hit.collider.CompareTag("drag"))
                    {
                        return;
                    }
                    //Con lo dicho anteriormente, obtiene el collider para luego desplazarlo
                    selectedObject = hit.collider.gameObject;
                    
                }
            }else
            //Este else actua para que cuando le demos click para dejar el GameObject, el selectedObject, se libere
            //En terminos de programacion pasaria de selectedObject = hit.collider.gameObject a = null;
            //Tambien, obtiene en la coordenada donde lo hemos dejado para que se quede en el sitio.
            {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z);

                selectedObject = null;

            }
        }
        //Esta condicion indica que ya que has obtenido el Collider del gameObject al hacer click, indicado en el anterior if,
        //Puedas moverlo
        if(selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z);
        }
    }

    //Se hace un metodo en el que obtiene las coordenadas del mundo para cuando le des click, sepa el hit a donde esta apuntando.
    private RaycastHit CastRay()
    {

        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x, 
            Input.mousePosition.y,
            Camera.main.farClipPlane);

        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

       return hit;
    }

}
