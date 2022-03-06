using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller2D;
    private float xMove;
    [SerializeField] protected float moveSpeed = 20f;
    private bool jump = false;
    void Start()
    {

    }

    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate() 
    {
        controller2D.Move(xMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
