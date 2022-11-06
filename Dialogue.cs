using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Se crea una clase para poder guardar las frases del array para poder recuperarlo
[System.Serializable]
public class Dialogue
{
    public string name;
    [TextArea(3, 10)]
    public string[] sentences;

}