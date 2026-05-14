using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimal : MonoBehaviour
{
   

    private void OnMouseDown()
    {
        Player.instance.coin += 1000;
        this.gameObject.SetActive(false);
    }
}
