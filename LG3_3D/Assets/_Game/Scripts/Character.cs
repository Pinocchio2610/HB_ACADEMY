using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    private float hori;
    private float veti;
    [SerializeField] private float speed = 5;
    public Transform Snopoit;
    [SerializeField] Joystick Joystick;
    Vector3 direction;
    float secondtime;
    
    public static Character character { get; private set; }

    private void Start()
    {       
    }
    void Update()
    {
        Moving();
        CheckEnemy();

    }

    private void Moving()
    {
        hori = Input.GetAxis("Horizontal");
        veti = Input.GetAxis("Vertical");
        hori = Joystick.Horizontal;
        veti = Joystick.Vertical;
        direction = Vector3.forward * veti + Vector3.right * hori;
        transform.Translate(direction * Time.deltaTime * speed, Space.World);
        if (direction != Vector3.zero)
        {

            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green; // Màu hình cầu
        Gizmos.DrawWireSphere(transform.position, 10 ); // Vẽ hình cầu
    }


    private void CheckEnemy()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 10, Vector3.forward, out hit, 5f))
        {

            if (hit.collider.tag == "Enemy")
            {
                if (veti == 0 && hori == 0)
                {
                    Attack();
                    
                }
            }
        }



    }
    private void Attack()
    {

        if (secondtime <= 0f)
        {
            secondtime = 1f;
            GameObject gun = PollingWeapon.instans.GetPoolObject();
            if (gun != null)
            {
                gun.transform.position = Snopoit.transform.position; 
                gun.SetActive(true);
                gun.GetComponent<Rigidbody>().AddForce(Snopoit.forward * 600, ForceMode.Force);
            }
            

        }
        else
        {
            secondtime -= Time.deltaTime;
        }

    }
    
    




}
