using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Interaction
{

    public Transform playerFeet;
    public override void Interact()
    {
        Vector3 direction = playerFeet.transform.position - transform.position;
        if (direction.y < 0)
        {
            Debug.Log("Unterhalb");
        }
        else if(direction.y > 0)
        {
            Debug.Log("Oberhalb");
        }
        
        if (direction.x < 0)
        {
            Debug.Log("Links");
        }
        else if(direction.x > 0)
        {
            Debug.Log("Rechts");
        }

        base.Interact();
    }
}
