using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeteHauteManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI txtCHRONO;
    public TMPro.TextMeshProUGUI txtLEVEL;
    public TMPro.TextMeshProUGUI txtINFO;

    public void _DisplayTextInfo(string msg)
    {
        txtINFO.text = msg;
    }

    internal void _DisplayTime(float dT)
    {
        txtCHRONO.text = dT.ToString("0.00");
    }

    public void _DisplayLevel(string msg)
    {
        txtLEVEL.text = msg;
    }

}
