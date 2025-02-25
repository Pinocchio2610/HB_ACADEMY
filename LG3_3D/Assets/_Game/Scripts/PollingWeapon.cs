using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.Rendering;

public class PollingWeapon : MonoBehaviour
{
    public static PollingWeapon instans;
    [SerializeField] public GameObject bullet;
    private float gunmax = 10f;
    private List<GameObject> list = new List<GameObject>();
    private List<Weapon> weapons = new List<Weapon>();

    private void Awake()
    {
        if (instans == null)
        {
            instans = this;
        }
        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            

        }


    }
    private void Start()
    {
        RenDan();
        GetPoolObject();
       

    }
    private void RenDan()
    {

        for (int i = 0; i < gunmax; i++)
        {
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            list.Add(obj);
        }

    }
    public GameObject GetPoolObject()
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].gameObject.activeInHierarchy)
            {
                return list[i];
            }
        }
        return null;


    }
}


