using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    int lever = 0;

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("mana"))
        {
            Debug.Log("A");
            lever += 2;
            other.gameObject.SetActive(false);
           
        }
    }

}
