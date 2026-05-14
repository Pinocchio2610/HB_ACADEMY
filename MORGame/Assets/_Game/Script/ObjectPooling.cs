using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private GameObject Chicken;
    private List<GameObject> chickenllist = new List<GameObject>();
    private List<GameObject> pigllist = new List<GameObject>();
    private List<GameObject> tigerllist = new List<GameObject>();
    private List<GameObject> glassllist = new List<GameObject>();
    private List<GameObject> milkllist = new List<GameObject>();
    private List<GameObject> eggllist = new List<GameObject>();
    private float maxAnimal = 10f;
    public static ObjectPooling instance;
    [SerializeField] private GameObject Pig;
    [SerializeField] private GameObject Tiger;
    [SerializeField] private GameObject Glass;
    [SerializeField] private GameObject Milk;
    [SerializeField] private GameObject Egg;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        GenChicken();
        GenPig();
        GenTiger();
        GenGlass(); 
        GenMilk();
        GenEgg();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void GenChicken()
    {
        for(int i = 0; i < maxAnimal; i++)
        {
            GameObject save = Instantiate(Chicken);
            save.SetActive(false);
            chickenllist.Add(save);   
        }    
    }
    public GameObject GetChicken()
    {
        for(int i = 0;i < chickenllist.Count;i++)
        {
            if(!chickenllist[i].activeInHierarchy)
            {
                return chickenllist[i];   
            }    
        }    
        return null;
    }

    private void GenPig()
    {
        for (int i = 0; i < maxAnimal; i++)
        {
            GameObject save = Instantiate(Pig);
            save.SetActive(false);
            pigllist.Add(save);
        }
    }
    public GameObject GetPig()
    {
        for (int i = 0; i < chickenllist.Count; i++)
        {
            if (!pigllist[i].activeInHierarchy)
            {
                return pigllist[i];
            }
        }
        return null;
    }

    private void GenTiger()
    {
        for (int i = 0; i < maxAnimal; i++)
        {
            GameObject save = Instantiate(Tiger);
            save.SetActive(false);
            tigerllist.Add(save);
        }
    }
    public GameObject GetTiger()
    {
        for (int i = 0; i < tigerllist.Count; i++)
        {
            if (!tigerllist[i].activeInHierarchy)
            {
                return tigerllist[i];
            }
        }
        return null;
    }

    private void GenGlass()
    {
        for (int i = 0; i < maxAnimal; i++)
        {
            GameObject save = Instantiate(Glass);
            save.SetActive(false);
            glassllist.Add(save);
        }
    }
    public GameObject GetGlass()
    {
        for (int i = 0; i < glassllist.Count; i++)
        {
            if (!glassllist[i].activeInHierarchy)
            {
                return glassllist[i];
            }
        }
        return null;
    }

    private void GenMilk()
    {
        for (int i = 0; i < maxAnimal; i++)
        {
            GameObject save = Instantiate(Milk);
            save.SetActive(false);
            milkllist.Add(save);
        }
    }
    public GameObject GetMilk()
    {
        for (int i = 0; i < milkllist.Count; i++)
        {
            if (!milkllist[i].activeInHierarchy)
            {
                return milkllist[i];
            }
        }
        return null;
    }

    private void GenEgg()
    {
        for (int i = 0; i < maxAnimal; i++)
        {
            GameObject save = Instantiate(Egg);
            save.SetActive(false);
            eggllist.Add(save);
        }
    }
    public GameObject GetEgg()
    {
        for (int i = 0; i < eggllist.Count; i++)
        {
            if (!eggllist[i].activeInHierarchy)
            {
                return eggllist[i];
            }
        }
        return null;
    }
}
