using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour , Gamemanager
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    
    public virtual void Moving()
    {
        rb.velocity = transform.right * moveSpeed;
    }
        
}
