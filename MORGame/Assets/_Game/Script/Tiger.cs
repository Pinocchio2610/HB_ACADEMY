using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Tiger : Animal , Gamemanager
{
    private bool child0 = true;
    private int step = 0;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    private bool isRight = true;
    private Coroutine resetCoroutine;
    private void Update()
    {
        Moving();
      
    }

    public virtual void Moving()
    {
        rb.velocity = transform.right * moveSpeed;
    }

   

    private void OnMouseDown()
    {
        if (resetCoroutine != null)
            StopCoroutine(resetCoroutine);
        resetCoroutine = StartCoroutine(ResetAfterDelay());
        if (step == 0)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            step = 1;
            moveSpeed = 0;
        }
        else if (step == 1)
        {

            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            step = 2;

        }
        else if (step == 2)
        {
           this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
           StartCoroutine(Destroytiger());
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemywall"))
        {
            ChangeDirection(!isRight);

        }

        if (collision.gameObject.CompareTag("Chicken"))
        {
            if (step == 0)
            {
                collision.gameObject.SetActive(false);
            }
        }

        if (collision.gameObject.CompareTag("Pig"))
        {
            if (step == 0)
            {
                collision.gameObject.SetActive(false);
            }
        }
    }
    private void ChangeDirection(bool isRight)
    {
        this.isRight = isRight;
        transform.rotation = isRight ? Quaternion.Euler(Vector3.zero) : Quaternion.Euler(Vector3.up * 180);
    }

    private IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3f); 
        ResetState();
        
    }
    private void ResetState()
    {
        // Tắt toàn bộ con
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        // Reset step & speed
        step = 0;
        moveSpeed = 5;
        resetCoroutine = null;
    }

    private IEnumerator Destroytiger()
    {
        yield return new WaitForSeconds(0.1f);
        this.gameObject.SetActive(false);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
            Player.instance.coin += 2000;
        }
        moveSpeed = 5;
        step = 0;
        resetCoroutine = null;
    }

}
