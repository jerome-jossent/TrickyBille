using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class _Chrono : MonoBehaviour
{
    [SerializeField] GameObject AIGUILLE;
    [SerializeField] [Range(0, 1)] float val_aiguille_0_1;
    float val_aiguille_0_1_prec;
    [SerializeField] float angle_Min, angle_Max;
    [SerializeField] float angle;
    public float CHRONO = 60;

    // Update is called once per frame
    void Update()
    {
        if (val_aiguille_0_1_prec != val_aiguille_0_1)
        {
            angle = Map(val_aiguille_0_1, 0, 1, angle_Min, angle_Max);

            AIGUILLE.transform.localRotation = Quaternion.Euler(0, -angle, 0);

            val_aiguille_0_1_prec = val_aiguille_0_1;
        }
    }

    public float Map(float x, float x1, float x2, float y1, float y2)
    {
        var m = (y2 - y1) / (x2 - x1);
        var c = y1 - m * x1; // point of interest: c is also equal to y2 - m * x2, though float math might lead to slightly different results.

        return m * x + c;
    }

    internal void _ChronoUpdate(float T)
    {
        //T commence à 0 et augmente
        float v = (CHRONO - T) / CHRONO;
        if (v < 0)
            v = 0;

        val_aiguille_0_1 = v;
    }
}
