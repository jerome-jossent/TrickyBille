using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _8_bras_cloche : MonoBehaviour
{
    [SerializeField] _controller controller;
    public bool hop, hopped, go;
    public Collider other;
    [SerializeField] GameObject PointFixe;

    public float zAngleStep, zAngleMax;
    Quaternion rotationInit;

    public Rigidbody rb;
    private void Start()
    {
        rotationInit = transform.rotation;
    }

    void Update()
    {
        if (controller.gamepad == null)
            return;

        hop = controller.gamepad.xButton.wasPressedThisFrame;

        if (controller.gamepad.selectButton.wasPressedThisFrame)
            ResetPosition();

        if (other == null)
            return;

        if (hop)
        {
            go = true;
        }
        if (hopped)
        {
            other.gameObject.transform.parent = null;
            rb.isKinematic = false;
        }
    }

    private void FixedUpdate()
    {
        if (go)
        {
            transform.Rotate(0, 0, zAngleStep, Space.Self);
        }

        if (transform.rotation.eulerAngles.z > zAngleMax)
        {
            go = false;
            hopped = true;
            transform.rotation = Quaternion.Euler(0, 0, zAngleMax);
        }
    }

    public void ResetPosition()
    {
        go = false;
        hopped = false;
//        transform.rotation = rotationInit;
        transform.rotation = Quaternion.Euler(0, 0, 5);

    }

    public void _OnTriggerEnter()
    {
        if (hopped)
            return;

        Debug.Log("_OnTriggerEnter " + other.name);
        rb = other.gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        other.gameObject.transform.SetParent(PointFixe.transform);
        other.gameObject.transform.position = PointFixe.transform.position;
    }
    public void _OnTriggerStay()
    {
        //Debug.Log("_OnTriggerStay " + other.name);
    }
    public void _OnTriggerExit()
    {
        //Debug.Log("_OnTriggerExit " + other.name);
    }

}
