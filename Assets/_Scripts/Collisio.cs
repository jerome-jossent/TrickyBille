using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Collisio : MonoBehaviour
{
    Gamepad gamepad;

    public void GetController()
    {
        gamepad = GameObject.Find("Scripts Manager").GetComponent<_controller>().gamepad;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gamepad == null) GetController();
        //https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/api/UnityEngine.InputSystem.Haptics.IDualMotorRumble.html#UnityEngine_InputSystem_Haptics_IDualMotorRumble_SetMotorSpeeds_System_Single_System_Single_

        float left = 0f;
        float right = 0.2f;
        gamepad.SetMotorSpeeds(left, right);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (gamepad == null) GetController();
        //https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/api/UnityEngine.InputSystem.Haptics.IDualMotorRumble.html#UnityEngine_InputSystem_Haptics_IDualMotorRumble_SetMotorSpeeds_System_Single_System_Single_

        float left = 0f;
        float right = 0f;

        gamepad.SetMotorSpeeds(left, right);
    }

}
