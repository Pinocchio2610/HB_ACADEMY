using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingEnemy : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    private List<GameObject> enemyList = new List<GameObject>();
    private float maxEnemy = 10f;
    public static PoolingEnemy instans;

    private void Awake()
    {
        if (instans == null)
        {
            instans = this;
        }
        
    }

    void Start()
    {
        SinhEnemy();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SinhEnemy()
    {
        for (int i = 0; i < maxEnemy; i++)
        {
            GameObject a = Instantiate(Enemy);
            a.SetActive(false);
            enemyList.Add(a);
        }

    }  
    public GameObject GetEnemy()
    {
        for(int i = 0;i < enemyList.Count;i++)
        {
            if(!enemyList[i].activeInHierarchy)
            {
                return enemyList[i];
            }
        }    
        return null;
    }    
}
