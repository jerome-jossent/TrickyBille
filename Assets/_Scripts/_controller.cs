using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class _controller : MonoBehaviour
{
    public Gamepad gamepad;
    //public GameObject[] scripts;

    void Start()
    {
        StartCoroutine(FindController());
    }

    void ReferenceController()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            MonoBehaviour mb = go.GetComponent<MonoBehaviour>();
            MethodInfo info = mb?.GetType().GetMethod("GetController");
            if (info != null)
            {
                Debug.Log("Link Controller to " + go.name);
                info.Invoke(mb, null);
            }
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
