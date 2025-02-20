using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NavmesAgen : MonoBehaviour
{
    [SerializeField] private Transform projects;
    private Vector3 Player;
    private Vector3 cau;
    [SerializeField] private Material mas;
    private Vector3 luu;
    [SerializeField] GameObject AddbrickPrefab;
    private LayerMask ground;
    List<GameObject> A = new List<GameObject>();
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        agent = GetComponent<NavMeshAgent>();
        transform.rotation = Quaternion.identity;
        GameObject[] B = GameObject.FindGameObjectsWithTag("Blue");

        for (int i = 0; i < 6; i++)
        {
            if (transform.childCount < 7)
            {
                agent.SetDestination(B[i].transform.position);
            }
            
        }
        if (transform.childCount == 6)
        {
            agent.SetDestination(projects.transform.position);
        }
        if(transform.position == projects.transform.position)
        {
            return;
        }    

    }

    private void Cau()
    {
        if (transform.childCount > 0)
        {

            Vector3 check = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            Debug.DrawRay(check, Vector3.forward, Color.red, 5f);
            RaycastHit hit;
            if (Physics.Raycast(check, Vector3.forward, out hit, 5))
            {

                if (transform.position.z > 0)
                {
                    string tag = hit.collider.tag;
                    if (tag.Contains("MyBrick"))
                    {
                        if (hit.collider.gameObject.GetComponent<MeshRenderer>().sharedMaterial != mas)
                        {
                            Transform D = transform.GetChild(transform.childCount - 1);
                            D.transform.SetParent(transform, false);
                            Destroy(D.gameObject);
                            hit.collider.GetComponent<MeshRenderer>().material = mas;
                            //hit.collider.gameObject.tag = "MyBrickGreen";
                            luu = hit.point;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
            }


        }
        else
        {
            if (transform.position.z > 0)
            {
                transform.position = luu;
            }
            if (transform.position.z < 0)
            {
                return;
            }


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Blue")
        {

            other.gameObject.SetActive(false); // Ẩn viên gạch
            GameObject newBrick = Instantiate(AddbrickPrefab, other.transform.position, Quaternion.identity);
            newBrick.transform.SetParent(transform);
            float vitri = transform.childCount * 0.1f;
            newBrick.transform.localPosition = new Vector3(0, vitri, -1);
            newBrick.transform.localRotation = Quaternion.identity;
            A.Add(other.gameObject);


        }
        if (other.gameObject.tag == "MyBrick")
        {
            SetBrick(other.gameObject);
            Cau();
        }


    }
    private void SetBrick(GameObject a)
    {

        if (a.gameObject.tag == "MyBrick")
        {
            for (int i = 0; A.Count > i; i++)
                A[i].SetActive(true);
        }

    }

}
