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
        if (Input.GetKeyDown(touche))
        {
            rb.AddForce(new Vector3(0, 1, 0) * power, ForceMode.Impulse);
        }
    }
}