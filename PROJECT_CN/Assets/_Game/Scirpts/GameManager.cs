using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    private Dictionary<int, Vector3> move = Mapmanager.CheckInt();
    private int Xucxac = 6;
    private Vector3[] LocalCanguaDo = new Vector3[4] { new Vector3(11, 1, 2), new Vector3(11, 1, 5), new Vector3(14, 1, 2), new Vector3(14, 1, 5) };
    private Animator anim;
    private string currrenanim;
    private NavMeshAgent agent;
    private Vector3 targetPosition;
    private float speed = 0.2f;
    private float t = 0;
    GameObject a;
    private bool succect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Mana();
        CheckSeahouse();



    }
    void CheckSeahouse()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonUp(0)) // Kiểm tra khi nhấn chuột trái
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f)) // Raycast từ camera xuống
            {
                if (hit.collider.CompareTag("SeahorsePlayer")) // Kiểm tra có phải cá ngựa không
                {
                    for (int i = 0; i < LocalCanguaDo.Length; i++)
                    {

                        if (hit.collider.transform.position == LocalCanguaDo[i])
                        {
                            if (Xucxac == 6)
                            {
                                hit.collider.transform.position = move[1];
                                return;
                            }
                        }
                    }
                    for (int i = 0; i < move.Count; i++)
                    {
                        if (hit.transform.position == move[i])
                        {
                            if (Xucxac == 6)
                            {
                                hit.transform.DOMove(move[i + 1], 1f);
                                Xucxac--;
                                if (Xucxac == 5)
                                {
                                    hit.transform.DOMove(move[i + 2], 1f);
                                    Xucxac--;
                                    if (Xucxac == 4)
                                    {
                                        hit.transform.DOMove(move[i + 3], 1f);
                                        Xucxac--;

                                        if (Xucxac == 3)
                                        {
                                            hit.transform.DOMove(move[i + 4], 1f);
                                            Xucxac--;
                                            if (Xucxac == 2)
                                            {
                                                hit.transform.DOMove(move[i + 5], 1f);
                                                Xucxac--;
                                                if (Xucxac == 1)
                                                {
                                                    hit.transform.DOMove(move[i + 6], 1f);
                                                    Xucxac--;
                                                }
                                            }
                                        }
                                    }

                                }
                               
                            }
                            Xucxac = 6;
                            //if (Xucxac == 5)
                            //{
                            //    hit.transform.DOMove(move[i + 1], 1f);
                            //    hit.transform.DOMove(move[i + 2], 1f);
                            //    hit.transform.DOMove(move[i + 3], 1f);
                            //    hit.transform.DOMove(move[i + 4], 1f);
                            //    hit.transform.DOMove(move[i + 5], 1f);
                            //}
                            //if (Xucxac == 4)
                            //{
                            //    hit.transform.DOMove(move[i + 1], 1f);
                            //    hit.transform.DOMove(move[i + 1], 1f);
                            //    hit.transform.DOMove(move[i + 1], 1f);
                            //    hit.transform.DOMove(move[i + 1], 1f);
                            //}
                            //if (Xucxac == 3)
                            //{
                            //    hit.transform.DOMove(move[i + 1], 1f);
                            //    hit.transform.DOMove(move[i + 1], 1f);
                            //    transform.DOMove(move[i + 1], 1f);
                            //}
                            //if (Xucxac == 2)
                            //{
                            //    transform.DOMove(move[i + 1], 1f);
                            //    transform.DOMove(move[i + 1], 1f);
                            //}
                            //if (Xucxac == 1)
                            //{
                            //    transform.DOMove(move[i + 1], 1f);
                            //}
                        }
                    }
                }

            }

        }

    }
    void Mana()
    {

        GameObject poolingmana = PoolingMana.Instance.SetActivity();

        if (poolingmana != null)
        {
            int A = Random.Range(1, 56);
            poolingmana.transform.position = move[A] - new Vector3(0, 0.5f, 0);
            poolingmana.transform.rotation = Quaternion.identity;
            poolingmana.SetActive(true);
        }
    }

    void ChangeAnim(string currename)
    {
        if (currrenanim != currename)
        {
            currename = currrenanim;
            anim.ResetTrigger(currrenanim);
            anim.SetTrigger(currename);
        }
    }
    float SetTime()
    {
        for (int i = 0; i < 10; i++)
        {
            t += Time.deltaTime * speed;
        }
        return t;
    }


}






