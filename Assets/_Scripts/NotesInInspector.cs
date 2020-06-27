using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesInInspector : MonoBehaviour
{
    [TextArea(1,1)]
    public string Objet = "";

    [TextArea(3, 20)]
    public string Notes = "";
}
