using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    public float resetPosition = 0f;
    public float pressedPosition = 90f;
    public float hitStrength = 100000f;
    public float flipperDamper = 300f;
    HingeJoint hinge;
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = flipperDamper;

        if (Input.GetKeyDown(KeyCode.T))
            spring.targetPosition = pressedPosition;
        else
            spring.targetPosition = resetPosition;

        hinge.spring = spring;
        hinge.useLimits = true;

    }
}
