using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig : MonoBehaviour
{
    public _2_bras_aimante _ba;

    private void OnTriggerEnter(Collider other)
    {
        _ba.Trig(this, other.gameObject);
    }
}
