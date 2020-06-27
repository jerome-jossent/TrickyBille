using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;

public class _2_bras_aimante : MonoBehaviour
{
    public GameObject Pivot;
    public Trig _Start, _Stop;
    public GameObject Aimant;

    public string InputAxeH;
    public string InputAxeV;
    public float valbruteH;
    public float valbruteV;
    public float val;

    public float degMin;
    public float degMax;



    void Start()
    {
        _Start._ba = this;
        _Stop._ba = this; 
    }

    // Update is called once per frame
    void Update()
    {
  

        //valbruteH = Input.GetAxis(InputAxeH);
        //valbruteV = Input.GetAxis(InputAxeV);
        //val = Mathf.Atan2(Input.GetAxis(InputAxeV), Input.GetAxis(InputAxeH)) * 180 / Mathf.PI;

        //if (val > -180 && val <= 0)
        //{
        //    Vector3 angle = new Vector3(0, val, 0);
        //    Pivot.transform.eulerAngles = angle;
        //}

    }

    internal void Trig(Trig trig, GameObject go)
    {
        Debug.Log(go.name + " est entré dans " + trig.name);
        if (trig == _Start)
        {
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            go.transform.SetParent(Aimant.transform);
        }
        if (trig == _Stop)
        {
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            go.transform.parent = null;
        }
    }

}
