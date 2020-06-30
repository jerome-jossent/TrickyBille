using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Trig_2 : MonoBehaviour
{
    public MonoBehaviour script;
    MethodInfo info;

    private void Start()
    {
        info = script?.GetType().GetMethod("_OnTriggerStay");
    }

    private void OnTriggerEnter(Collider other)
    {
        script?.GetType().GetField("other", BindingFlags.Instance | BindingFlags.Public).SetValue(script, other);
    }
    private void OnTriggerStay(Collider other)
    {
        info?.Invoke(script, null);
    }
    private void OnTriggerExit(Collider other)
    {
        script?.GetType().GetField("other", BindingFlags.Instance | BindingFlags.Public).SetValue(script, null);
    }
}
