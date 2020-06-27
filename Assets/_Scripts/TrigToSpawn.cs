using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigToSpawn : MonoBehaviour
{
    public Spawn spawn;

    private void Start()
    {
        GameObject.Find("Script Manager").GetComponent<Spawn>();
    }

    void OnTriggerEnter(Collider other)
    {
        spawn.spawn(other.gameObject);
    }

}
