using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigToSpawn : MonoBehaviour
{
    public GameObject spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = spawnPoint.transform.position;
        other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
