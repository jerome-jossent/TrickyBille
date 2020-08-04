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
    SCRIPTSMANAGER _sm;
    void Awake()
    {
        _sm = GameObject.Find("Scripts Manager").GetComponent<SCRIPTSMANAGER>();
    }
    private void Start()
    {
        direction = transform.localRotation * direction;
    }

    private void Update()
    {
       // if (_sm._IM.controller.gamepad == null) return;
        hop = _sm._IM.i_5_saut;// controller.gamepad.aButton.wasPressedThisFrame;
        if (hop)
            animationPoussoir.SetTrigger("hop"); //https://www.studica.com/blog/unity-tutorial-animator-controllers
    }

    public void _OnTriggerStay()
    {
        //Debug.Log(other.gameObject.name);
        if (hop)
            other.attachedRigidbody.AddForce(direction * power, ForceMode.Impulse);
    }
}