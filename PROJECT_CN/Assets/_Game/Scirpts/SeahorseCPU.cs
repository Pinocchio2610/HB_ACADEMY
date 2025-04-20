using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class SeahorseCPU : MonoBehaviour
{
    public int lever = 0;
    public int Xucxac;
    public Vector3[] moveBlue = new Vector3[62];
    private int number = 0;
    private Dictionary<int, Vector3> move = Mapmanager.CheckInt();
    public bool isMoving = false;
    public bool isOutside = false;
    public Vector3 Myhome;
    [SerializeField] private Animator anim;
    private string currentAnimName;
    public Vector3 Firtmove;
    public bool CheckVacham = false;
    private Collision maychoi2;
    private Collision maychoi3;
    private void Awake()
    {
        CPU.instance.SeahorseCPU.Add(this);
    }
    private void Update()
    {
        for (int i = 0; i < moveBlue.Length; i++)
        {
            if (this.transform.position == moveBlue[0])
            {
                this.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if (this.transform.position == moveBlue[6])
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (this.transform.position == moveBlue[12])
            {
                this.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if (this.transform.position == moveBlue[14])
            {
                this.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else if (this.transform.position == moveBlue[20])
            {
                this.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if (this.transform.position == moveBlue[26])
            {
                this.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else if (this.transform.position == moveBlue[28])
            {
                this.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if (this.transform.position == moveBlue[34])
            {
                this.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else if (this.transform.position == moveBlue[40])
            {
                this.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if (this.transform.position == moveBlue[42])
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (this.transform.position == moveBlue[48])
            {
                this.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if (this.transform.position == moveBlue[54])
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (this.transform.position == moveBlue[55])
            {
                this.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
        if (NeuDangOCheDoDiChuyen())
        {
            Dichuyen1o();
        }
    }
    private void FixedUpdate()
    {
        if (maychoi2 != null)
        {
            if (maychoi2.transform.position == maychoi2.gameObject.GetComponent<SeahorseCPU2>().Myhome)
            {
                maychoi2.gameObject.GetComponent<SeahorseCPU2>().ChangeAnim("Idle");
            }
        }
        if (maychoi3 != null)
        {

            if (maychoi3.transform.position == maychoi3.gameObject.GetComponent<SeahouseCPU3>().Myhome)
            {
                maychoi3.gameObject.GetComponent<SeahouseCPU3>().ChangeAnim("Idle");
            }
        }
        if (this.gameObject.transform.position == Myhome)
        {
            ChangeAnim("Idle");
        }
    }
    private bool NeuDangOCheDoDiChuyen()
    {
        if (isMoving)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Start()
    {
        for (int i = 15; i < move.Count - 24; i++)
        {
            moveBlue[number] = move[i];
            number++;
        }
        number = 42;
        for (int i = 1; i < move.Count - 66; i++)
        {
            moveBlue[number] = move[i];
            number++;
        }
        for (int i = 75; i < move.Count; i++)
        {
            moveBlue[number] = move[i];
            number++;
        }
        CPU.instance.moveBlue = moveBlue;
    }
    void ChecKComplete()
    {
        Xucxac--;
        if (Xucxac > 0)
        {
            for (int i = 0; i < moveBlue.Length; i++)
            {
                if (transform.position == moveBlue[i])
                {
                    transform.DOMove(moveBlue[i + 1], 1f).onComplete = ChecKComplete;
                }
            }
        }
        else
        {
            ChangeAnim("Idle");
            CheckVacham = false;
        }
    }
    public void Dichuyen1o()
    {
        for (int i = 0; i < moveBlue.Length; i++)
        {
            if (this.transform.position == move[i])
            {
                transform.DOMove(move[i + 1], 1f).onComplete = ChecKComplete;
                ChangeAnim("Walk");
                CheckVacham = true;
                isMoving = false;
            }
            if (this.transform.position == move[61])
            {
                if (Xucxac == 6)
                {
                    transform.DOMove(move[i + 1], 1f);
                    ChangeAnim("Walk");
                    CheckVacham = true;
                    if (this.transform.position == move[i + 1])
                    {
                        ChangeAnim("Idle");
                        CheckVacham = false;
                    }
                }
                else
                {
                    CPU.instance.CheckSeahouse();
                }
            }
            if (this.transform.position == move[60])
            {
                if (Xucxac == 5)
                {
                    transform.DOMove(move[i + 1], 1f);
                    ChangeAnim("Walk");
                    CheckVacham = true;
                    if (this.transform.position == move[i + 1])
                    {
                        ChangeAnim("Idle");
                        CheckVacham = false;
                    }
                }
                else
                {
                    CPU.instance.CheckSeahouse();
                }
            }
            if (this.transform.position == move[59])
            {
                if (Xucxac == 4)
                {
                    transform.DOMove(move[i + 1], 1f);
                    ChangeAnim("Walk");
                    CheckVacham = true;
                    if (this.transform.position == move[i + 1])
                    {
                        ChangeAnim("Idle");
                        CheckVacham = false;
                    }
                }
                else
                {
                    CPU.instance.CheckSeahouse();
                }
            }
            if (this.transform.position == move[58])
            {
                if (Xucxac == 3)
                {
                    transform.DOMove(move[i + 1], 1f);
                    ChangeAnim("Walk");
                    CheckVacham = true;
                    if (this.transform.position == move[i + 1])
                    {
                        ChangeAnim("Idle");
                        CheckVacham = false;
                    }
                }
                else
                {
                    CPU.instance.CheckSeahouse();
                }
            }
            if (this.transform.position == move[57])
            {
                if (Xucxac == 2)
                {
                    transform.DOMove(move[i + 1], 1f);
                    ChangeAnim("Walk");
                    CheckVacham = true;
                    if (this.transform.position == move[i + 1])
                    {
                        ChangeAnim("Idle");
                        CheckVacham = false;
                    }
                }
                else
                {
                    CPU.instance.CheckSeahouse();
                }
            }
            if (this.transform.position == move[55])
            {
                if (Xucxac == 1)
                {
                    transform.DOMove(move[i + 1], 1f).onComplete = ChecKComplete;
                    CheckVacham = true;
                    ChangeAnim("Walk");
                }
                else
                {
                    CPU.instance.CheckSeahouse();
                }
            }
            if (this.transform.position == move[54])
            {
                if (Xucxac == 1 || Xucxac == 2)
                {
                    transform.DOMove(move[i + 1], 1f).onComplete = ChecKComplete;
                    CheckVacham = true;
                    ChangeAnim("Walk");
                }
                else
                {
                    CPU.instance.CheckSeahouse();
                }
            }
            if (this.transform.position == move[53])
            {
                if (Xucxac == 1 || Xucxac == 2 || Xucxac == 3)
                {
                    transform.DOMove(move[i + 1], 1f).onComplete = ChecKComplete;
                    CheckVacham = true;
                    ChangeAnim("Walk");
                }
                else
                {
                    CPU.instance.CheckSeahouse();
                }
            }
            if (this.transform.position == move[52])
            {
                if (Xucxac == 1 || Xucxac == 2 || Xucxac == 3 || Xucxac == 4)
                {
                    transform.DOMove(move[i + 1], 1f).onComplete = ChecKComplete;
                    CheckVacham = true;
                    ChangeAnim("Walk");
                }
                else
                {
                    CPU.instance.CheckSeahouse();
                }
            }
            if (this.transform.position == move[51])
            {
                if (Xucxac == 1 || Xucxac == 2 || Xucxac == 3 || Xucxac == 4 || Xucxac == 5)
                {
                    transform.DOMove(move[i + 1], 1f).onComplete = ChecKComplete;
                    CheckVacham = true;
                    ChangeAnim("Walk");
                }
                else
                {
                    CPU.instance.CheckSeahouse();
                }
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("mana"))
        {
            lever += 2;
            other.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CPUBLUE1"))
        {
            if (CheckVacham)
            {
                this.transform.position = this.Firtmove;
                Dice.dice.CheckMoveCPU = true;
                CPU.instance.CheckSeahouse();
            }
            else
            {
                Dice.dice.CheckMoveCPU = true;
                CPU.instance.CheckSeahouse();
            }
        }
        if (collision.gameObject.CompareTag("CPUGREEN"))
        {
            maychoi2 = collision;
            if (lever > collision.gameObject.GetComponent<SeahorseCPU2>().lever)
            {
                if (CheckVacham)
                {
                    collision.gameObject.transform.position = collision.gameObject.GetComponent<SeahorseCPU2>().Myhome;
                }
                else
                {
                    for (int i = 0; i < collision.gameObject.GetComponent<SeahorseCPU2>().moveGreen.Length; i++)
                    {
                        if (collision.gameObject.transform.position == collision.gameObject.GetComponent<SeahorseCPU2>().moveGreen[i])
                        {
                            collision.gameObject.transform.position = collision.gameObject.GetComponent<SeahorseCPU2>().moveGreen[i - 1];
                        }    
                    } 
                        
                }
            }
            else
            {
                if (CheckVacham)
                {
                    for (int i = 0; i < moveBlue.Length; i++)
                    {
                        if (this.transform.position == moveBlue[i])
                        {
                            this.gameObject.transform.position = moveBlue[i - 1];
                        }

                    }

                }
                else
                {
                    this.transform.position = Myhome;
                }
            }
        }
        if (collision.gameObject.CompareTag("CPUYELLOW"))
        {
            maychoi3 = collision;
            if (lever > collision.gameObject.GetComponent<SeahouseCPU3>().lever)
            {
                if (CheckVacham)
                {
                    collision.gameObject.transform.position = collision.gameObject.GetComponent<SeahouseCPU3>().Myhome;
                }
                else
                {
                    for (int i = 0; i < collision.gameObject.GetComponent<SeahouseCPU3>().moveYellow.Length; i++)
                    {
                        if (collision.gameObject.transform.position == collision.gameObject.GetComponent<SeahouseCPU3>().moveYellow[i])
                        {
                            collision.gameObject.transform.position = collision.gameObject.GetComponent<SeahouseCPU3>().moveYellow[i - 1];
                        }
                    }
                }
            }
            else
            {
                if (CheckVacham)
                {
                    for (int i = 0; i < moveBlue.Length; i++)
                    {
                        if (this.transform.position == moveBlue[i])
                        {
                            this.gameObject.transform.position = moveBlue[i - 1];
                        }
                    }
                }
                else
                {
                    this.transform.position = Myhome;
                }
            }
        }
    }
    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }
}
