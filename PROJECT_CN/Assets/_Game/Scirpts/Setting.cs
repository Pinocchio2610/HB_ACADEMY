using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Button Quit;
    public Button Again;
    public static Setting setting { get; private set; }

    private void Awake()
    {
        if (setting == null)
        {
            setting = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Again.onClick.AddListener(ButtonAgain);
        Quit.onClick.AddListener(ButtonQuit);
    } 

    void ButtonAgain()
    {
        GameManager.instance.CanvasSetting.SetActive(false);
        GameManager.instance.isStop = false;
    }
    void ButtonQuit()
    {
        GameManager.instance.CanvasSetting.SetActive(false);
        UIStartGame.instance.gameObject.SetActive(true);
    }    
   
}
