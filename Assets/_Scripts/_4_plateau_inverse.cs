using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class _4_plateau_inverse : MonoBehaviour
{
    [SerializeField] GameObject Plateau_rotule;
    public float coeff_H, coeff_V;
    public Vector2 valbrute;
    public Vector3 plateau_positionInit;
    Gamepad gamepad;

    private void Start()
    {
        plateau_positionInit = Plateau_rotule.transform.localRotation.eulerAngles;
    }

    void Update()
    {
        if (gamepad == null) return;

        valbrute = gamepad.rightStick.ReadValue();
        Plateau_rotule.transform.localRotation = Quaternion.Euler(
            plateau_positionInit.x + valbrute.x * coeff_V,
            plateau_positionInit.y,
            plateau_positionInit.z + valbrute.y * coeff_H);
    }

    public void GetController()
    {
        gamepad = GameObject.Find("Scripts Manager").GetComponent<_controller>().gamepad;
    }
}
