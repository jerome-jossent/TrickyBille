using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class _6_labyrinthe_cache : MonoBehaviour
{
    [SerializeField] GameObject Plateau_rotule;
    [SerializeField] GameObject toit;
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

        valbrute = _sm._IM.i_6_labyrinthe_cache;
        Plateau_rotule.transform.localRotation = Quaternion.Euler(
            plateau_positionInit.x + valbrute.x * coeff_V,
            plateau_positionInit.y,
            plateau_positionInit.z + valbrute.y * coeff_H);

        int transparent = 0;
        if (_sm._IM.i_6_labyrinthe_cache_TransparentPlus)
            transparent++;
        if (_sm._IM.i_6_labyrinthe_cache_TransparentMoins)
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