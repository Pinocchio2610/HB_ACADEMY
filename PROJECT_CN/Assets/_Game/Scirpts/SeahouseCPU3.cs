using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class SeahouseCPU3 : MonoBehaviour
{
    public int lever = 0;
    private Dictionary<int, Vector3> move = Mapmanager.CheckInt();
    public Vector3[] moveYellow = new Vector3[62];
    private int number = 0;
    public int Xucxac;
    public bool isMoving = false;
    public bool isOutside = false;
    public Vector3 Myhome;
    [SerializeField] private Animator anim;
    private string currentAnimName;
    public Vector3 Firtmove;
    public bool CheckVacham = false;

    private void Awake()
    {
        CPU3.instance.SeahorseCPU3.Add(this);
    }
    private void Start()
    {
        for (int i = 43; i < move.Count - 24; i++)
        {
            moveYellow[number] = move[i];
            number++;
        }
        for (int i = 1; i < move.Count - 38; i++)
        {
            moveYellow[number] = move[i];
            number++;
        }
        for (int i = 69; i < move.Count - 6; i++)
        {
            moveYellow[number] = move[i];
            number++;
        }
        CPU3.instance.moveYellow = moveYellow;
    }
    private void Update()
    {

        for (int i = 0; i < moveYellow.Length; i++)
        {
            if (this.transform.position == moveYellow[0])
            {
                this.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if (this.transform.position == moveYellow[6])
            {
                this.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else if (this.transform.position == moveYellow[12])
            {
                this.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if (this.transform.position == moveYellow[14])
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (this.transform.position == moveYellow[20])
            {
                this.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if (this.transform.position == moveYellow[26])
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (this.transform.position == moveYellow[28])
            {   
                this.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if (this.transform.position == moveYellow[34])
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (this.transform.position == moveYellow[40])
            {
                this.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if (this.transform.position == moveYellow[42])
            {
                this.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else if (this.transform.position == moveYellow[48])
            {
                this.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if (this.transform.position == moveYellow[54])
            {
                this.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else if (this.transform.position == moveYellow[55])
            {
                this.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }
        if (isMoving)
        {
            Dichuyen1o();
        }
    }
    void ChecKComplete()
    {
        Xucxac--;
        if (Xucxac > 0)
        {
            for (int i = 0; i < moveYellow.Length; i++)
            {
                if (transform.position == moveYellow[i])
                {
                    transform.DOMove(moveYellow[i + 1], 1f).onComplete = ChecKComplete;
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
        for (int i = 0; i < moveYellow.Length; i++)
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
                    CPU3.instance.CheckSeahouse();
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
                    CPU3.instance.CheckSeahouse();
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
                    CPU3.instance.CheckSeahouse();
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
                    CPU3.instance.CheckSeahouse();
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
                    CPU3.instance.CheckSeahouse();
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
                    CPU3.instance.CheckSeahouse();
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
                    CPU3.instance.CheckSeahouse();
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
                    CPU3.instance.CheckSeahouse();
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
                    CPU3.instance.CheckSeahouse();
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
                    CPU3.instance.CheckSeahouse();
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
        if (collision.gameObject.CompareTag("CPUYELLOW"))
        {
            if (CheckVacham)
            {
                this.transform.position = this.Firtmove;
                Dice.dice.CheckMoveCPU3 = true;
                CPU3.instance.CheckSeahouse();
            }
            else
            {
                Dice.dice.CheckMoveCPU3 = true;
                CPU3.instance.CheckSeahouse();
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
