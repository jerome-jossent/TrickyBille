using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigToSpawn : MonoBehaviour
{
    CheckPointEtSpawn spawn;

    private void Start()
    {
        spawn = GameObject.Find("Scripts Manager").GetComponent<CheckPointEtSpawn>();
    }

    void OnTriggerEnter(Collider other)
    {
        spawn.spawn(other.gameObject);
    }

}
