﻿using System;
using UnityEngine;

public class _1_pont : MonoBehaviour
{
    [SerializeField] GameObject Morceau1, Morceau2, Morceau3;
    public string InputAxe;
    public float coeff_degrees;
    public float valbrute;
    public float val;

    private void Update()
    {
        valbrute = Math.Abs(Input.GetAxis(InputAxe));
        val = coeff_degrees * (valbrute - 0.5f)*2;

        Morceau1.transform.localRotation = Quaternion.Euler(0, 0, val );
        Morceau2.transform.localRotation = Quaternion.Euler(0, 0, -val );
        Morceau3.transform.localRotation = Quaternion.Euler(0, 0, val );
    }
}