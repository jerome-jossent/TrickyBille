using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class _6_labyrinthe_cache : MonoBehaviour
{
    [SerializeField] _controller controller;
    [SerializeField] GameObject Plateau_rotule;
    [SerializeField] GameObject toit;
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

        int transparent = 0;
        if (controller.gamepad.dpad.up.wasPressedThisFrame)
            transparent++;
        if (controller.gamepad.dpad.down.wasPressedThisFrame)
            transparent--;

        if (transparent != 0)
        {
            Material m = toit.GetComponent<Renderer>().material;
            Color c = m.color;
            float a = c.a  + transparent * 0.1f;
            if (a > 1) a = 1;
            if (a < 0) a = 0;
            m.color = new Color(c.r, c.g, c.b, a);
        }
    }
}