using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckPointEtSpawn : MonoBehaviour
{
    [SerializeField] _controller controller;
    public GameObject Bille;
    [Range(0, 7)] public int niveau;
    public GameObject[] spawnPoint;

    public bool spawnDebugAtStart;
    public GameObject spawnPointDebug;

    SCRIPTSMANAGER _sm;
    void Awake()
    {
        _sm = GameObject.Find("Scripts Manager").GetComponent<SCRIPTSMANAGER>();
    }
    void Start()
    {
        if (spawnDebugAtStart && spawnPointDebug.activeSelf && spawnPointDebug.transform.parent.gameObject.activeSelf)
            spawn(Bille, true);
        else
            spawn(Bille);
    }

    void Update()
    {
        if (controller.gamepad == null) return;

        bool whanttospawn = controller.gamepad.bButton.wasPressedThisFrame;
        if (controller.gamepad.leftShoulder.wasPressedThisFrame)
        {
            NextLevel();
            whanttospawn = true;
        }

        if (controller.gamepad.yButton.wasPressedThisFrame)
            spawn(Bille, true);
        if (whanttospawn)
            spawn(Bille, false);
    }

    void NextLevel()
    {
        do
        {
            niveau++;
            if (niveau > spawnPoint.Length-1) 
                niveau = 0;
        } while (spawnPoint[niveau] == null);
    }

    public void spawn(GameObject QUOI, bool debug = false)
    {
        if (debug)
            QUOI.transform.position = spawnPointDebug.transform.position;
        else
            QUOI.transform.position = spawnPoint[niveau].transform.position;

        QUOI.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void _CheckPoint(GameObject checkpointPasse)
    {       
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            if (checkpointPasse == spawnPoint[i])
            {
                if (i > niveau)
                    niveau = i;
                break;
            }
        }

        _sm._gameManager._NewLevelReached(niveau);

        if (niveau == spawnPoint.Length - 1)
        {
            _sm._gameManager._Finish();
            niveau = 0;
        }
    }
}