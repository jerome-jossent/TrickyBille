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
    SCRIPTSMANAGER _sm;
    void Awake()
    {
        _sm = GameObject.Find("Scripts Manager").GetComponent<SCRIPTSMANAGER>();
    }
    private void Start()
    {
        plateau_positionInit = Plateau_rotule.transform.localRotation.eulerAngles;
    }

    void Update()
    {
        if (_sm._IM.controller.gamepad == null) return;

        valbrute = _sm._IM.i_4_plateau_inverse;
        Plateau_rotule.transform.localRotation = Quaternion.Euler(
            plateau_positionInit.x + valbrute.x * coeff_V,
            plateau_positionInit.y,
            plateau_positionInit.z + valbrute.y * coeff_H);
    }
}