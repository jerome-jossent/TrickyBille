using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class _controller : MonoBehaviour
{
    //https://forum.unity.com/threads/new-input-system-not-working-in-webgl-builds.870421/
    public Gamepad gamepad;

    int i = 0;
    SCRIPTSMANAGER _sm;
    void Awake()
    {
        _sm = GameObject.Find("Scripts Manager").GetComponent<SCRIPTSMANAGER>();
    }

    public void _FindController()
    {
        StartCoroutine(GetFirstController());
    }

    IEnumerator GetFirstController()
    {
        while (gamepad == null)
        {
            //gamepad = Gamepad.current;
            foreach (Gamepad g in Gamepad.all)
            {
                gamepad = g;
                break;
            }
            _sm._TeteHauteManager._DisplayTextInfo("Branchez une manette et appuyez sur un bouton\n" +
                "(déconnecté/reconnecté)");
            yield return new WaitForSeconds(0.2f);
        }
        _sm._TeteHauteManager._DisplayTextInfo("");

        yield return null;
    }
}