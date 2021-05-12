using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemebt : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    private Vector2 movement;

    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame (Handle Input Here)
    void Update()
    {   
        // right = 1, left = -1, not pressed = 0
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    
    // Handle Movement
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement);
    }
}
