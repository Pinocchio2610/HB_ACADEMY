using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int currentPlayer = 0;  // Người chơi hiện tại
    public int totalPlayers = 4;   // Tổng số người chơi
    private bool isCPUTurnProcessing = false;
    public List<GameObject> gameList = new List<GameObject>();
    public Button Pause;
    public GameObject CanvasSetting;
    public bool isStop;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        Pause.onClick.AddListener(OnCanvasSetting);
       
    }
    private void Update()
    {
        if (isStop)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 3f;
        }
        NextTurn();
    }
        
    public void NextTurn()
    {
        if (currentPlayer == 0)
        {
            Player.Instance.StartTurn(currentPlayer);
            gameList[0].GetComponent<Image>().color = Color.white;
        }
        else if (currentPlayer == 1) // CPU
        {
            gameList[1].GetComponent<Image>().color = Color.white;
            if (!isCPUTurnProcessing)
            {
                StartCoroutine(HandleCPUTurn());
            }
        }
        else if (currentPlayer == 2)
        {
            gameList[2].GetComponent<Image>().color = Color.white;
            if (!isCPUTurnProcessing)
            {
                StartCoroutine(HandleCPU1Turn());
            }
        }
        else if (currentPlayer == 3)
        {
            gameList[3].GetComponent<Image>().color = Color.white;
            if (!isCPUTurnProcessing)
            {
                StartCoroutine(HandleCPU2Turn());
            }
        }
    }
    public void EndTurn()
    {
        currentPlayer = (currentPlayer + 1) % totalPlayers;
        NextTurn();
    }
    private IEnumerator HandleCPUTurn()
    {
        isCPUTurnProcessing = true;

        // 1. Hiệu ứng bắt đầu lượt
        yield return new WaitForSeconds(0.5f); // Delay để người chơi thấy

        // 2. Tung xúc xắc
        Dice.dice.RollDiceCPU();
        // 3. Chờ xúc xắc dừng
        yield return new WaitUntil(() =>
            Dice.dice.gameObject.GetComponent<Rigidbody>().velocity == Vector3.zero);

        yield return new WaitForSeconds(10f); // Thêm delay để quan sát

        // 4. Hiển thị kết quả
        Dice.dice.Canvas.SetActive(false);
        int result = Dice.dice.CallRoll();
        CPU.instance.Xucxac = result;
        // 5. Di chuyển từng bước (nếu cần)
        if (Dice.dice.CheckMoveCPU == true)
        {
            CPU.instance.CheckSeahouse();
        }
        yield return new WaitForSeconds(0.5f); // Delay giữa các bước di chuyển
        // 6. Kết thúc lượt
        yield return new WaitForSeconds(0.5f);
        if (CPU.instance.Xucxac == 6)
        {
            Dice.dice.Reset();
            StartCoroutine(HandleCPUTurn());
        }
        else
        {
            isCPUTurnProcessing = false;
            gameList[1].GetComponent<Image>().color = Color.black;
            Dice.dice.Reset();
            EndTurn();
        }
    }
    private IEnumerator HandleCPU1Turn()
    {
        isCPUTurnProcessing = true;

        // 1. Hiệu ứng bắt đầu lượt
        yield return new WaitForSeconds(0.5f); // Delay để người chơi thấy

        // 2. Tung xúc xắc
        Dice.dice.RollDiceCPU2();
        // 3. Chờ xúc xắc dừng
        yield return new WaitUntil(() =>
            Dice.dice.gameObject.GetComponent<Rigidbody>().velocity == Vector3.zero);

        yield return new WaitForSeconds(10f); // Thêm delay để quan sát
        // 4. Hiển thị kết quả
        Dice.dice.Canvas.SetActive(false);
        int result = Dice.dice.CallRoll();
        CPU2.instance.Xucxac = result;
        // 5. Di chuyển từng bước (nếu cần)
        if (Dice.dice.CheckMoveCPU2 == true)
        {
            CPU2.instance.CheckSeahouse();
        }
        yield return new WaitForSeconds(0.5f); // Delay giữa các bước di chuyển
        // 6. Kết thúc lượt
        yield return new WaitForSeconds(0.5f);
        if (CPU2.instance.Xucxac == 6)
        {
            Dice.dice.Reset();
            StartCoroutine(HandleCPU1Turn());
        }
        else
        {
            gameList[2].GetComponent<Image>().color = Color.black;
            Dice.dice.Reset();
            isCPUTurnProcessing = false;
            EndTurn();
        }
    }
    private IEnumerator HandleCPU2Turn()
    {
        isCPUTurnProcessing = true;

        // 1. Hiệu ứng bắt đầu lượt
        yield return new WaitForSeconds(0.5f); // Delay để người chơi thấy

        // 2. Tung xúc xắc
        Dice.dice.RollDiceCPU3();
        // 3. Chờ xúc xắc dừng
        yield return new WaitUntil(() =>
            Dice.dice.gameObject.GetComponent<Rigidbody>().velocity == Vector3.zero);

        yield return new WaitForSeconds(10f); // Thêm delay để quan sát

        // 4. Hiển thị kết quả
        Dice.dice.Canvas.SetActive(false);
        int result = Dice.dice.CallRoll();
        CPU3.instance.Xucxac = result;
        // 5. Di chuyển từng bước (nếu cần)
        if (Dice.dice.CheckMoveCPU3 == true)
        {
            CPU3.instance.CheckSeahouse();
        }
        yield return new WaitForSeconds(0.5f); // Delay giữa các bước di chuyển
        // 6. Kết thúc lượt
        yield return new WaitForSeconds(0.5f);
        if (CPU3.instance.Xucxac == 6)
        {
            Dice.dice.Reset();
            StartCoroutine(HandleCPU2Turn());
        }
        else
        {
            isCPUTurnProcessing = false;
            gameList[3].GetComponent<Image>().color = Color.black;
            Dice.dice.Reset();
            EndTurn();
        }
    }
    private void OnCanvasSetting()
    {
        CanvasSetting.SetActive(true);
        isStop = true;  
    }
}







