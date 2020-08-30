using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Fin : MonoBehaviour
{
    SCRIPTSMANAGER _sm;

    public Collider other;
    void Awake()
    {
        _sm = GameObject.Find("Scripts Manager").GetComponent<SCRIPTSMANAGER>();
    }
    public void _OnTriggerStay()
    {
        //Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "Bille")        
            _sm._gameManager._Finish();        
    }
}
