using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Trig_3 : MonoBehaviour
{
    public MonoBehaviour script;
    MethodInfo infoEnter, infoStay, infoExit;

    private void Start()
    {
        infoEnter = script?.GetType().GetMethod("_OnTriggerEnter");
        infoStay = script?.GetType().GetMethod("_OnTriggerStay");
        infoExit = script?.GetType().GetMethod("_OnTriggerExit");
    }

    private void OnTriggerEnter(Collider other)
    {
        script?.GetType().GetField("other", BindingFlags.Instance | BindingFlags.Public).SetValue(script, other);
        infoEnter?.Invoke(script, null);
    }
    private void OnTriggerStay(Collider other)
    {
        infoStay?.Invoke(script, null);
    }
    private void OnTriggerExit(Collider other)
    {
        infoExit?.Invoke(script, null);
        script?.GetType().GetField("other", BindingFlags.Instance | BindingFlags.Public).SetValue(script, null);
    }
}
