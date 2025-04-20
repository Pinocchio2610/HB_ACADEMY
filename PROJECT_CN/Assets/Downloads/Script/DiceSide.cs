using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSide : MonoBehaviour
{
    public static DiceSide diceSide;
    bool onGround;
    public int sideValue;
    private void Awake()
    {
        diceSide = this;
    }
    void OnTriggerEnter(Collider col)
    {
       
        if (col.tag == "Ground")
        {
            onGround = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Ground")
        {
            onGround = false;
        }
    }
    public bool OnGround()
    {
        return onGround;
    }
}
