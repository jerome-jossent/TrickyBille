using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawn : MonoBehaviour
{
    public GameObject Bille;
    [Range(1, 9)] public int niveau;
    public GameObject[] spawnPoint;

    public bool spawnDebugAtStart;
    public GameObject spawnPointDebug;
    Gamepad gamepad;

    void Start()
    {
        if (spawnDebugAtStart && spawnPointDebug.activeSelf && spawnPointDebug.transform.parent.gameObject.activeSelf)
            spawn(Bille, true);
        else
            spawn(Bille);
    }

    void Update()
    {
        if (gamepad == null) GetController();

        bool whanttospawn = gamepad.bButton.wasPressedThisFrame;
        if (gamepad.leftShoulder.wasPressedThisFrame)
        {
            NextLevel();
            whanttospawn = true;
        }

        if (gamepad.yButton.wasPressedThisFrame)
            spawn(Bille, true);
        if (whanttospawn)
            spawn(Bille, false);

    }

    void NextLevel()
    {
        do
        {
            niveau++;
            if (niveau > 9) niveau = 1;
        } while (spawnPoint[niveau - 1] == null);
    }

    public void GetController()
    {
        gamepad = GameObject.Find("Scripts Manager").GetComponent<_controller>().gamepad;
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