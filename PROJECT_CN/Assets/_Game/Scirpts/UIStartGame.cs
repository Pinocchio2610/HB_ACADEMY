using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStartGame : MonoBehaviour
{
    public Button PlayGame;
    public static UIStartGame instance {  get; private set; }

 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        PlayGame.onClick.AddListener(Batdaugame);
    }
    private void Batdaugame()
    {
        Mapmanager.mapmanager.Genmap();
        this.gameObject.SetActive(false);
    }    

}
