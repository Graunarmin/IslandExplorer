using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Movement & Animation: https://www.youtube.com/watch?v=whzomFgjT50&list=PL1EolBJZ74i2Y_Nhuk_fkNt4Urte5mepC&index=46&t=635s
public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    private Vector2 movement;

    public AnimationManager animationManager;
    public Animator animator;
    private string currentAnimationState;
    

    public static bool IsWalking { get; private set; }

    public static event Action<bool> IsWalkingEvent;

    private void OnDisable()
    {
        animationManager.ChangeAnimationState("player_idle", movement, animator);
        IsWalkingEvent?.Invoke(false);
    }

    private void SetIsWalking(bool status)
    {
        IsWalking = status;
        IsWalkingEvent?.Invoke(status);
    }

    // Update is called once per frame (Handle Input Here)
    void Update()
    {
        GetMovement();
    }

    private void GetMovement()
    {
        // right = 1, left = -1, not pressed = 0
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x == 0 && movement.y == 0 && IsWalking)
        {
            SetIsWalking(false);
        }
        else if((movement.x != 0 || movement.y != 0) && !IsWalking)
        {
            SetIsWalking(true);
        }
        animationManager.AnimateMovement(movement, animator);
        
        /*animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);*/
    }
    
    // Handle Movement
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement);
    }
}
