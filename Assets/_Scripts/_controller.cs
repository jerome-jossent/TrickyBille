using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class _controller : MonoBehaviour
{
    public Gamepad gamepad;
    public GameObject[] scripts;

    void Start()
    {
        StartCoroutine(FindController());
    }

    void ReferenceController()
    {
        foreach (GameObject item in scripts)
        {
            MonoBehaviour mb = item?.GetComponent<MonoBehaviour>();
            MethodInfo info = mb?.GetType().GetMethod("GetController");
            info?.Invoke(mb, null);
        }
    }

    IEnumerator FindController()
    {
        while (gamepad == null)
        {   //prend le premier controller
            foreach (Gamepad g in Gamepad.all)
            {
                gamepad = g;
                break;
            }
            yield return new WaitForSeconds(.1f);
        }
        ReferenceController();
    }
}
