using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choose_Control_and_Color : MonoBehaviour
{
    [SerializeField] Toggle x360, touch, souris;
    [SerializeField] Toggle marron, rouge, orange, bleu;
    bool changebycode = false;
    SCRIPTSMANAGER _sm;
    void Awake()
    {
        _sm = GameObject.Find("Scripts Manager").GetComponent<SCRIPTSMANAGER>();


        _SetToggleButtonsFromValues();
        gameObject.SetActive(false);
    }

    public void _SetToggleButtonsFromValues()
    {
        //Debug.Log(_sm._IM._interaction_Type.ToString());
        changebycode = true;
        switch (_sm._IM._interaction_Type)
        {
            case Interactions_Manager.interaction_type.x360:
                x360.isOn = true;
                break;
            case Interactions_Manager.interaction_type.touchScreen:
                touch.isOn = true;
                break;
            case Interactions_Manager.interaction_type.mouse:
                souris.isOn = true;
                break;
        }
        _Selection_Controller();

        switch (_sm._boardVersion._boardVersion_type)
        {
            case _BoardVersion.BoardVersion_type.marron:
                marron.isOn = true;
                break;
            case _BoardVersion.BoardVersion_type.rouge:
                rouge.isOn = true;
                break;
            case _BoardVersion.BoardVersion_type.orange:
                orange.isOn = true;
                break;
            case _BoardVersion.BoardVersion_type.bleu:
                bleu.isOn = true;
                break;
        }
        _Selection_Color();
        changebycode = false;
    }

    public void _Selection_Controller()
    {
        if (x360.isOn)
        {
            if(!changebycode)
                _sm._IM._interaction_Type = Interactions_Manager.interaction_type.x360;
            x360.targetGraphic.color = new Color(1, 1, 1, 1);
            touch.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            souris.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            return;
        }
        if (touch.isOn)
        {
            if (!changebycode)
                _sm._IM._interaction_Type = Interactions_Manager.interaction_type.touchScreen;
            x360.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            touch.targetGraphic.color = new Color(1, 1, 1, 1);
            souris.targetGraphic.color = new Color(1, 1, 1, 0.5f);
            return;
        }
        if (souris.isOn)
        {
            if (!changebycode)
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
