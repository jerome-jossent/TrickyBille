using System;
using UnityEngine;

public class _3_rails_ecartes : MonoBehaviour
{
    public GameObject Rail_Gauche;
    public GameObject Rail_Droite;
    public GameObject Poussoir;
    public string InputAxe;
    public float valbrute, valbruteprec;
    public float val;

    public float degMax;
    Vector3 poussoir_alt_init;

    private void Start()
    {
        poussoir_alt_init = Poussoir.transform.localPosition;
    }

    void Update()
    {
        valbrute = Input.GetAxis(InputAxe);
        if (valbrute < 0)
            valbrute = 0;

        if (valbrute != valbruteprec)
        {
            val = valbrute * degMax;
            Vector3 push = poussoir_alt_init + new Vector3(0,UnityEngine.Random.Range(-0.1f, 0),0);
            Rail_Gauche.transform.localRotation = Quaternion.Euler(0, val, 0);
            Rail_Droite.transform.localRotation = Quaternion.Euler(0, -val, 0);
            Poussoir.transform.localPosition = push;
            valbruteprec = valbrute;
        }
    }
}
