using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 2f, -8f);
    
    // Update is called once per frame
    void LateUpdate()
    {
    
        transform.position = Character.character.transform.position + offset;
    }
}
