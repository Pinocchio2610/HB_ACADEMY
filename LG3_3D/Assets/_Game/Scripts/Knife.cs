using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
{

    public override void Moving()
    {
        Vector3 curren = this.transform.position;
        Vector3 tager = curren + Vector3.forward;
        this.transform.position = Vector3.Lerp(curren, tager, Time.deltaTime);
        Debug.Log("Kniefe");
    }

    public override void Dame()
    {
        base.Dame();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {

            this.gameObject.SetActive(false);
        }
    }
}

