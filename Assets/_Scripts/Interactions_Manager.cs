using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions_Manager : MonoBehaviour
{
    public enum interaction_type { x360, touchScreen, mouse }
    public interaction_type _interaction_Type;
    public _controller controller;

    public float i_1_pont;//-1 à 1
    public Vector2 i_2et7_bras_aimante;//-1 à 1
    public float i_3_rails_ecartes;//-1 à 1
    public Vector2 i_4_plateau_inverse;//-1 à 1
    public bool i_5_saut;
    bool i_5_saut_precedent;
    public Vector2 i_6_labyrinthe_cache;//-1 à 1
    public bool i_8_lancement_bras_cloche;
    bool i_8_lancement_bras_cloche_precedent;
    public bool i_8_lancement_bras_cloche_RESET; 
    bool i_8_lancement_bras_cloche_RESET_precedent;


    public bool i_6_labyrinthe_cache_TransparentPlus;
    public bool i_6_labyrinthe_cache_TransparentMoins;

    public bool i_spawnToCheckpoint;
    public bool i_goToNextLevel;
    public bool i_spawnToDebugCheckpoint;

    public Touch_Stick touch_Stick_L;
    public Touch_Stick touch_Stick_R;

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

                i_spawnToCheckpoint = controller.gamepad.bButton.wasPressedThisFrame;
                i_goToNextLevel = controller.gamepad.leftShoulder.wasPressedThisFrame;
                i_spawnToDebugCheckpoint = controller.gamepad.yButton.wasPressedThisFrame;
                break;

            case interaction_type.touchScreen:
                i_2et7_bras_aimante = new Vector2(touch_Stick_R.x, touch_Stick_R.y);
                i_4_plateau_inverse = i_2et7_bras_aimante;

                if (i_5_saut && i_5_saut_precedent)
                    i_5_saut = false;
                i_5_saut_precedent = i_5_saut;

                i_6_labyrinthe_cache = new Vector2(touch_Stick_L.x, touch_Stick_L.y);

                if (i_8_lancement_bras_cloche && i_8_lancement_bras_cloche_precedent)
                    i_8_lancement_bras_cloche = false;
                i_8_lancement_bras_cloche_precedent = i_8_lancement_bras_cloche;

                if (i_8_lancement_bras_cloche_RESET && i_8_lancement_bras_cloche_RESET_precedent)
                    i_8_lancement_bras_cloche_RESET = false;
                i_8_lancement_bras_cloche_RESET_precedent = i_8_lancement_bras_cloche_RESET;


                break;
        }
    }

    public void i_1_pont_fromSlider(float value_0to1)
    {
        i_1_pont = value_0to1;
    }
    public void i_3_rails_ecartes_fromSlider(float value_0to1)
    {
        i_3_rails_ecartes = value_0to1;
    }
    public void i_5_saut_fromTouchSpace_Press()
    {
        i_5_saut = true;
    }
    public void i_8_lancement_bras_cloche_Press()
    {
        i_8_lancement_bras_cloche = true;
    }
    public void i_8_lancement_bras_cloche_RESET_Press()
    {
        i_8_lancement_bras_cloche_RESET = true;
    }



    float Map(float value, float low1, float high1, float low2, float high2)
    {
        return low2 + (value - low1) * (high2 - low2) / (high1 - low1);
    }
}
