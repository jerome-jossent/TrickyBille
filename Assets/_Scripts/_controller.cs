using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class _controller : MonoBehaviour
{//https://forum.unity.com/threads/new-input-system-not-working-in-webgl-builds.870421/
    public Gamepad gamepad;
    public Text text;

    int i = 0;

    public void Update()
    {
        if (gamepad != null) return;

        //gamepad = Gamepad.current;
        foreach (Gamepad g in Gamepad.all)
        {
            gamepad = g;
            break;
        }
        if (gamepad != null)
            text.text = "Contrôleur de jeu trouvé : " + gamepad.displayName;
        else
            text.text = "Contrôleur pas trouvé\n(déconnecté/reconnecté) - " + i++;
    }

    //void Awake()
    //{
    //    StartCoroutine(FindController());
    //}

    //IEnumerator FindController()
    //{
    //    int i = 0;
    //    while (gamepad == null)
    //    {   //prend le premier controller
    //        foreach (Gamepad g in Gamepad.all)
    //        {
    //            gamepad = g;
    //            break;
    //        }
    //        yield return new WaitForSeconds(.1f);
    //        text.text = "pas trouvé : " + i++;
    //    }
    //    text.text = "Contrôleur de jeu trouvé : " + gamepad.displayName;
    //    Debug.Log("Contrôleur de jeu trouvé : " + gamepad.displayName);
    //}
}