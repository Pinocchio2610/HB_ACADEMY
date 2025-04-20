using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SeahorseCPU2 : MonoBehaviour
{
    public int lever = 0;
    private Dictionary<int, Vector3> move = Mapmanager.CheckInt();
    public Vector3[] moveGreen = new Vector3[62];
    private int number = 0;
    public int Xucxac;
    public bool isMoving = false;
    public bool isOutside = false;
    public Vector3 Myhome;
    [SerializeField] private Animator anim;
    private string currentAnimName;
    public Vector3 Firtmove;
    public bool CheckVacham = false;
    private Collision maychoi3;

    private void Awake()
    {
        CPU2.instance.SeahorseCPU2.Add(this);
    }
    private void Start()
    {
        for (int i = 29; i < move.Count - 24; i++)
        {
            moveGreen[number] = move[i];
            number++;
        }
        for (int i = 1; i < move.Count - 52; i++)
        {
            moveGreen[number] = move[i];
            number++;
        }
        for (int i = 63; i < move.Count - 12; i++)
        {
            moveGreen[number] = move[i];
            number++;
        }
        CPU2.instance.moveGreen = moveGreen;
    }
    private void Update()
    {
        for (int i = 0; i < moveGreen.Length; i++)
        {
            if (this.transform.position == moveGreen[0])
            {
                this.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else if (this.transform.position == moveGreen[6])
            {
                this.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if (this.transform.position == moveGreen[12])
            {
                this.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else if (this.transform.position == moveGreen[14])
            {
                this.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if (this.transform.position == moveGreen[20])
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (this.transform.position == moveGreen[26])
            {
                this.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if (this.transform.position == moveGreen[28])
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (this.transform.position == moveGreen[34])
            {
                this.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if (this.transform.position == moveGreen[40])
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (this.transform.position == moveGreen[42])
            {
                this.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if (this.transform.position == moveGreen[48])
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (this.transform.position == moveGreen[54])
            {
                this.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if (this.transform.position == moveGreen[55])
            {
                this.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
        }
        if (isMoving)
        {
            Dichuyen1o();
        }

    }
    private void FixedUpdate()
    {
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
    void ChecKComplete()
    {
        Xucxac--;
        if (Xucxac > 0)
        {
            for (int i = 0; i < moveGreen.Length; i++)
            {
                if (transform.position == moveGreen[i])
                {
                    transform.DOMove(moveGreen[i + 1], 1f).onComplete = ChecKComplete;
                }
            }
        }
        else
        {
            CheckVacham = false;
            ChangeAnim("Idle");
        }

    }
    public void Dichuyen1o()
    {
        for (int i = 0; i < moveGreen.Length; i++)
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
                    CPU2.instance.CheckSeahouse();
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
                    CPU2.instance.CheckSeahouse();
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
                    CPU2.instance.CheckSeahouse();
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
                    CPU2.instance.CheckSeahouse();
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
                    CPU2.instance.CheckSeahouse();
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
                    CPU2.instance.CheckSeahouse();
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
                    CPU2.instance.CheckSeahouse();
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
                    CPU2.instance.CheckSeahouse();
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
                    CPU2.instance.CheckSeahouse();
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
                    CPU2.instance.CheckSeahouse();
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
        if(collision.gameObject.CompareTag("CPUGREEN"))
        {
            if (CheckVacham)
            {
                this.transform.position = this.Firtmove;
                Dice.dice.CheckMoveCPU2 = true;
                CPU2.instance.CheckSeahouse();
            }
            else
            {
                Dice.dice.CheckMoveCPU2 = true;
                CPU2.instance.CheckSeahouse();
            }
        }
        if (collision.gameObject.CompareTag("CPUYELLOW"))
        {
            if (lever > collision.gameObject.GetComponent<SeahouseCPU3>().lever)
            {
                maychoi3 = collision;
                if (CheckVacham)
                {
                    collision.gameObject.transform.position = collision.gameObject.GetComponent<SeahouseCPU3>().Myhome;
                }
                else
                {
                    for (int i = 0; i < CPU3.instance.moveYellow.Length; i++)
                    {
                        if (collision.gameObject.transform.position == CPU3.instance.moveYellow[i])
                        {
                            collision.gameObject.transform.position = CPU3.instance.moveYellow[i - 1];
                        }
                    }
                }
            }
            else
            {
                if (CheckVacham)
                {
                    for (int i = 0; i < moveGreen.Length; i++)
                    {
                        if (this.transform.position == moveGreen[i])
                        {
                            this.gameObject.transform.position = moveGreen[i - 1];
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

