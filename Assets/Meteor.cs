using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float moveSpeed = 1f;    
    private Rigidbody2D rigid2d;
    void Start()
    {
        rigid2d = this.GetComponent<Rigidbody2D>();
        rigid2d.velocity = new Vector2(0, -moveSpeed);
    }

    void Update()
    {
        
    }
}
