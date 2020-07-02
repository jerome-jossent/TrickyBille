using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class _5_bis_saut : MonoBehaviour
{
    public Vector3 direction;
    public float power;
    bool hop;
    public Collider other;
    public Animator animationPoussoir;
    Gamepad gamepad;

    private void Start()
    {
        direction = transform.localRotation * direction;
    }

    private void Update()
    {
        if (gamepad == null) GetController();
        hop = UnityEngine.InputSystem.Keyboard.current.yKey.wasPressedThisFrame ||
              gamepad.aButton.wasPressedThisFrame;
        if (hop)
            animationPoussoir.SetTrigger("hop"); //https://www.studica.com/blog/unity-tutorial-animator-controllers
    }
    public void GetController()
    {
        gamepad = GameObject.Find("Scripts Manager").GetComponent<_controller>().gamepad;
    }

    public void _OnTriggerStay()
    {
        Debug.Log(other.gameObject.name);
        if (hop)
            other.attachedRigidbody.AddForce(direction * power, ForceMode.Impulse);
    }
}
