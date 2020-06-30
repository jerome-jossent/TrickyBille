using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spring : MonoBehaviour
{
    public Vector3 direction;
    public float power;
    bool hop;
    private void Update()
    {
        hop = UnityEngine.InputSystem.Keyboard.current.yKey.wasPressedThisFrame;
    }

    private void OnTriggerStay(Collider other)
    {
        if (hop)
            other.attachedRigidbody.AddForce(direction * power, ForceMode.Impulse);
    }
}
