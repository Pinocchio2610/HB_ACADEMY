using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Weapon
{
    
    public override void Moving()
    {
       
    }

    public override void Dame()
    {
        base.Dame();
    }

    public void Dichuyen()
    {
        Vector3 cureent = this.transform.rotation.eulerAngles;
        Quaternion target = Quaternion.Euler(cureent.x, cureent.y + 90, cureent.z);
        transform.rotation = Quaternion.Slerp(this.transform.rotation, target, Time.deltaTime * Speed);

    }
    public void Comeback()
    {
        Vector3.Lerp(transform.position, Character.character.transform.position, Time.deltaTime * Speed); 
    }    

    IEnumerator Test()
    {
        Dichuyen();
        yield return new WaitForSeconds(2);
        Comeback(); 
        yield return new WaitForSeconds(1);
    }    
}    

   

