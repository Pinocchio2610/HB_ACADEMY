using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : Character
{
    [SerializeField] private float attackRange;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    private IState currentState;
    private bool isRight = true;

    private Character target;
    public Character Taget => target;

    void Update()
    {

        if (currentState != null)
        {
            currentState.OnExecute(this);

        }
    }
    public override void OnInit()
    {
        base.OnInit();
        ChangeState(new IdleState());
    }
    public override void OnDespam()
    {
        base.OnDespam();
    }
    protected override void OnDeath()
    {
        base.OnDeath();
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    public void Moving()
    {
        ChangeAnim("run");
        rb.velocity = transform.right * moveSpeed;
    }
    public void StopMoving()
    {
        ChangeAnim("idle");
        rb.velocity = Vector2.zero;
    }
    public void Attack()
    {
        ChangeAnim("attack");
    }
    public bool IsTargetInRange()
    {
        if (target != null && Vector2.Distance(target.transform.position, this.transform.position) <= attackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SetTaget(Character character)
    {
        this.target = character;
        if (IsTargetInRange())
        {
            ChangeState(new AttackState());
        }
        else if (target != null)
        {
            ChangeState(new PatrolState());
        }
        else
        {
            ChangeState(new IdleState());
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyWall"))
        {
            ChangeDirection(!isRight);
        }
    }
    public void ChangeDirection(bool isRight)
    {
        this.isRight = isRight;
        transform.rotation = isRight ? Quaternion.Euler(Vector3.zero) : Quaternion.Euler(Vector3.up * 180);
    }
}
