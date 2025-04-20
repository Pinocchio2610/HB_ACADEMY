using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public static Rigidbody rb;
    [SerializeField] public GameObject Canvas;
    public bool hasLanded;
    public bool thrown;
    public Vector3 initPosition;
    public static int diceValue;
    public static Dice dice;
    public DiceSide[] diceSides;
    public int Tam;
    private Dictionary<int, Vector3> move = Mapmanager.CheckInt();
    public bool CheckMovePlayer = false;
    public bool CheckMoveCPU = false;
    public bool CheckMoveCPU2 = false;
    public bool CheckMoveCPU3 = false;
    public bool Check;
    void Awake()
    {
        dice = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        rb.useGravity = false;
    }
    private void Update()
    {
        if (Player.Instance.CheckDice == true && CheckMovePlayer == false)
        {
            if (this.gameObject.GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0))
            {
                CheckDedichuyen();
                Player.Instance.CheckDice = false;
                CheckMovePlayer = true;
                Player.Instance.CheckDice = false;
            }

        }
        if (GameManager.instance.currentPlayer == 1)
        {
            HasLanded();
        }
    }
    public int CallRoll()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        return SideValueCheck();
    }
    public void RollDice()
    {
        Canvas.SetActive(true);
        if (GameManager.instance.currentPlayer == 0)
        {
            if (!thrown && !hasLanded)
            {
                rb.useGravity = true;
                rb.AddForce(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
                rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
            }
        }
    }
    public void RollDiceCPU()
    {
        Canvas.gameObject.SetActive(true);
        rb.useGravity = true;
        rb.AddForce(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        thrown = true;
        CheckMoveCPU = true;
    }
    public void RollDiceCPU2()
    {
        Canvas.gameObject.SetActive(true);
        rb.useGravity = true;
        rb.AddForce(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        thrown = true;
        CheckMoveCPU2 = true;
    }
    public void RollDiceCPU3()
    {
        Canvas.gameObject.SetActive(true);
        rb.useGravity = true;
        rb.AddForce(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        thrown = true;
        CheckMoveCPU3 = true;
    }


    private void CheckDedichuyen()
    {
        foreach (DiceSide side in diceSides)
        {
            if (side.OnGround() == true)
            {
                {
                    thrown = true;
                    if (thrown && !hasLanded)
                    {
                        Player.Instance.Xucxac = CallRoll();
                        Canvas.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
    public void SetDice()
    {
        CheckMovePlayer = false;
        diceValue = 0;
        Reset();

    }
    public void Reset()
    {
        dice.transform.position = initPosition;
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
        rb.isKinematic = false;
    }
    public void RollAgain()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Reset();
            thrown = true;
            rb.useGravity = true;
            rb.AddForce(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
            rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        }
        Reset();
        thrown = true;
        rb.useGravity = true;
        rb.AddForce(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
    }

    public int SideValueCheck()
    {
        diceValue = 0;
        foreach (DiceSide side in diceSides)
        {
            if (side.OnGround())
            {
                diceValue = side.sideValue;
                return diceValue;
            }
            else
            {
                diceValue = 0;
            }
        }
        return diceValue;
    }
    public bool HasLanded()
    {
        foreach (DiceSide side in diceSides)
        {
            if (side.OnGround())
            {
                return Check = true;
            }
        }
        return Check;
    }
}