using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Bille;
    [Range(1, 9)]
    public int niveau;
    public GameObject[] spawnPoint;

    void Start()
    {
        spawn(Bille);
    }

    public void spawn(GameObject QUOI)
    {
        QUOI.transform.position = spawnPoint[niveau - 1].transform.position;
        QUOI.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
