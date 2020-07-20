using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _8_bras_cloche : MonoBehaviour
{
    [SerializeField] _controller controller;
   // [SerializeField] GameObject GO_withRigidBody;
   // Rigidbody rigidbody;
    public float rotationSpeed;
    public float xAngle, yAngle, zAngle;


    private void Start()
    {
       // rigidbody = GO_withRigidBody.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (controller.gamepad == null) return;
        
        if(controller.gamepad.xButton.wasPressedThisFrame)
        {
           // transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);

            transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
            //transform.Rotate(xAngle, yAngle, zAngle, Space.World);
            //transform.Rotate(Vector3.forward, rotationSpeed);
        }
    }

    private void FixedUpdate()
    {
        
    }
}
