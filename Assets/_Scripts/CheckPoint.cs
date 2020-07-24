using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Spawn spawn_Manager;
    private void Start()
    {
        spawn_Manager = GameObject.Find("Scripts Manager").GetComponent<Spawn>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Bille")
            return;

        spawn_Manager._CheckPoint(gameObject.transform.parent.gameObject);
    }
}