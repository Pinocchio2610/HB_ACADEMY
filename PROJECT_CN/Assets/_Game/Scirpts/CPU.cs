using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.ContentSizeFitter;

public class CPU : MonoBehaviour
{
    public Vector3[] moveBlue;
    public int Xucxac;
    public static CPU instance;
    public bool CheckXX;
    public bool CheckCPU;
    public List<SeahorseCPU> SeahorseCPU = new List<SeahorseCPU>();
    public bool isComing = false;
    private bool isBook = false;
    private bool isLook = false;
    private List<SeahorseCPU> OnisSide = new List<SeahorseCPU>();
    private bool win6 = false;
    private bool win5 = false;
    private bool win4 = false;
    private bool win3 = false;
    public GameObject Winer;
    SeahorseCPU CanguaduocpickCPU;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        { Destroy(gameObject); }
    }
    private void Update()
    {
        if (CheckWin() == true)
        {
            BatCanvasWinner();
        }
    }
    private void BatCanvasWinner()
    {
        Winer.gameObject.SetActive(true);
    }

    public void CheckSeahouse()
    {
        isLook = true;
        if (XucXacBang6(Xucxac))
        {
            ChonCaNgua();
        }
        else
        {
            ThuchienDiChuyen();
        }
    }
    private void ThuchienDiChuyen()
    {
        DemCaNgua();

        switch (DemCaNgua())
        {
            case 0:
                break;
            case 1:
                DichuyenConNgoaiChuong();
                break;
            default:
                ChonConDeDichuyen();
                break;
        }
        Dice.dice.CheckMoveCPU = false;
    }    
    private void ChonConDeDichuyen()
    {
        if (isLook)
        {
             CanguaduocpickCPU = TimCaNgua();
            if (CanguaduocpickCPU != null)
            {
                CanguaduocpickCPU.Firtmove = CanguaduocpickCPU.transform.position;
                if (CanguaduocpickCPU.isOutside == true)
                {
                    isComing = true;
                    if (isComing)
                    {
                        CanguaduocpickCPU.isMoving = true;
                        CanguaduocpickCPU.Dichuyen1o();
                        CanguaduocpickCPU.Xucxac = Xucxac;
                    }
                }
                else
                {
                    ChonConDeDichuyen();
                }
            }
        }
    }    
    private void DichuyenConNgoaiChuong()
    {
        for (int i = 0; i < SeahorseCPU.Count; i++)
        {
            SeahorseCPU[i].Firtmove = SeahorseCPU[i].transform.position;
            if (SeahorseCPU[i].isOutside == true)
            {
                isComing = true;
                if (isComing)
                {
                    SeahorseCPU[i].isMoving = true;
                    SeahorseCPU[i].Dichuyen1o();
                    SeahorseCPU[i].Xucxac = Xucxac;
                    isComing = false;
                }
            }
        }
    }    
    private int DemCaNgua()
    {
        int Socabenngoia = 0;
        for (int i = 0; i < SeahorseCPU.Count; i++)
        {
            if (SeahorseCPU[i].isOutside == true)
            {
                Socabenngoia++;
            }
        }
        return Socabenngoia;
    }    
    private void ChonCaNgua()
    {
        isBook = true;
        CanguaduocpickCPU = TimCaNgua();
        if (CaNGuaKhongRong(CanguaduocpickCPU))
        {
            CanguaduocpickCPU.Firtmove = CanguaduocpickCPU.transform.position;
            if (CoCaNguaTrongChuong(CanguaduocpickCPU))
            {
                XuatChuong();
            }
            else
            {
                Dichuyen6();
            }
            Dice.dice.CheckMoveCPU = false;
        }
    }   
    private void Dichuyen6()
    {
        isComing = true;
        if (isComing)
        {
            CanguaduocpickCPU.isMoving = true;
            CanguaduocpickCPU.Dichuyen1o();
            CanguaduocpickCPU.Xucxac = Xucxac;
        }
    }    
    private void XuatChuong()
    {
        CanguaduocpickCPU.Myhome = CanguaduocpickCPU.transform.position;
        CanguaduocpickCPU.transform.position = moveBlue[0];
        CanguaduocpickCPU.isOutside = true;
        OnisSide.Add(CanguaduocpickCPU);
    }    
    private bool CoCaNguaTrongChuong(SeahorseCPU a)
    {
        if(a.isOutside == false)
        {
            return true;
        }    
        else
        {
            return false;
        }    
    }    
    private bool CaNGuaKhongRong(SeahorseCPU a)
    {
        if (a != null)
        {
            return true;
        }
        else { return false; }
    }
    private bool XucXacBang6(int a)
    {
        if (a == 6)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private SeahorseCPU TimCaNgua()
    {

        SeahorseCPU cangua = null;
        if (Xucxac == 6 && isBook == true)
        {
            if (OnisSide.Count == 0)
            {
                for (int i = 0; i < SeahorseCPU.Count; i++)
                {
                    if (SeahorseCPU[i].isOutside == false)
                    {
                        cangua = SeahorseCPU[i];
                    }
                }
            }
            else
            {
                if (CheckBoxStart() == true)
                {
                    for (int i = 0; i < OnisSide.Count; i++)
                        if (OnisSide[i] == true)
                        {
                            cangua = OnisSide[i];
                        }
                }
                else
                {
                    for (int i = 0; i < SeahorseCPU.Count; i++)
                    {
                        cangua = SeahorseCPU[Random.Range(0, SeahorseCPU.Count)];
                    }

                }
            }
            isBook = false;
        }
        else
        {
            for (int i = 0; i < SeahorseCPU.Count; i++)
            {
                if (SeahorseCPU[i].isOutside == true)
                {
                    cangua = SeahorseCPU[i];
                }
            }

        }
        return cangua;
    }
    private bool CheckBoxStart()
    {
        bool a = false;
        RaycastHit hit;
        Debug.DrawRay(moveBlue[0] + Vector3.up, Vector3.down, Color.yellow, 2f);
        if (Physics.Raycast(moveBlue[0] + new Vector3(0, 2, 0), Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.CompareTag("CPUBLUE1"))
            {
                return a = true;
            }
            else
            {
                return a = false;
            }
        }
        return a;
    }
    private bool CheckWin()
    {
        RaycastHit hit;

        if (Physics.Raycast(moveBlue[61] + new Vector3(0, 2, 0), Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("SeahorsePlayer"))
            {
                win6 = true;
            }
        }
        else if (Physics.Raycast(moveBlue[60] + new Vector3(0, 2, 0), Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("SeahorsePlayer") && win6 == true)
            {
                win5 = true;
            }
        }
        else if (Physics.Raycast(moveBlue[59] + new Vector3(0, 2, 0), Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("SeahorsePlayer") && win6 == true && win5 == true)
            {
                win4 = true;
            }
        }
        else if (Physics.Raycast(moveBlue[58] + new Vector3(0, 2, 0), Vector3.down, out hit, Mathf.Infinity))
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
