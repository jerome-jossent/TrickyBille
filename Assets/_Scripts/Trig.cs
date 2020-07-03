using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig : MonoBehaviour
{
    public _2_bras_aimante _ba;

    private void OnTriggerEnter(Collider other)
    {
        _ba.TrigEnter(this, other.gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        _ba.TrigStay(this, other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        _ba.TrigExit(this, other.gameObject);
    }
}