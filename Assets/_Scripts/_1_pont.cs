using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class _1_pont : MonoBehaviour
{
    [SerializeField] GameObject Morceau1, Morceau2, Morceau3;
    public float coeff_degrees;
    public float valbrute;
    public float val;
    SCRIPTSMANAGER _sm;
    void Awake()
    {
        _sm = GameObject.Find("Scripts Manager").GetComponent<SCRIPTSMANAGER>();
    }
    private void Update()
    {
        if (_sm._IM.controller.gamepad == null) return;

        valbrute = Math.Abs(_sm._IM.i_1_pont);
        val = coeff_degrees * (valbrute - 0.5f) * 2;

        Morceau1.transform.localRotation = Quaternion.Euler(0, 0, val);
        Morceau2.transform.localRotation = Quaternion.Euler(0, 0, -val);
        Morceau3.transform.localRotation = Quaternion.Euler(0, 0, val);
    }

}