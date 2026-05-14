using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
    //private int coin = 10;
    [SerializeField] private Button Shop;
    [SerializeField] private GameObject StoreCanva;
    [SerializeField] private GameObject Sopping;
    [SerializeField] private Button Exit1;
    [SerializeField] private Button Chicken;
    [SerializeField] private Button Pig;
    [SerializeField] private Button PlayGame;
    [SerializeField] private GameObject Game;
    [SerializeField] private GameObject Canvanewgame;
    private GameObject checkChicken;
    private GameObject checkPig;
    private int mana = 0;
    public int coin;
    public Camera mainCamera;
    public static Player instance;
    [SerializeField] private Text scoreText;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        coin = 10000;
        Shop.onClick.AddListener(StoreOnSeting);
        Exit1.onClick.AddListener(OutShtore);
        Chicken.onClick.AddListener(ZenChicken);
        Pig.onClick.AddListener(ZenPig);
        PlayGame.onClick.AddListener(PlayGameMor);
        StartCoroutine(ZenTiger());
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = coin.ToString();
        Debug.Log(coin);
        //if (Input.GetMouseButtonDown(0) && mana > 0)
        //{
        //    Vector3 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //    worldPos.z = 0f;
        //    if (worldPos.x > -26.7f && worldPos.x < 57.35f && worldPos.y > -4.5f && worldPos.y < -2.42f)
        //    {
        //        ZenGlass();
        //        mana--;
        //    }
        //}
        //string a = coin.ToString();
        //coi.text = a;
    }

    private void StoreOnSeting()
    {
        StoreCanva.SetActive(true);
        Sopping.SetActive(false);
    }

    private void OutShtore()
    {
        StoreCanva.SetActive(false);
        Sopping.SetActive(true);
    }

    private void ZenChicken()
    {

        GameObject chicken = ObjectPooling.instance.GetChicken();

        if (chicken != null)
        {
            if (coin >= 10000)
            {
                chicken.transform.position = new Vector2(Random.Range(-20.09f, 53.9f), Random.Range(-2.95f, -4.12f));
                chicken.SetActive(true);
                checkChicken = chicken;
                coin -= 10000;
            }
        }
    }

    private void ZenPig()
    {

        GameObject pig = ObjectPooling.instance.GetPig();

        if (pig != null)
        {
            if (coin >= 20000)
            {
                pig.transform.position = new Vector2(Random.Range(-20.09f, 53.9f), Random.Range(-2.95f, -4.12f));
                pig.SetActive(true);
                checkPig = pig;
                coin -= 20000;
            }
        }

    }
    IEnumerator ZenTiger()
    {
        while (true)
        {


            yield return new WaitForSeconds(40);

            if ((checkChicken != null && checkChicken.activeInHierarchy) ||
                (checkPig != null && checkPig.activeInHierarchy))
            {
                GameObject tiger = ObjectPooling.instance.GetTiger();

                float x = (Random.value < 0.5f) ? -20.09f : 53.9f;
                if (tiger != null)
                {
                    tiger.transform.position = new Vector2(x, Random.Range(-2.95f, -4.12f));
                    tiger.SetActive(true);
                }
            }
        }

    }

    private void PlayGameMor()
    {
        Game.SetActive(true );
        Canvanewgame.SetActive(false);

    }    
    //private void ZenGlass()
    //{
    //    GameObject glass = ObjectPooling.instance.GetGlass();

    //    if (glass != null)
    //    {
    //        Vector3 a = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    //        glass.transform.position = new Vector3(a.x, a.y, 0);
    //        glass.SetActive(true);
    //        checkPig = glass;
    //    }
    //}
    //private void PigEat()
    //{
    //    mana = 5;
    //}

}

