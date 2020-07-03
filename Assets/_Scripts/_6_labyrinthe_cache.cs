using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class _6_labyrinthe_cache : MonoBehaviour
{
    [SerializeField] _controller controller;
    [SerializeField] GameObject Plateau_rotule;
    public float coeff_H, coeff_V;
    public Vector2 valbrute;
    public Vector3 plateau_positionInit;

    private void Start()
    {
        plateau_positionInit = Plateau_rotule.transform.localRotation.eulerAngles;
    }

    void Update()
    {
        if (controller.gamepad == null) return;

        valbrute = controller.gamepad.leftStick.ReadValue();
        Plateau_rotule.transform.localRotation = Quaternion.Euler(
            plateau_positionInit.x + valbrute.x * coeff_V,
            plateau_positionInit.y,
            plateau_positionInit.z + valbrute.y * coeff_H);
    }
}