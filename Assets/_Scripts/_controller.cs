using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class _controller : MonoBehaviour
{
    public Gamepad gamepad;

    void Awake()
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
        Debug.Log("Contrôleur de jeu trouvé : " + gamepad.displayName);
        //ReferenceController();
    }

    void ReferenceController()
    {
        // juste pour l'exercice, parce qu'on aurait pu faire autrement
        // utilisation de la REFLECTION : càd qu'à l'aide du nom d'une méthode,
        // je la cherche et la démarre dans tous les scripts la possédant.
        MonoBehaviour[] allScripts = Resources.FindObjectsOfTypeAll(typeof(MonoBehaviour)) as MonoBehaviour[];
        foreach (MonoBehaviour mb in allScripts)
        {
            MethodInfo info = mb.GetType().GetMethod("GetController");
            if (info != null)
            {
                info.Invoke(mb, null);
                //Debug.Log(gamepad.displayName + " linked to " + mb.gameObject.name);
            }
        }
    }
}
