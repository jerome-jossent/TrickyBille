using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions_Manager : MonoBehaviour
{
    public enum interaction_type { x360, touchScreen, KeyboardMouse, VR}
    public interaction_type _interaction_Type;
    public _controller controller;

    public float i_1_pont;//-1 à 1
    public Vector2 i_2et7_bras_aimante;//-1 à 1
    public float i_3_rails_ecartes;//-1 à 1
    public Vector2 i_4_plateau_inverse;//-1 à 1
    public bool i_5_saut;
    public Vector2 i_6_labyrinthe_cache;//-1 à 1
    public bool i_8_lancement_bras_cloche;
    public bool i_8_lancement_bras_cloche_RESET;

    public bool i_6_labyrinthe_cache_TransparentPlus;
    public bool i_6_labyrinthe_cache_TransparentMoins;
   // public bool i_8_lancement_bras_cloche;

    SCRIPTSMANAGER _sm;
    void Awake()
    {
        _sm = GameObject.Find("Scripts Manager").GetComponent<SCRIPTSMANAGER>();
    }

    void Update()
    {
        switch (_interaction_Type)
        {
            case interaction_type.x360:
                i_1_pont = controller.gamepad.rightTrigger.ReadValue();
                i_2et7_bras_aimante = controller.gamepad.rightStick.ReadValue();
                i_3_rails_ecartes = controller.gamepad.leftStick.ReadValue().y;
                i_4_plateau_inverse = controller.gamepad.rightStick.ReadValue();
                i_5_saut = controller.gamepad.aButton.wasPressedThisFrame;
                i_6_labyrinthe_cache = controller.gamepad.leftStick.ReadValue();

                i_6_labyrinthe_cache_TransparentPlus = controller.gamepad.dpad.up.wasPressedThisFrame;
                i_6_labyrinthe_cache_TransparentMoins = controller.gamepad.dpad.down.wasPressedThisFrame;

                i_8_lancement_bras_cloche = controller.gamepad.aButton.wasPressedThisFrame;
                i_8_lancement_bras_cloche_RESET = controller.gamepad.selectButton.wasPressedThisFrame;
                break;
            case interaction_type.touchScreen:
                break;
            //case interaction_type.KeyboardMouse:
            //    break;
            //case interaction_type.VR:
            //    break;
        }
    }
}
