using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float Speed = 5;

    private void Update()
    {
        Moving();
    }
    public virtual void Moving()
    {
       
    }

    public virtual void Dame()
    {

    }
   
   

}
