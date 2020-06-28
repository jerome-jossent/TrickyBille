using UnityEngine;

public class applyTorque : MonoBehaviour
{
    public Rigidbody rb;
    public float torque;
    float turn;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))        
            turn = 1;
    }

    void FixedUpdate()
    {
        rb.AddTorque(transform.forward * torque * turn);
    }
}