using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ressort : MonoBehaviour
{
    public KeyCode touche;
    public float power;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(touche))
        if (UnityEngine.InputSystem.Keyboard.current.yKey.wasPressedThisFrame)
        {
            rb.AddForce(new Vector3(0, 1, 0) * power, ForceMode.Impulse);
            Debug.Log("paf");
        }
    }
}