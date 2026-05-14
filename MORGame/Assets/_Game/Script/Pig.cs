using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : Animal
{
    private bool isRight = true;
    [SerializeField] private GameObject eatPig;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Hungry());
        StartCoroutine(ZenMilk());
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

    IEnumerator Hungry()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);

            if (this.gameObject.activeInHierarchy)
            {

            }
        }
    }

    IEnumerator ZenMilk()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            {
                GameObject milk = ObjectPooling.instance.GetMilk();

                if (milk != null)
                {
                    milk.transform.position = this.transform.position;
                    milk.SetActive(true);
                }
            }
        }

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



}
