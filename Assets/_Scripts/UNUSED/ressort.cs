using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ressort : MonoBehaviour
{
    public KeyCode touche;
    public float power;
    Rigidbody rb;

    bool hop;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (UnityEngine.InputSystem.Keyboard.current.yKey.wasPressedThisFrame)
        {
            hop = true;
        }
    }

    void FixedUpdate()
    {
        if (hop)
        {
            rb.AddForce(new Vector3(0, 1, 0) * power, ForceMode.Impulse);
            Debug.Log("paf");
            hop = false;
        }
    }
}