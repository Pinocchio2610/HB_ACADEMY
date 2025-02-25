using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        EnemyT();
    }

    private void EnemyT()
    {
        
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {

                pos = new Vector3(i , 2 , j);
                GameObject a = PoolingEnemy.instans.GetEnemy();
                if (a != null)
                {
                    a.transform.position = pos;
                    a.SetActive(true);
                }
            }
        }
    }

}
