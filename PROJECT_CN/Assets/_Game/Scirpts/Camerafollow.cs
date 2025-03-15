using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Camerafollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 offset;
    public Transform TF;
    //public Transform TFmapmanager;

    // Update is called once per frame
    void LateUpdate()
    {
        TF.position = new Vector3(8, 50, 8);
        TF.rotation = Quaternion.Euler(90 , 0  , 0);   
       
    }
   
}
