using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject continueGameObject;
    public GameObject buttonBack;
    private Animator anim;
    public Dialogue dialogue;
    private GameObject player;
    public GameObject finishButton;
    

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
       //Se inserta en una cola las frases indicadas en la clase Dialogue y empieza la lectura llamando a la funcion
        sentences = new Queue<string>();
        StartDialogue(dialogue);



    }

    //Este metodo adquiere las frases de la clase Dialogue y se hace un foreach para meterlos en cola
    public void StartDialogue(Dialogue dialogue)
    {
        continueGameObject.SetActive(true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }

        DisplayNextSentence();
    }
    //Este metodo hace que modifique el texto del GameObject y lo muestre hasta que llegue un conteo a la ultima frase
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }


    //Este metodo hace que oculte el GameObject de continuar y se muestra el de finalizar. \
    //Tambien aparece el boton de repetir para que se vuelva a repetir las frases
    //Y hacemos que la animacion se detenga

    void EndDialogue()
    {
        continueGameObject.SetActive(false);
        buttonBack.SetActive(true);
        player = GameObject.Find("Player");
        anim = player.GetComponent<Animator>();
        anim.SetBool("isDancing", false);
        finishButton.SetActive(true);
    }

    //Este metodo hace que se vuelva a repetir las frases.
    public void RepeatDialogue()
    {
        anim.SetBool("isDancing", true);
        buttonBack.SetActive(false);
        continueGameObject.SetActive(true);
        finishButton.SetActive(false);
        StartDialogue(dialogue);

    }

    //Este metodo hace que al darle al boton finalizar se lleve a otra escena
    public void FinishDialogue()
    {
        SceneManager.LoadScene("SampleScene");



    }

    }

