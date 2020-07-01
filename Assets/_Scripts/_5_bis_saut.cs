using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _5_bis_saut : MonoBehaviour
{
    public Vector3 direction;
    public float power;
    bool hop;
    public Collider other;
    public Animator animationPoussoir;

    private void Update()
    {
        hop = UnityEngine.InputSystem.Keyboard.current.yKey.wasPressedThisFrame;
        if (hop)
            animationPoussoir.SetTrigger("hop");//https://www.studica.com/blog/unity-tutorial-animator-controllers
    }

    public void _OnTriggerStay()
    {
        Debug.Log(other.gameObject.name); 
        if (hop)
            other.attachedRigidbody.AddForce(direction * power, ForceMode.Impulse);
    }
}
