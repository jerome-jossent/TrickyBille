﻿using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class _2_bras_aimante : MonoBehaviour
{
    //il faut environ tourner 3 fois le bouton (trois coup de poignet) pour réaliser un demi-tour (0 à 180° ou 0 à -180°)

    public GameObject Pivot;
    public Trig _ZoneStart, _ZoneStop; //zones d'activités de l'aimant
    public GameObject Aimant; //point d'ancrage positionné au bout du bras

    //pour l'interface j'utilise un joystick avec ses 2 axes. L'objectif est de le faire tourner dans le même sens que le bouton.    
    //subjectivement, ça correspondrait à 3 tours de joysticks.
    public string InputAxeH;
    public string InputAxeV;
    // comprise entre -1 et 1
    // comprise entre -1 et 1

    public float joy_ang_deg; // calcul de la position (angulaire) du joystick
    public TextAnchor joy_pos;
    public TextAnchor joy_pos_prec;

    public float angleTarget;
    public float vitesseangulaire;
    private Quaternion targetRotation;

    Gamepad gamepad;
   public Vector2 valbrute;
    void Start()
    {
        _ZoneStart._ba = this;
        _ZoneStop._ba = this;
    }

    void Update()
    {
        if (gamepad == null) GetController();

        valbrute = gamepad.rightStick.ReadValue();

        joy_pos = AngleToOrientation(valbrute.y, valbrute.x);
        float increment = CalculIncrement(joy_pos) * 10;
        if (increment != 0)
        {
            angleTarget += increment;
            if (angleTarget > 0) angleTarget = 0;
            if (angleTarget < -180) angleTarget = -180;
            targetRotation = Quaternion.Euler(0, angleTarget, 0);
        }

        Pivot.transform.rotation = Quaternion.Slerp(Pivot.transform.rotation, targetRotation, vitesseangulaire * Time.deltaTime);
    }

    public void GetController()
    {
        gamepad = GameObject.Find("Scripts Manager").GetComponent<_controller>().gamepad;
    }

    float CalculIncrement(TextAnchor joy_pos)
    {
        float val = CalculIncrement(joy_pos, joy_pos_prec);
        joy_pos_prec = joy_pos;
        return val;
    }

    float CalculIncrement(TextAnchor joy_pos, TextAnchor joy_pos_prec)
    {
        if (joy_pos == joy_pos_prec)
            return 0f;

        switch (joy_pos_prec)
        {
            case TextAnchor.UpperLeft:
                if (joy_pos == TextAnchor.MiddleLeft) return -1f;
                if (joy_pos == TextAnchor.UpperCenter) return 1f;
                break;
            case TextAnchor.UpperCenter:
                if (joy_pos == TextAnchor.UpperLeft) return -1f;
                if (joy_pos == TextAnchor.UpperRight) return 1f;
                break;
            case TextAnchor.UpperRight:
                if (joy_pos == TextAnchor.UpperCenter) return -1f;
                if (joy_pos == TextAnchor.MiddleRight) return 1f;
                break;
            case TextAnchor.MiddleRight:
                if (joy_pos == TextAnchor.UpperRight) return -1f;
                if (joy_pos == TextAnchor.LowerRight) return 1f;
                break;
            case TextAnchor.MiddleCenter:
                break;
            case TextAnchor.LowerRight:
                if (joy_pos == TextAnchor.MiddleRight) return -1f;
                if (joy_pos == TextAnchor.LowerCenter) return 1f;
                break;
            case TextAnchor.LowerCenter:
                if (joy_pos == TextAnchor.LowerRight) return -1f;
                if (joy_pos == TextAnchor.LowerLeft) return 1f;
                break;
            case TextAnchor.LowerLeft:
                if (joy_pos == TextAnchor.LowerCenter) return -1f;
                if (joy_pos == TextAnchor.MiddleLeft) return 1f;
                break;
            case TextAnchor.MiddleLeft:
                if (joy_pos == TextAnchor.LowerLeft) return -1f;
                if (joy_pos == TextAnchor.UpperLeft) return 1f;
                break;
        }
        return 0f;
    }

    TextAnchor AngleToOrientation(float V, float H)
    {
        if (Math.Abs(V) + Math.Abs(H) < 1)
            return TextAnchor.MiddleCenter;

        joy_ang_deg = Mathf.Atan2(V, H) * 180 / Mathf.PI;
        if (joy_ang_deg < 22.5f && joy_ang_deg > -22.5f) return TextAnchor.MiddleRight;
        if (joy_ang_deg < 67.5f && joy_ang_deg > 22.5f) return TextAnchor.UpperRight;
        if (joy_ang_deg < 112.5f && joy_ang_deg > 67.5f) return TextAnchor.UpperCenter;
        if (joy_ang_deg < 157.5f && joy_ang_deg > 112.5f) return TextAnchor.UpperLeft;
        if (joy_ang_deg < -157.5f || joy_ang_deg > 157.5f) return TextAnchor.MiddleLeft;
        if (joy_ang_deg < -112.5f && joy_ang_deg > -157.5f) return TextAnchor.LowerLeft;
        if (joy_ang_deg < -67.5f && joy_ang_deg > -112.5f) return TextAnchor.LowerCenter;
        if (joy_ang_deg < -22.5f && joy_ang_deg > -67.5f) return TextAnchor.LowerRight;
        return TextAnchor.MiddleCenter;
    }

    internal void TrigEnter(Trig trig, GameObject go)
    {
        if (trig == _ZoneStart)
        {
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            go.transform.SetParent(Aimant.transform);
            go.transform.position = Aimant.transform.position;
        }
        if (trig == _ZoneStop)
        {
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            go.transform.parent = null;
        }
    }
    internal void TrigStay(Trig trig, GameObject go)
    {
        //if (trig == _ZoneStart)
        //{
        //    Rigidbody rb = go.GetComponent<Rigidbody>();
        //    rb.isKinematic = true;
        //    go.transform.SetParent(Aimant.transform);
        //    go.transform.position = Aimant.transform.position;
        //}
        //if (trig == _ZoneStop)
        //{
        //    Rigidbody rb = go.GetComponent<Rigidbody>();
        //    rb.isKinematic = false;
        //    go.transform.parent = null;
        //}
    }
    internal void TrigExit(Trig trig, GameObject go)
    {
        //if (trig == _ZoneStart)
        //{
        //    Rigidbody rb = go.GetComponent<Rigidbody>();
        //    rb.isKinematic = true;
        //    go.transform.SetParent(Aimant.transform);
        //    go.transform.position = Aimant.transform.position;
        //}
        //if (trig == _ZoneStop)
        //{
        //    Rigidbody rb = go.GetComponent<Rigidbody>();
        //    rb.isKinematic = false;
        //    go.transform.parent = null;
        //}
    }
}