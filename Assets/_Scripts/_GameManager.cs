using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class _GameManager : MonoBehaviour
{
    float T0;
    Dictionary<int, float> Chrono;

    SCRIPTSMANAGER _sm;
    void Awake()
    {
        _sm = GameObject.Find("Scripts Manager").GetComponent<SCRIPTSMANAGER>();
    }

    public enum step { prerequisite, start, run, finish }
    public step GameState;

    public void Start()
    {
        GameState = step.prerequisite;
        Init();
        start(); // temporaire...
    }

    private void Init()
    {
        //brancher une manette
        _sm._Controller._FindController();
    }

    public void Update()
    {
        //Update Chrono
        if (GameState == step.run)
        {
            float dT = Time.time - T0;
            _sm._TeteHauteManager._DisplayTime(dT);
        }
    }

    public void start()
    {
        GameState = step.start;
        //  démarrage chrono
        Chrono = new Dictionary<int, float>();
        T0 = Time.time;
    }

    public void _NewLevelReached(int niveau)
    {
        //niveaux atteints
        GameState = step.run;
        //  enregistrement des chronos pour chaque niveau
        if (!Chrono.ContainsKey(niveau))
        {
            Chrono.Add(niveau, Time.time - T0);
            _sm._TeteHauteManager._DisplayLevel("Level " + niveau);
        }

    }

    public void _Finish()
    {
        GameState = step.finish;
        //terminé
        //  arrêt chrono
        //  scores
    }


}
