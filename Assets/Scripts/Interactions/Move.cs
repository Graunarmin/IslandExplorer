using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Tilemaps;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Move : Interaction
{
    private Tilemap pathTilemap;
    private Tilemap obstacleTilemap;
    [SerializeField] private TileBase bridgeTile;
    [SerializeField] private TileBase bridgeTile2;
    [SerializeField] private Collider2D objectCollider;

    public static event Action<bool> MovedStoneEvent;
    public static event Action<bool> MovedStoneToWaterEvent;
    protected override void Start()
    {
        base.Start();
        pathTilemap = References.Instance.pathTilemap;
        obstacleTilemap = References.Instance.obstacleTilemap;
    }

    public override void Interact()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        Vector3 moveDirection = DetermineMoveDirection();
        
        if (CanMove(moveDirection))
        {
            transform.position += moveDirection;
            MovedStoneEvent?.Invoke(true);
        }
        else
        {
            if (CanMoveIntoWater(moveDirection))
            {
                MoveIntoWater(moveDirection);
                transform.position += moveDirection;
                MovedStoneToWaterEvent?.Invoke(true);
            }
        }
    }
    
    private Vector3 DetermineMoveDirection()
    {
        // https://forum.unity.com/threads/detection-if-player-left-or-right-of-enemy.515074/
        Vector2 relativePoint = transform.InverseTransformPoint(References.Instance.playerFeet.position);
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

    private bool CanMoveIntoWater(Vector2 direction)
    {
        Vector3Int gridPosition = pathTilemap.WorldToCell(transform.position + (Vector3)direction);
        if (obstacleTilemap.HasTile(gridPosition))
        {
            return true;
        }
        return false;
    }
    
    private void MoveIntoWater(Vector2 direction)
    {
        Vector3 stonePosition = transform.position;
        
        //Water is 2 Tiles wide
        Vector3Int gridPosition = pathTilemap.WorldToCell(stonePosition + (Vector3)direction);
        Vector3Int gridPositionNext = pathTilemap.WorldToCell(stonePosition + 2*(Vector3)direction);
        
        SaveMovedTiles(gridPosition, gridPositionNext);
        
        //remove the water tile (has collider)
        obstacleTilemap.SetTile(gridPosition, null);
        obstacleTilemap.SetTile(gridPositionNext, null);
        
        //and set the bridge tile
        pathTilemap.SetTile(gridPosition, bridgeTile);
        pathTilemap.SetTile(gridPositionNext, bridgeTile2);
        
        //deactivate stone
        transform.gameObject.SetActive(false);
    }

    private void SaveMovedTiles(Vector3Int gridPosition, Vector3Int gridPositionNext)
    {
        StonePuzzle activePuzzle = StonePuzzle.ActiveStonePuzzle;
        
        //Save Tiles, their position and rotation so they can be reset later
        activePuzzle.AddMovedTile(obstacleTilemap, obstacleTilemap.GetTile(gridPosition), 
            gridPosition, obstacleTilemap.GetTransformMatrix(gridPosition));
        activePuzzle.AddMovedTile(obstacleTilemap, obstacleTilemap.GetTile(gridPositionNext), 
            gridPositionNext, obstacleTilemap.GetTransformMatrix(gridPositionNext));
        
        activePuzzle.AddMovedTile(pathTilemap, pathTilemap.GetTile(gridPosition), 
            gridPosition, pathTilemap.GetTransformMatrix(gridPosition));
        activePuzzle.AddMovedTile(pathTilemap, pathTilemap.GetTile(gridPositionNext), 
            gridPositionNext, pathTilemap.GetTransformMatrix(gridPositionNext));
    }
}
