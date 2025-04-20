using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CPU2 : MonoBehaviour
{
    public Vector3[] moveGreen;
    public int Xucxac;
    public static CPU2 instance;
    public List<SeahorseCPU2> SeahorseCPU2 = new List<SeahorseCPU2>();
    private bool isComing = false;
    private bool isBook = false;
    private bool isLook = false;
    private List<SeahorseCPU2> OnisSide = new List<SeahorseCPU2>();
    private bool win6 = false;
    private bool win5 = false;
    private bool win4 = false;
    private bool win3 = false;
    public GameObject Winer;
    private SeahorseCPU2 CanguaduocpickCPU2;
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
    private void Update()
    {

        if (CheckWin() == true)
        {
            Winer.gameObject.SetActive(true);
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
             CanguaduocpickCPU2 = TimCaNgua();
            if (CanguaduocpickCPU2 != null)
            {
                CanguaduocpickCPU2.Firtmove = CanguaduocpickCPU2.transform.position;
                if (CanguaduocpickCPU2.isOutside == true)
                {
                    isComing = true;
                    if (isComing)
                    {
                        CanguaduocpickCPU2.isMoving = true;
                        CanguaduocpickCPU2.Dichuyen1o();
                        CanguaduocpickCPU2.Xucxac = Xucxac;
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
        for (int i = 0; i < SeahorseCPU2.Count; i++)
        {
            SeahorseCPU2[i].Firtmove = SeahorseCPU2[i].transform.position;
            if (SeahorseCPU2[i].isOutside == true)
            {
                isComing = true;
                if (isComing)
                {
                    SeahorseCPU2[i].isMoving = true;
                    SeahorseCPU2[i].Dichuyen1o();
                    SeahorseCPU2[i].Xucxac = Xucxac;
                    isComing = false;
                }
            }
        }
    }
    private int DemCaNgua()
    {
        int Socabenngoia = 0;
        for (int i = 0; i < SeahorseCPU2.Count; i++)
        {
            if (SeahorseCPU2[i].isOutside == true)
            {
                Socabenngoia++;
            }
        }
        return Socabenngoia;
    }
    private void ChonCaNgua()
    {
        isBook = true;
        CanguaduocpickCPU2 = TimCaNgua();
        if (CaNGuaKhongRong(CanguaduocpickCPU2))
        {
            CanguaduocpickCPU2.Firtmove = CanguaduocpickCPU2.transform.position;
            if (CoCaNguaTrongChuong(CanguaduocpickCPU2))
            {
                XuatChuong();
            }
            else
            {
                Dichuyen6();
            }
            Dice.dice.CheckMoveCPU2 = false;
        }
    }
    private void Dichuyen6()
    {
        isComing = true;
        if (isComing)
        {
            CanguaduocpickCPU2.isMoving = true;
            CanguaduocpickCPU2.Dichuyen1o();
            CanguaduocpickCPU2.Xucxac = Xucxac;
        }
    }
    private void XuatChuong()
    {
        CanguaduocpickCPU2.Myhome = CanguaduocpickCPU2.transform.position;
        CanguaduocpickCPU2.transform.position = moveGreen[0];
        CanguaduocpickCPU2.isOutside = true;
        OnisSide.Add(CanguaduocpickCPU2);
    }
    private bool CoCaNguaTrongChuong(SeahorseCPU2 a)
    {
        if (a.isOutside == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool CaNGuaKhongRong(SeahorseCPU2 a)
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
    private SeahorseCPU2 TimCaNgua()
    {

        SeahorseCPU2 cangua = null;
        if (Xucxac == 6 && isBook == true)
        {
            if (OnisSide.Count == 0)
            {
                for (int i = 0; i < SeahorseCPU2.Count; i++)
                {
                    if (SeahorseCPU2[i].isOutside == false)
                    {
                        cangua = SeahorseCPU2[i];
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
                    for (int i = 0; i < SeahorseCPU2.Count; i++)
                    {
                        cangua = SeahorseCPU2[Random.Range(0, SeahorseCPU2.Count)];
                    }

                }
            }
            isBook = false;
        }
        else
        {
            for (int i = 0; i < SeahorseCPU2.Count; i++)
            {
                if (SeahorseCPU2[i].isOutside == true)
                {
                    cangua = SeahorseCPU2[i];
                }
            }

        }
        return cangua;
    }
    private bool CheckBoxStart()
    {
        bool a = false;
        RaycastHit hit;

        if (Physics.Raycast(moveGreen[0] + new Vector3(0, 2, 0), Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.CompareTag("CPUGREEN"))
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

        if (Physics.Raycast(moveGreen[61] + new Vector3(0, 2, 0), Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("SeahorsePlayer"))
            {
                win6 = true;
            }
        }
        if (Physics.Raycast(moveGreen[60] + new Vector3(0, 2, 0), Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("SeahorsePlayer") && win6 == true)
            {
                win5 = true;
            }
        }
        if (Physics.Raycast(moveGreen[59] + new Vector3(0, 2, 0), Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("SeahorsePlayer") && win6 == true && win5 == true)
            {
                win4 = true;
            }
        }
        if (Physics.Raycast(moveGreen[58] + new Vector3(0, 2, 0), Vector3.down, out hit, Mathf.Infinity))
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
