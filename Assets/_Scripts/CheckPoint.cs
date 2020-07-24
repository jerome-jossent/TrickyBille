using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    CheckPointEtSpawn checkPointEtSpawn;
    private void Start()
    {
        checkPointEtSpawn = GameObject.Find("Scripts Manager").GetComponent<CheckPointEtSpawn>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Bille")
            return;

        checkPointEtSpawn._CheckPoint(gameObject.transform.parent.gameObject);
    }
}