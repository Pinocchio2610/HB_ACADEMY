using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Chicken : Animal
{
    private bool isRight = true;
    void Start()
    {
        StartCoroutine(ZenEgg());
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }
    public override void Moving()
    {
        base.Moving();
    }

    private void ChangeDirection(bool isRight)
    {
        this.isRight = isRight;
        transform.rotation = isRight ? Quaternion.Euler(Vector3.zero) : Quaternion.Euler(Vector3.up * 180);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemywall"))
        {
            ChangeDirection(!isRight);
          
        }
    }

    IEnumerator ZenEgg()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            {
                GameObject egg = ObjectPooling.instance.GetEgg();

                if (egg != null)
                {
                    egg.transform.position = this.transform.position;
                    egg.SetActive(true);
                }
            }
        }

    }
}
