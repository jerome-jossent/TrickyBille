using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class _1_pont : MonoBehaviour
{
    [SerializeField] GameObject Morceau1, Morceau2, Morceau3;
    public float coeff_degrees;
    public float valbrute;
    public float val;

    Gamepad gamepad;

    private void Update()
    {
        if (gamepad == null) GetController();

        valbrute = Math.Abs(gamepad.rightTrigger.ReadValue());
        val = coeff_degrees * (valbrute - 0.5f) * 2;

        Morceau1.transform.localRotation = Quaternion.Euler(0, 0, val);
        Morceau2.transform.localRotation = Quaternion.Euler(0, 0, -val);
        Morceau3.transform.localRotation = Quaternion.Euler(0, 0, val);
    }

    public void GetController()
    {
        gamepad = GameObject.Find("Scripts Manager").GetComponent<_controller>().gamepad;
    }
}
