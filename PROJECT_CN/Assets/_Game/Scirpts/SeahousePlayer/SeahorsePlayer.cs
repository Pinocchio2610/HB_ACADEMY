using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class SeahorsePlayer : MonoBehaviour
{

    public bool isOutside = false;
    int lever = 0;
    public int vittri;
    private Dictionary<int, Vector3> move = Mapmanager.CheckInt();
    public int XucXac;
    public bool isMoving = false;
    public Vector3 Myhome;
    [SerializeField] private Animator anim;
    private string currentAnimName;
    public bool CheckVacham = false;
    public Vector3 Firtmove;
    private State currentstate;
    private Collision maychoi1;
    private Collision maychoi2;
    private Collision maychoi3;

    private void Awake()
    {
        Player.Instance.SeahorsePlayers.Add(this);
    }
    private void Update()
    {
        for (int i = 0; i < move.Count; i++)
        {
            if (this.transform.position == move[7])
            {
                this.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if (this.transform.position == move[13])
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (this.transform.position == move[15])
            {
                this.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if (this.transform.position == move[21])
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (this.transform.position == move[27])
            {
                this.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if (this.transform.position == move[29])
            {
                this.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else if (this.transform.position == move[35])
            {
                this.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if (this.transform.position == move[41])
            {
                this.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else if (this.transform.position == move[43])
            {
                this.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if (this.transform.position == move[49])
            {
                this.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else if (this.transform.position == move[55])
            {
                this.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if (this.transform.position == move[56])
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        if (currentstate != null)
        {

        }
    }
    private void FixedUpdate()
    {
        if (maychoi1 != null)
        {
            if (maychoi1.transform.position == maychoi1.gameObject.GetComponent<SeahorseCPU>().Myhome)
            {
                maychoi1.gameObject.GetComponent<SeahorseCPU>().ChangeAnim("Idle");
            }
        }
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
    void ChecKComplete()
    {
        XucXac--;
        if (XucXac > 0)
        {
            for (int i = 0; i < move.Count - 20; i++)
            {
                if (transform.position == move[i])
                {
                    transform.DOMove(move[i + 1], 1f).onComplete = ChecKComplete;
                }
            }
            for (int i = 0; i < move.Count; i++)
            {
                if (this.transform.position == move[7])
                {
                    this.transform.rotation = Quaternion.Euler(0, 90, 0);
                }
                else if (this.transform.position == move[13])
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (this.transform.position == move[15])
                {
                    this.transform.rotation = Quaternion.Euler(0, -90, 0);
                }
                else if (this.transform.position == move[21])
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (this.transform.position == move[27])
                {
                    this.transform.rotation = Quaternion.Euler(0, -90, 0);
                }
                else if (this.transform.position == move[29])
                {
                    this.transform.rotation = Quaternion.Euler(0, -180, 0);
                }
                else if (this.transform.position == move[35])
                {
                    this.transform.rotation = Quaternion.Euler(0, -90, 0);
                }
                else if (this.transform.position == move[41])
                {
                    this.transform.rotation = Quaternion.Euler(0, -180, 0);
                }
                else if (this.transform.position == move[43])
                {
                    this.transform.rotation = Quaternion.Euler(0, 90, 0);
                }
                else if (this.transform.position == move[49])
                {
                    this.transform.rotation = Quaternion.Euler(0, -180, 0);
                }
                else if (this.transform.position == move[55])
                {
                    this.transform.rotation = Quaternion.Euler(0, 90, 0);
                }
                else if (this.transform.position == move[56])
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
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
        for (int i = 0; i < move.Count - 20; i++)
        {
            if (this.transform.position == move[i])
            {
                transform.DOMove(move[i + 1], 1f).onComplete = ChecKComplete;
                ChangeAnim("Walk");
                CheckVacham = true;
                isMoving = false;

            }
            if (this.transform.position == move[55])
            {
                if (XucXac == 1)
                {
                    CheckVacham = true;
                    transform.DOMove(move[i + 1], 1f);
                    ChangeAnim("Walk");
                    isMoving = false;
                    if (this.transform.position == move[i + 1])
                    {
                        ChangeAnim("Idle");
                        CheckVacham = false;
                    }

                }
                else
                {
                    Player.Instance.SeahorePlayers();
                }
            }
            if (this.transform.position == move[55])
            {

                if (XucXac == 1)
                {
                    transform.DOMove(move[i + 1], 1f);
                    ChangeAnim("Walk");
                    CheckVacham = true;
                    isMoving = false;
                    if (this.transform.position == move[i + 1])
                    {
                        ChangeAnim("Idle");
                        CheckVacham = false;
                    }
                }
                else
                {
                    Player.Instance.SeahorePlayers();
                }
            }
            if (this.transform.position == move[51])
            {
                if (XucXac == 1 || XucXac == 2 || XucXac == 3 || XucXac == 4 || XucXac == 5)
                {
                    transform.DOMove(move[i + 1], 1f).onComplete = ChecKComplete;
                    ChangeAnim("Walk");
                    isMoving = false;
                    CheckVacham = true;
                }
                else
                {
                    Player.Instance.SeahorePlayers();
                }
            }
            if (this.transform.position == move[52])
            {
                if (XucXac == 1 || XucXac == 2 || XucXac == 3 || XucXac == 4)
                {
                    transform.DOMove(move[i + 1], 1f).onComplete = ChecKComplete;
                    ChangeAnim("Walk");
                    isMoving = false;
                    CheckVacham = true;
                }
                else
                {
                    Player.Instance.SeahorePlayers();
                }
            }
            if (this.transform.position == move[53])
            {
                if (XucXac == 1 || XucXac == 2 || XucXac == 3)
                {
                    transform.DOMove(move[i + 1], 1f).onComplete = ChecKComplete;
                    ChangeAnim("Walk");
                    isMoving = false;
                    CheckVacham = true;
                }
                else
                {
                    Player.Instance.SeahorePlayers();
                }
            }
            if (this.transform.position == move[54])
            {
                if (XucXac == 2 || XucXac == 1)
                {
                    transform.DOMove(move[i + 1], 1f).onComplete = ChecKComplete;
                    ChangeAnim("Walk");
                    isMoving = false;
                    CheckVacham = true;
                }
                else
                {
                    Player.Instance.SeahorePlayers();
                }
            }
            if (this.transform.position == move[55])
            {
                if (XucXac == 1)
                {
                    transform.DOMove(move[i + 1], 1f).onComplete = ChecKComplete;
                    ChangeAnim("Walk");
                    isMoving = false;
                    CheckVacham = true;
                }
                else
                {
                    Player.Instance.SeahorePlayers();
                }
            }
            if (this.transform.position == move[57])
            {
                if (XucXac == 2)
                {
                    transform.DOMove(move[i + 1], 1f);
                    ChangeAnim("Walk");
                    isMoving = false;
                    CheckVacham = true;
                    if (this.transform.position == move[i + 1])
                    {
                        ChangeAnim("Idle");
                        CheckVacham = false;
                    }
                }
                else
                {
                    Player.Instance.SeahorePlayers();
                }
            }
            if (this.transform.position == move[58])
            {
                if (XucXac == 3)
                {
                    transform.DOMove(move[i + 1], 1f);
                    ChangeAnim("Walk");
                    isMoving = false;
                    CheckVacham = true;
                    if (this.transform.position == move[i + 1])
                    {
                        ChangeAnim("Idle");
                        CheckVacham = false;
                    }
                }
                else
                {
                    Player.Instance.SeahorePlayers();
                }
            }
            if (this.transform.position == move[59])
            {
                if (XucXac == 4)
                {
                    transform.DOMove(move[i + 1], 1f);
                    ChangeAnim("Walk");
                    isMoving = false;
                    CheckVacham = true;
                    if (this.transform.position == move[i + 1])
                    {
                        ChangeAnim("Idle");
                        CheckVacham = false;
                    }
                }
                else
                {
                    Player.Instance.SeahorePlayers();
                }
            }
            if (this.transform.position == move[60])
            {
                if (XucXac == 5)
                {
                    transform.DOMove(move[i + 1], 1f);
                    ChangeAnim("Walk");
                    isMoving = false;
                    CheckVacham = true;
                    if (this.transform.position == move[i + 1])
                    {
                        ChangeAnim("Idle");
                        CheckVacham = false;
                    }
                }
                else
                {
                    ChangeAnim("Idle");
                    Player.Instance.SeahorePlayers();
                }
            }
            if (this.transform.position == move[61])
            {
                if (XucXac == 2)
                {
                    transform.DOMove(move[i + 1], 1f);
                    ChangeAnim("Walk");
                    isMoving = false;
                    CheckVacham = true;
                    if (this.transform.position == move[i + 1])
                    {
                        ChangeAnim("Idle");
                        CheckVacham = false;
                    }
                }
                else
                {
                    Player.Instance.SeahorePlayers();
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
        if (collision.gameObject.CompareTag("SeahorsePlayer"))
        {
            if (CheckVacham)
            {
                this.transform.position = this.Firtmove;
                collision.gameObject.transform.position = collision.transform.position;
                Dice.dice.CheckMovePlayer = true;
                Player.Instance.SeahorePlayers();
            }
            else
            {
                collision.gameObject.transform.position = collision.gameObject.transform.position;
            }
        }
        if (collision.gameObject.CompareTag("CPUBLUE1"))
        {
            maychoi1 = collision;
            if (lever > collision.gameObject.GetComponent<SeahorseCPU>().lever)
            {
                if (CheckVacham)
                {
                    this.ChangeAnim("Attack");
                    collision.gameObject.GetComponent<SeahorseCPU>().ChangeAnim("Death");
                    collision.gameObject.transform.position = collision.gameObject.GetComponent<SeahorseCPU>().Myhome;
                }
                else
                {
                    for (int i = 0; i < collision.gameObject.GetComponent<SeahorseCPU>().moveBlue.Length; i++)
                    {
                        if (collision.gameObject.transform.position == collision.gameObject.GetComponent<SeahorseCPU>().moveBlue[i])
                        {
                            collision.gameObject.transform.position = collision.gameObject.GetComponent<SeahorseCPU>().moveBlue[i-1];
                        }
                    }
                }
            }
            else
            {
                if (CheckVacham)
                {
                    for (int i = 0; i < move.Count - 17; i++)
                    {
                        if (this.transform.position == move[i])
                        {
                            this.gameObject.transform.position = move[i - 1];
                        }
                    }

                }
                else
                {
                    collision.gameObject.GetComponent<SeahorseCPU>().ChangeAnim("Attack");
                    this.ChangeAnim("Death");
                    this.transform.position = Myhome;

                }
            }
        }
        if (collision.gameObject.CompareTag("CPUGREEN"))
        {
            maychoi2 = collision;
            if (lever > collision.gameObject.GetComponent<SeahorseCPU2>().lever)
            {
                if (CheckVacham)
                {
                    this.ChangeAnim("Attack");
                    collision.gameObject.GetComponent<SeahorseCPU2>().ChangeAnim("Death");
                    collision.gameObject.transform.position = collision.gameObject.GetComponent<SeahorseCPU2>().Myhome;
                }
                else
                {
                    for (int i = 0; i < collision.gameObject.GetComponent<SeahorseCPU2>().moveGreen.Length; i++)
                    {
                        if (collision.gameObject.transform.position == collision.gameObject.GetComponent<SeahorseCPU2>().moveGreen[i])
                        {
                            collision.gameObject.transform.position = collision.gameObject.GetComponent<SeahorseCPU2>().moveGreen[i-1];
                        }
                    }
                }
            }
            else
            {
                if (CheckVacham)
                {
                    for (int i = 0; i < move.Count - 17; i++)
                    {
                        if (this.transform.position == move[i])
                        {
                            this.gameObject.transform.position = move[i - 1];
                        }

                    }

                }
                else
                {
                    collision.gameObject.GetComponent<SeahorseCPU2>().ChangeAnim("Attack");
                    this.ChangeAnim("Death");
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
                    this.ChangeAnim("Attack");
                    collision.gameObject.GetComponent<SeahorseCPU>().ChangeAnim("Death");
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
                    for (int i = 0; i < move.Count - 17; i++)
                    {
                        if (this.transform.position == move[i])
                        {
                            this.gameObject.transform.position = move[i - 1];
                        }
                    }
                }
                else
                {
                    collision.gameObject.GetComponent<SeahouseCPU3>().ChangeAnim("Attack");
                    this.ChangeAnim("Death");
                    this.transform.position = Myhome;
                }
            }
        }
    }
    private void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);

        }
    }
}
