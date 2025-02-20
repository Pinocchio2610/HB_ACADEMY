using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public Button nextLevelButton;
    public Button retryButton;

    private bool isGameOver = false;
    public static UIManager uiManager { get; private set; } // Singleton
    private void Awake()
    {
        if (uiManager == null)
        {
            uiManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        HideGameUI();

        nextLevelButton.onClick.AddListener(OnClickNextMap);
        retryButton.onClick.AddListener(OnClickTryAgain);
    }

    void Update()
    {
        if (isGameOver)
        {
            ShowGameUI();
        }
    }

    void OnClickNextMap()
    {
        MapManager.mapManager.NextMap();
        Character.character.OnInit();
        isGameOver = false;
        HideGameUI();
    }

    void OnClickTryAgain()
    {
        MapManager.mapManager.GenMap();
        Character.character.OnInit();
        isGameOver = false;
        HideGameUI();
    }


    public void GameOver()
    {
        isGameOver = true;
    }

    internal void HideGameUI()
    {
        gameOverUI.SetActive(false);
    }

    internal void ShowGameUI()
    {
        gameOverUI.SetActive(true);
    }
}