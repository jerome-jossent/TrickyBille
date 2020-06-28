using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Bille;
    [Range(1, 9)]
    public int niveau;
    public GameObject[] spawnPoint;

    public bool spawnDebugAtStart;
    public KeyCode spawnDebugKeyCode;
    public GameObject spawnPointDebug;

    void Start()
    {
        if (spawnDebugAtStart && spawnPointDebug.activeSelf && spawnPointDebug.transform.parent.gameObject.activeSelf)
            spawn(Bille, true);
        else
            spawn(Bille);
    }

    void Update()
    {
        if (Input.GetKeyDown(spawnDebugKeyCode))
            spawn(Bille, true);
    }

    public void spawn(GameObject QUOI, bool debug = false)
    {
        if (debug)
            QUOI.transform.position = spawnPointDebug.transform.position;
        else
            QUOI.transform.position = spawnPoint[niveau - 1].transform.position;

        QUOI.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}