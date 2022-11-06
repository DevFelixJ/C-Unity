using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject buttonGameObject;
    private Animator anim;

    //Cuando le des click al boton Aparato Digestivo, se activará los GameObject del cuadro del dialogo,
    //deshabilitando que se pueda interactuar con el boton.
    //y el player empezará la animación
    public void TriggerDialogue()
    {
        anim = GetComponent<Animator>();
        dialogueBox.SetActive(true);
        buttonGameObject = GameObject.FindGameObjectWithTag("TestButton");
        buttonGameObject.GetComponent<Button>().interactable = false;
        anim.SetBool("isDancing", true);



    }

     

   
}
