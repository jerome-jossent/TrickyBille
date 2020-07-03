using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Collisio : MonoBehaviour
{
    [SerializeField] _controller controller;


    private void OnCollisionEnter(Collision collision)
    {
        if (controller.gamepad == null) return;
        //https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/api/UnityEngine.InputSystem.Haptics.IDualMotorRumble.html#UnityEngine_InputSystem_Haptics_IDualMotorRumble_SetMotorSpeeds_System_Single_System_Single_

        float left = 0f;
        float right = 0.2f;
        controller.gamepad.SetMotorSpeeds(left, right);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (controller.gamepad == null) return;
        //https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/api/UnityEngine.InputSystem.Haptics.IDualMotorRumble.html#UnityEngine_InputSystem_Haptics_IDualMotorRumble_SetMotorSpeeds_System_Single_System_Single_

        float left = 0f;
        float right = 0f;
        controller.gamepad.SetMotorSpeeds(left, right);
    }
}