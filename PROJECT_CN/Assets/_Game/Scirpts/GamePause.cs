using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{
    public GameObject MenuPausee;
    public static GamePause instanes;
    private void wake()
    {
        if(instanes == null)
        {
            instanes = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void MenuPause()
    {
        MenuPausee.SetActive(true);
    }


}
