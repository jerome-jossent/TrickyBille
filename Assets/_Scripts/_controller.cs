using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class _controller : MonoBehaviour
{
    public Gamepad gamepad;

    void Start()
    {
        StartCoroutine(FindController());
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

    void ReferenceController()
    {
        //juste pour l'exercice, parce qu'on aurait pu faire autrement
        //utilisation de la REFLEXION : càd qu'à l'aide du nom d'une méthode,
        //je la cherche et la démarre dans tous les scripts la possédant.
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            MonoBehaviour mb = go.GetComponent<MonoBehaviour>();
            MethodInfo info = mb?.GetType().GetMethod("GetController");
            info?.Invoke(mb, null);            
        }
    }

}
