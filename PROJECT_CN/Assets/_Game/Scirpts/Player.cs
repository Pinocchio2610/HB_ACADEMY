using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Dictionary<int, Vector3> move = Mapmanager.CheckInt();
    public int Xucxac;
    public Vector3[] LocalCanguaDo = new Vector3[4] { new Vector3(11, 1.01f, 2), new Vector3(11, 1.01f, 5), new Vector3(14, 1.01f, 2), new Vector3(14, 1.01f, 5) };
    public static Player Instance { get; private set; }
    private int currentPlayerIndex = 0;  // Người chơi hiện tại
    public bool CheckDice = false;
    public List<SeahorsePlayer> SeahorsePlayers = new List<SeahorsePlayer>();
    private bool isComing = false;
    private bool isLook = false;
    private bool win6 = false;
    private bool win5 = false;
    private bool win4 = false;
    private bool win3 = false;
    private SeahorsePlayer bientam;
    public GameObject Winer;
    private SeahorsePlayer Canguaduocpick;
    int Socabenngoia = 0;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    private void Update()
    {
        if (Dice.dice.CheckMovePlayer == true)
        {
            SeahorePlayers();
        }
    }
    public void SeahorePlayers()
    {
        isLook = true;
        if (XucXacBangSau(Xucxac))
        {
            ChonCaNgua();
        }
        else
        {
            DeCanguaDichuyen();
        }
    }
    private bool XucXacBangSau(int ketquaCuaXucXac)
    {
        if (ketquaCuaXucXac == 6)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ChonCaNgua()
    {
        if (NhanChuotTrai())
        {
            ChonCaNguaDo();
        }
    }
    private void ChonCaNguaDo()
    {
        Canguaduocpick = TimCaNgua();
        if (KhongKhongCoConNaoNgoaiChuong(Canguaduocpick))
        {
            XuatChuong();
        }
    } 
    private void XuatChuong()
    {
        if (CaNguaTrongChuong())
        {
            ChoXuatChuong();
        }
        else
        {
            ChoDiChuyen();

        }
        Dice.dice.hasLanded = true;
        Dice.dice.SetDice();
        StartTurn(0);
        Canguaduocpick.Firtmove = Canguaduocpick.transform.position;

    } 
    private bool CaNguaTrongChuong()
    {
        if (Canguaduocpick.isOutside == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void ChoXuatChuong()
    {
        Canguaduocpick.Myhome = Canguaduocpick.transform.position;
        Canguaduocpick.transform.position = move[1];
        Canguaduocpick.CheckVacham = true;
        bientam = Canguaduocpick;
        if (Canguaduocpick.transform.position == move[1])
        {
            Canguaduocpick.CheckVacham = false;
        }
        Canguaduocpick.isOutside = true;
    }
    private void ChoDiChuyen()
    {
        isComing = true;
        if (DuocPhepDichuyen())
        {
            Canguaduocpick.isMoving = true;
            Canguaduocpick.Dichuyen1o();
            Canguaduocpick.XucXac = Xucxac;
            isComing = false;
        }
    }
    private bool KhongKhongCoConNaoNgoaiChuong(SeahorsePlayer a)
    {
        if (a != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    private bool NhanChuotTrai()
    {
        if (Input.GetMouseButton(0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void DeCanguaDichuyen()
    {

        DemSoCaNguaBenNgoai();

        switch (Socabenngoia)
        {
            case 0:
                QuaLuot();
                break;

            case 1:
                ConBenNgoaiTuDiChuyen();
                break;
            default:
                ChonConDiChuyen();
                break;
        }
    }  
    private void DemSoCaNguaBenNgoai()
    {
        for (int i = 0; i < SeahorsePlayers.Count; i++)
        {
            if (SeahorsePlayers[i].isOutside == true)
            {
                Socabenngoia++;
            }
        }
    }
    private void QuaLuot()
    {
        Dice.dice.hasLanded = true;
        Dice.dice.SetDice();
        GameManager.instance.gameList[0].GetComponent<Image>().color = Color.black;
        GameManager.instance.EndTurn();
    } 
    private void ConBenNgoaiTuDiChuyen()
    {
        for (int i = 0; i < SeahorsePlayers.Count; i++)
        {
            if (SeahorsePlayers[i].isOutside == true)
            {
                SeahorsePlayers[i].Firtmove = SeahorsePlayers[i].transform.position;
                isComing = true;
                if (isComing)
                {
                    SeahorsePlayers[i].isMoving = true;
                    SeahorsePlayers[i].Dichuyen1o();
                    SeahorsePlayers[i].XucXac = Xucxac;
                    isComing = false;
                }
            }
        }
        Dice.dice.hasLanded = true;
        Dice.dice.SetDice();
        GameManager.instance.gameList[0].GetComponent<Image>().color = Color.black;
        GameManager.instance.EndTurn();
    }
    private void ChonConDiChuyen()
    {
        if (isLook)
        {
            if (NhanChuotTrai())
            {
                ChoCaNguaDiChuyen();
            }
        }
    }
    private void ChoCaNguaDiChuyen()
    {
        isComing = true ;
        if (DuocPhepDichuyen())
        {
            Canguaduocpick = TimCaNgua();
            if (CoCaNgua(Canguaduocpick))
            {
                Canguaduocpick.Firtmove = Canguaduocpick.transform.position;
                if (Canguaduocpick.isOutside == true)
                {
                    isComing = true;
                    if (DuocPhepDichuyen())
                    {
                        Canguaduocpick.isMoving = true;
                        Canguaduocpick.Dichuyen1o();
                        Canguaduocpick.XucXac = Xucxac;
                        isComing = false;
                    }
                }
                else
                {
                    ChonConDiChuyen();
                }
            }
            isComing = false;
        }
        Dice.dice.hasLanded = true;
        Dice.dice.SetDice();
        GameManager.instance.gameList[0].GetComponent<Image>().color = Color.black;
        GameManager.instance.EndTurn();
        isLook = false;
    }
 
    private bool DuocPhepDichuyen()
    {
        if (isComing)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private SeahorsePlayer TimCaNgua()
    {
        SeahorsePlayer cangua = null;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f)) // Raycast từ camera xuống
        {
            if (hit.collider.CompareTag("SeahorsePlayer"))
            {
                cangua = hit.collider.GetComponent<SeahorsePlayer>();
            }
        }
        return cangua;

    }
    private bool CoCaNgua(SeahorsePlayer a )
    {
        if (a != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }    
    public void StartTurn(int playerIndex)
    {
        if (currentPlayerIndex == playerIndex)
        {
            if (Input.GetKeyDown(KeyCode.Space) && CheckDice == false)
            {
                Dice.dice.RollDice();
                CheckDice = true;
            }
        }
    }
    private bool CheckOnSeahouse()
    {
        int Soluongcanguatrongchuong = 0;
        for (int i = 0; i < 4; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(LocalCanguaDo[i], Vector3.up, out hit, 2f))
            {
                if (hit.collider.CompareTag("SeahorsePlayer"))
                {
                    Soluongcanguatrongchuong++;
                }
            }
        }
        if (Soluongcanguatrongchuong == 4)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private bool CheckWin()
    {
        RaycastHit hit;

        if (Physics.Raycast(move[62] + new Vector3(0, 2, 0), Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("SeahorsePlayer"))
            {
                win6 = true;
            }
        }
        else if (Physics.Raycast(move[61] + new Vector3(0, 2, 0), Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("SeahorsePlayer") && win6 == true)
            {
                win5 = true;
            }
        }
        else if (Physics.Raycast(move[60] + new Vector3(0, 2, 0), Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("SeahorsePlayer") && win6 == true && win5 == true)
            {
                win4 = true;
            }
        }
        else if (Physics.Raycast(move[59] + new Vector3(0, 2, 0), Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("SeahorsePlayer") && win6 == true && win5 == true && win4 == true)
            {
                win3 = true;

            }
            else
            {
                win3 = false;
            }
        }
        return win3;
    }
}










