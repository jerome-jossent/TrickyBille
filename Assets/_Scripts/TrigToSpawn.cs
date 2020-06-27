using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigToSpawn : MonoBehaviour
{
    Spawn spawn;

    private void Start()
    {
        spawn = GameObject.Find("Script Manager").GetComponent<Spawn>();
    }

    void OnTriggerEnter(Collider other)
    {
        spawn.spawn(other.gameObject);
    }

}
