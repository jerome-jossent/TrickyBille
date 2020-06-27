using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _3_rails_ecartes : MonoBehaviour
{
    public GameObject Rail_Gauche, Rail_Droite;

    public string InputAxe;
    public float valbrute;
    public float val;

    public float degMax;


    void Update()
    {
        valbrute = Math.Abs(Input.GetAxis(InputAxe));
        val = valbrute * degMax;

        Rail_Gauche.transform.localRotation = Quaternion.Euler(0, val, 0);
        Rail_Droite.transform.localRotation = Quaternion.Euler(0, -val, 0);
    }
}
