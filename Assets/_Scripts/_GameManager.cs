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

    public enum step { prerequisite, run, finish }
    public step GameState;
    step GameState_prec;

    public void Start()
    {
        GameState = step.prerequisite;
        Init();
        _Start(); // temporaire...
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
            if (GameState_prec != GameState)
                _sm._chrono._SetChronoStart();
            float dT = Time.time - T0;
            _sm._TeteHauteManager._DisplayTime(dT);
            _sm._chrono._ChronoUpdate(dT);
        }
        else
        {
            if (GameState_prec != GameState)
                _sm._chrono._SetChronoStop();
        }
        GameState_prec = GameState;
    }

    public void _Start()
    {
      //  GameState = step.start;
        // démarrage chrono
        Chrono = new Dictionary<int, float>();
        T0 = Time.time;
        _sm._chrono._ChronoUpdate(0);
        // placement de la bille au point de départ
        _sm._CheckPointEtSpawn._InitPosition();

       // _sm._choose_Control_And_Color._SetToggleButtonsFromValues();
    }

    public void _NewLevelReached(int niveau)
    {
        //Debug.Log("Niveau atteint : " + niveau.ToString());
        
        //niveaux atteints
        GameState = step.run;
        //  enregistrement des chronos pour chaque niveau
        if (!Chrono.ContainsKey(niveau))
        {
            Chrono.Add(niveau, Time.time - T0);
            _sm._TeteHauteManager._DisplayLevel(niveau.ToString());
        }

        //pour le cas du bras aimanté, il faut réactiver l'aimant si la valeur est différente de 3
        if (niveau != 4)
        {
            _sm._piegeManager._2_Bras_Aimante._Reset();
        }





    }

    public void _Finish()
    {
        GameState = step.finish;
        //terminé
        //  arrêt chrono
        //  scores

        //propose menu pour restart !!!!!!
    }

    public void _Restart()
    {
        _sm._piegeManager._8_Bras_Cloche._Reset();
        _Start();
    }
}