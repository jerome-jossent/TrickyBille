using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BoardVersion : MonoBehaviour
{
    public enum BoardVersion_type { marron, rouge, orange, bleu }
    public BoardVersion_type _boardVersion_type;




    SCRIPTSMANAGER _sm;
    void Awake()
    {
        _sm = GameObject.Find("Scripts Manager").GetComponent<SCRIPTSMANAGER>();
    }

    public void _SetBoradVersion(BoardVersion_type boardVersion_Type)
    {
        //TODO
    }
}
