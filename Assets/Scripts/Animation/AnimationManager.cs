using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    private string currentAnimationState;
    // Animation States
    private const string PLAYER_IDLE = "player_idle";
    private const string PLAYER_WALK_UP = "player_walk_up";
    private const string PLAYER_WALK_DOWN = "player_walk_down";
    private const string PLAYER_WALK_LEFT = "player_walk_left";
    private const string PLAYER_WALK_RIGHT = "player_walk_right";
    
    public void AnimateMovement(Vector2 movement, Animator animator)
    {
        if (movement.x > 0)
        {
            ChangeAnimationState(PLAYER_WALK_RIGHT, movement, animator);
        }

        else if (movement.y > 0)
        {
            ChangeAnimationState(PLAYER_WALK_UP, movement, animator);
        }

        else if (movement.x == 0 && movement.y == 0)
        {
            ChangeAnimationState(PLAYER_IDLE, movement, animator);
        }

        else if (movement.x < 0)
        {
            ChangeAnimationState(PLAYER_WALK_LEFT, movement, animator);
        }

        else if (movement.y < 0)
        {
            ChangeAnimationState(PLAYER_WALK_DOWN, movement, animator);
        }
    }

    public void ChangeAnimationState(string newState, Vector2 movement, Animator animator)
    {
        // stop animation from interrupting itself
        if (currentAnimationState == newState)
        {
            return;
        }
        // Play animation
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.Play(newState);

        currentAnimationState = newState;
    }
}
