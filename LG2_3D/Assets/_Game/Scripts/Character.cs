using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    float horizontal;
    float vertical;
    private float Speed = 5;
    public Joystick joystick;
    private List<GameObject> Addbrick = new List<GameObject>();
    public GameObject AddbrickPrefab;
    private List<GameObject> A = new List<GameObject>();
    public Material mas;
    [SerializeField] LayerMask ground;
    Vector3 cau;
    private Vector3 Player;
    Vector3 luu;
    private float a;
    Vector3 san;
    //public Material mas;

    // Start is called before the first frame update
    private void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    private void Moving()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;
        Vector3 direction = Vector3.forward * (-vertical) + Vector3.right * (-horizontal);
        transform.Translate(direction * Time.deltaTime * Speed);
        Player = transform.position;
        cau = direction;
        
        if (CheckBox())
        {
            return;

        }
        else
        {

            transform.Translate(-direction * Time.deltaTime * Speed);
            return;
        }






    }
    // nen de mot scrip brick

    


    private void Cau()
    {
        if (transform.childCount > 0)
        {

            Vector3 check = new Vector3(Player.x, Player.y - 1, Player.z);
            Debug.DrawRay(check, Vector3.forward, Color.red, 5f);
            RaycastHit hit;
            if (Physics.Raycast(check, Vector3.forward, out hit, 5 ))
            {

                if (cau.z < 0)
                {
                    string tag = hit.collider.tag;
                    if (tag.Contains("MyBrick"))
                    {
                        if (hit.collider.gameObject.GetComponent<MeshRenderer>().sharedMaterial !=mas)
                        {
                            Transform D = transform.GetChild(transform.childCount - 1);
                            D.transform.SetParent(transform, false);
                            Destroy(D.gameObject);
                            hit.collider.GetComponent<MeshRenderer>().material = mas;
                            //hit.collider.gameObject.tag = "MyBrickGreen";
                            luu = Player;
                        }
                        else
                        {
                            Debug.Log("a");
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
            if (cau.z < 0)
            {
                transform.position = luu;
            }
            if (cau.z > 0)
            {
                return;
            }


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Green")
        {

            other.gameObject.SetActive(false); // Ẩn viên gạch
            GameObject newBrick = Instantiate(AddbrickPrefab, other.transform.position, Quaternion.identity);
            newBrick.transform.SetParent(transform);
            float vitri = transform.childCount * 0.1f;
            newBrick.transform.localPosition = new Vector3(0, vitri, 1);
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
    private bool CheckBox()
    {
        RaycastHit hit;
        Vector3 check = new Vector3(Player.x, Player.y, Player.z + 1);
        //Debug.DrawLine(check, Vector3.down, Color.red, 5f);
        if (Physics.Raycast(check, Vector3.down, out hit, 5f, ground))
        {
            san = hit.point;
            return true;
        }
        return false;
    }


}
