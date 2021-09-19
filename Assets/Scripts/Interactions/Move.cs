using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Move : Interaction
{
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap collisionTilemap;
    [SerializeField] private Collider2D objectCollider;

    public override void Interact()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        Vector3 movePosition = DetermineMoveDirection();
        
        if (CanMove(movePosition))
        {
            transform.position += movePosition;
        }
    }

    private Vector3 DetermineMoveDirection()
    {
        // https://forum.unity.com/threads/detection-if-player-left-or-right-of-enemy.515074/
        Vector2 relativePoint = transform.InverseTransformPoint(References.instance.playerFeet.position);
        if (relativePoint.x < 0f && Mathf.Abs(relativePoint.x) > Mathf.Abs(relativePoint.y))
        {
            return new Vector3(1f, 0f, 0f);
        }
        if(relativePoint.x > 0f && Mathf.Abs(relativePoint.x) > Mathf.Abs(relativePoint.y))
        {
            return new Vector3(-1f, 0f, 0f);
        }
        
        if (relativePoint.y < 0f && Mathf.Abs(relativePoint.x) < Mathf.Abs(relativePoint.y))
        {
            return new Vector3(0f, 1f, 0f);
        }
        if(relativePoint.y > 0f && Mathf.Abs(relativePoint.x) < Mathf.Abs(relativePoint.y))
        {
            return new Vector3(0f, -1f, 0f);
        }

        return new Vector3(0f, 0f, 0f);
    }

    private bool CanMove(Vector2 direction)
    {
        RaycastHit2D[] hits = new RaycastHit2D[10];
        ContactFilter2D filter = new ContactFilter2D() { };
        int numHits = objectCollider.Cast(direction, filter, hits, 1f);
        for (int i = 0; i < numHits; i++)
        {
            if (!hits[i].collider.isTrigger)
            {
                Debug.Log("I can't move there because of " + hits[i].collider.gameObject.name);
                return false;
                
            }
        }
        return true;
    }
}
