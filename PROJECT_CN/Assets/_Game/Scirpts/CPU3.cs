using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class CPU3 : MonoBehaviour
{
    public Vector3[] moveYellow;
    public int Xucxac;
    public static CPU3 instance;
    public List<SeahouseCPU3> SeahorseCPU3 = new List<SeahouseCPU3>();
    private bool isComing = false;
    private bool isBook = false;
    private bool isLook = false;
    private List<SeahouseCPU3> OnisSide = new List<SeahouseCPU3>();
    private bool win6 = false;
    private bool win5 = false;
    private bool win4 = false;
    private bool win3 = false;
    public GameObject Winer;
    private SeahouseCPU3 CanguaduocpickCPU3;
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
            CanguaduocpickCPU3 = TimCaNgua();
            if (CanguaduocpickCPU3 != null)
            {
                CanguaduocpickCPU3.Firtmove = CanguaduocpickCPU3.transform.position;
                if (CanguaduocpickCPU3.isOutside == true)
                {
                    isComing = true;
                    if (isComing)
                    {
                        CanguaduocpickCPU3.isMoving = true;
                        CanguaduocpickCPU3.Dichuyen1o();
                        CanguaduocpickCPU3.Xucxac = Xucxac;
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
        for (int i = 0; i < SeahorseCPU3.Count; i++)
        {
            SeahorseCPU3[i].Firtmove = SeahorseCPU3[i].transform.position;
            if (SeahorseCPU3[i].isOutside == true)
            {
                isComing = true;
                if (isComing)
                {
                    SeahorseCPU3[i].isMoving = true;
                    SeahorseCPU3[i].Dichuyen1o();
                    SeahorseCPU3[i].Xucxac = Xucxac;
                    isComing = false;
                }
            }
        }
    }
    private int DemCaNgua()
    {
        int Socabenngoia = 0;
        for (int i = 0; i < SeahorseCPU3.Count; i++)
        {
            if (SeahorseCPU3[i].isOutside == true)
            {
                Socabenngoia++;
            }
        }
        return Socabenngoia;
    }
    private void ChonCaNgua()
    {
        isBook = true;
        CanguaduocpickCPU3 = TimCaNgua();
        if (CaNGuaKhongRong(CanguaduocpickCPU3))
        {
            CanguaduocpickCPU3.Firtmove = CanguaduocpickCPU3.transform.position;
            if (CoCaNguaTrongChuong(CanguaduocpickCPU3))
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
            CanguaduocpickCPU3.isMoving = true;
            CanguaduocpickCPU3.Dichuyen1o();
            CanguaduocpickCPU3.Xucxac = Xucxac;
        }
    }
    private void XuatChuong()
    {
        CanguaduocpickCPU3.Myhome = CanguaduocpickCPU3.transform.position;
        CanguaduocpickCPU3.transform.position = moveYellow[0];
        CanguaduocpickCPU3.isOutside = true;
        OnisSide.Add(CanguaduocpickCPU3);
    }
    private bool CoCaNguaTrongChuong(SeahouseCPU3 a)
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
    private bool CaNGuaKhongRong(SeahouseCPU3 a)
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
    private SeahouseCPU3 TimCaNgua()
    {

        SeahouseCPU3 cangua = null;
        if (Xucxac == 6 && isBook == true)
        {
            if (OnisSide.Count == 0)
            {
                for (int i = 0; i < SeahorseCPU3.Count; i++)
                {
                    if (SeahorseCPU3[i].isOutside == false)
                    {
                        cangua = SeahorseCPU3[i];
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
                    for (int i = 0; i < SeahorseCPU3.Count; i++)
                    {
                        cangua = SeahorseCPU3[Random.Range(0, SeahorseCPU3.Count)];
                    }

                }
            }
            isBook = false;
        }
        else
        {
            for (int i = 0; i < SeahorseCPU3.Count; i++)
            {
                if (SeahorseCPU3[i].isOutside == true)
                {
                    cangua = SeahorseCPU3[i];
                }
            }

        }
        return cangua;
    }
    private bool CheckBoxStart()
    {
        bool a = false;
        RaycastHit hit;

        if (Physics.Raycast(moveYellow[0] + new Vector3(0, 2, 0), Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.CompareTag("CPUYELLOW"))
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

        if (Physics.Raycast(moveYellow[61] + new Vector3(0, 2, 0), Vector3.down, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(moveYellow[61] + new Vector3(0, 2, 0), Vector3.down, Color.red, Mathf.Infinity);
            if (hit.collider.CompareTag("SeahorsePlayer"))
            {
                win6 = true;
            }
        }
         if (Physics.Raycast(moveYellow[60] + new Vector3(0, 2, 0), Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("SeahorsePlayer") && win6 == true)
            {
                win5 = true;
            }
        }
         if (Physics.Raycast(moveYellow[59] + new Vector3(0, 2, 0), Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("SeahorsePlayer") && win6 == true && win5 == true)
            {
                win4 = true;
            }
        }
         if (Physics.Raycast(moveYellow[58] + new Vector3(0, 2, 0), Vector3.down, out hit, Mathf.Infinity))
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
