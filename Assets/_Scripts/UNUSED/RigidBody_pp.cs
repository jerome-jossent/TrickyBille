using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBody_pp : MonoBehaviour
{
    Rigidbody rb;
    public float val;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {

        rb.maxAngularVelocity = val;
        rb.maxDepenetrationVelocity = val;
        //Physics.gravity = new Vector3(0, -1.0F, 0);
    }
}
