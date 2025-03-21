﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody rb;

    bool hasLanded;
    bool thrown;

    Vector3 initPosition;

    public int diceValue;

    public DiceSide[] diceSides;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        rb.useGravity = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();
        }
        if (rb.IsSleeping() && !hasLanded && thrown)
        {
            hasLanded = true;
            rb.useGravity = false;
            rb.isKinematic = true;
            SideValueCheck();
        }
        else if (!rb.IsSleeping() && hasLanded && diceValue == 0)
        {
            RollAgain();
        }
    }
    void RollDice()
    {
        if (!thrown && !hasLanded)
        {
            thrown = true;
            rb.useGravity = true;
            rb.AddForce(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
            rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        }
        else if (thrown && hasLanded)
        {
            Reset();
        }
    }
    void Reset()
    {
        transform.position = initPosition;
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
        rb.isKinematic = false;
    }
    void RollAgain()
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

    void SideValueCheck()
    {
        diceValue = 0;
        foreach (DiceSide side in diceSides)
        {
            if (side.OnGround())
            {
                diceValue = side.sideValue;
                Debug.Log(diceValue);   
                return;
            }
        }
    }
}