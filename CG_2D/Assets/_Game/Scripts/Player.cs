using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Rigidbody2D rb;
    // animator la thang dieu khien anim con animation la clip
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 350;

    private bool isGrounded = true;// check xem nhân vật có trên mặt đất không
    private bool isJumping = false;
    private bool isAttack = false;
    private bool isDead = false;

    private float horizontal;

    
    private int coin = 0;
    private Vector3 savePoint;

    // Start is called before the first frame update
    void Start()
    {
        SavePoint();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }
        //Debug.Log(CheckGrounded());
        isGrounded = CheckGrounded();

        // -1 -> 0 -> 1
        horizontal = Input.GetAxisRaw("Horizontal");
        //verticle = Input.GetAxisRaw("Vetical");

        if (isAttack)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        if (isGrounded)
        {
            if (isJumping)
            {
                return;
            }
            //jump
            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            //change anim run
            if (Mathf.Abs(horizontal) > 0.1f)
            {
                ChangeAnim("run");
            }
            // attack
            if (Input.GetKeyDown(KeyCode.J) && isGrounded)
            {
                Attack();
            }


            // throw
            if (Input.GetKeyDown(KeyCode.K) && isGrounded)
            {
                Throw();
            }

        }
        //check falling
        if (!isGrounded && rb.velocity.y < 0)
        {
            ChangeAnim("fall");
            isJumping = false;
        }

        //Moving
        if (Mathf.Abs(horizontal) > 0.1f)
        {
            // ChangeAnim("run");
            rb.velocity = new Vector2(horizontal * Time.fixedDeltaTime * speed, rb.velocity.y);
            transform.rotation = Quaternion.Euler(new Vector3(0, horizontal > 0 ? 0 : 180, 0));
            //khong toi uu dc game//
            //transform.localScale = new Vector3(horizontal, 1, 1);
        }
        //idle
        else if (isGrounded)
        {
            ChangeAnim("idle");
            rb.velocity = Vector2.zero;
        }
    }

    public override void OnInit()
    {
        base.OnInit();
        isDead = false;
        isAttack = false;
        transform.position = savePoint;
        ChangeAnim("idle");
    }
    public override void OnDespam()
    {
        base.OnDespam();
    }
    protected override void OnDeath()
    {
        base.OnDeath();
    }
    // ban 1 tia nhan vat va check xem recat do co cham vao ground ko
    private bool CheckGrounded()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.1f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);

        //if(hit.collider != null)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}

        return hit.collider != null;
    }

    private void Attack()
    {
        rb.velocity = Vector2.zero;
        ChangeAnim("attack");
        isAttack = true;
        Invoke(nameof(ResetAttack), 0.5f);
    }

    private void Throw()
    {
        rb.velocity = Vector2.zero;
        ChangeAnim("throw");
        isAttack = true;
        Invoke(nameof(ResetAttack), 0.5f);
    }
    public void ResetAttack()
    {
        isAttack = false;
        ChangeAnim("idle");
    }

    private void Jump()
    {
        isJumping = true;
        ChangeAnim("jump");
        rb.AddForce(jumpForce * Vector2.up);
    }

   
    internal void SavePoint()
    {
        savePoint = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            coin++;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "DeathZone")
        {
            isDead = true;
            ChangeAnim("die");
            Invoke(nameof(OnInit), 1f);
        }
    }
}

    