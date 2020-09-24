using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _8_bras_cloche : MonoBehaviour
{
    public bool hop, hopped, go;
    public Collider other;
    [SerializeField] GameObject PointFixe;

    public float zAngleStep, zAngleMax;
    Quaternion rotationInit = Quaternion.Euler(0, 0, 5);

    public Rigidbody rb;
    SCRIPTSMANAGER _sm;
    void Awake()
    {
        _sm = GameObject.Find("Scripts Manager").GetComponent<SCRIPTSMANAGER>();
    }

    private void Start()
    {
        rotationInit = transform.rotation;
    }

    void Update()
    {
        hop = _sm._IM.i_8_lancement_bras_cloche;

        if (_sm._IM.i_8_lancement_bras_cloche_RESET)
            _Reset();

        if (other == null)
            return;

        if (hop)        
            go = true;
        
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

    public void _Reset()
    {
        go = false;
        hopped = false;
        transform.rotation = rotationInit;
    }

    public void _OnTriggerEnter()
    {
        if (hopped)
            return;

        //Debug.Log("_OnTriggerEnter " + other.name);
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
