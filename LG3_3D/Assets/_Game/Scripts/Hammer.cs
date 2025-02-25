using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Hammer : Weapon
{
    public override void Moving()
    {
        
        Vector3 cureent = this.transform.rotation.eulerAngles;
        Quaternion target = Quaternion.Euler(cureent.x, cureent.y + 90, cureent.z);
        transform.rotation = Quaternion.Slerp(this.transform.rotation, target ,Time.deltaTime *Speed);
    }

    public override void Dame()
    {
        base.Dame();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            this.gameObject.SetActive(false);
        } 
        
        if(collision.collider.tag == "Wall")
        {
            this.gameObject.SetActive(false);
        }    
    }

}
