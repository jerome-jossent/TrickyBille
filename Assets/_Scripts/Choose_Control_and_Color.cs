using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choose_Control_and_Color : MonoBehaviour
{
    [SerializeField] Toggle x360, touch, souris;
    [SerializeField] Toggle marron, rouge, orange, bleu;

    SCRIPTSMANAGER _sm;
    void Awake()
    {
        _sm = GameObject.Find("Scripts Manager").GetComponent<SCRIPTSMANAGER>();
    }

    public void Start()
    {
        x360.targetGraphic.color = new Color(1, 1, 1, 0.5f);
        touch.targetGraphic.color = new Color(1, 1, 1, 0.5f);
        souris.targetGraphic.color = new Color(1, 1, 1, 0.5f);

        marron.targetGraphic.color = new Color(1, 1, 1, 0.5f);
        rouge.targetGraphic.color = new Color(1, 1, 1, 0.5f);
        orange.targetGraphic.color = new Color(1, 1, 1, 0.5f);
        bleu.targetGraphic.color = new Color(1, 1, 1, 0.5f);
    }

    public void _Selection_Controller()
    {
        if (x360.isOn)
        {
            _sm._IM._interaction_Type = Interactions_Manager.interaction_type.x360;
            x360.targetGraphic.color = new Color(1, 1, 1, 1);
            touch.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            souris.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            return;
        }
        if (touch.isOn)
        {
            _sm._IM._interaction_Type = Interactions_Manager.interaction_type.touchScreen;
            x360.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            touch.targetGraphic.color = new Color(1, 1, 1, 1);
            souris.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            return;
        }
        if (souris.isOn)
        {
            _sm._IM._interaction_Type = Interactions_Manager.interaction_type.mouse;
            x360.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            touch.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            souris.targetGraphic.color = new Color(1, 1, 1, 1);
            return;
        }
    }
    
    public void _Selection_Color()
    {
        if (marron.isOn)
        {
            _sm._boardVersion._SetBoradVersion(_BoardVersion.BoardVersion_type.marron);
            marron.targetGraphic.color = new Color(1, 1, 1, 1);
            rouge.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            orange.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            bleu.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            return;
        }
        if (rouge.isOn)
        {
            _sm._boardVersion._SetBoradVersion(_BoardVersion.BoardVersion_type.rouge);
            marron.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            rouge.targetGraphic.color = new Color(1, 1, 1, 1);
            orange.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            bleu.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            return;
        }
        if (orange.isOn)
        {
            _sm._boardVersion._SetBoradVersion(_BoardVersion.BoardVersion_type.orange);
            marron.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            rouge.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            orange.targetGraphic.color = new Color(1, 1, 1, 1);
            bleu.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            return;
        }
        if (bleu.isOn)
        {
            _sm._boardVersion._SetBoradVersion(_BoardVersion.BoardVersion_type.bleu);
            marron.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            rouge.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            orange.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            bleu.targetGraphic.color = new Color(1, 1, 1, 1);
            return;
        }
    }
}
