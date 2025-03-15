using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingMana : MonoBehaviour
{
    public static PoolingMana Instance;
    [SerializeField] private GameObject mana;
    List<GameObject> pool = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }
    void Start()
    {
        Genmana();
    }

    void Genmana()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject a = Instantiate(mana);
            a.SetActive(false);
            pool.Add(a);
        }
    }
    public GameObject SetActivity()
    {
        for (int i = 0; i < pool.Count; i++)
        {

            if (!pool[i].gameObject.activeInHierarchy)
            {
                return pool[i].gameObject;
            }

        }
        return null ;
    }
}
