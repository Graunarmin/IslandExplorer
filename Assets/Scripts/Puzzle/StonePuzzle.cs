using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StonePuzzle : MonoBehaviour
{
    [SerializeField] private List<PuzzleStone> stones = new List<PuzzleStone>();
    [SerializeField] private Transform playerStart;
    public static StonePuzzle ActiveStonePuzzle { get; set; }

    private Dictionary<Tilemap, Dictionary<Vector3Int, TileBase>> movedTiles =
        new Dictionary<Tilemap, Dictionary<Vector3Int, TileBase>>();
    
    private Dictionary<Tilemap, Dictionary<Vector3Int, Matrix4x4>> tileMatrices =
        new Dictionary<Tilemap, Dictionary<Vector3Int, Matrix4x4>>();

    private void OnEnable()
    {
        GameManager.ResetEvent += ResetPuzzle;
    }

    private void ResetPuzzle()
    {
        ResetStones();
        ResetPlayer();
        ResetTiles();
    }

    private void ResetStones()
    {
        if (ActiveStonePuzzle == this)
        {
            foreach (PuzzleStone stone in stones)
            {
                stone.Reset();
            }
        }
    }

    private void ResetPlayer()
    {
        References.Instance.player.transform.position = playerStart.position;
    }

    private void ResetTiles()
    {
        foreach (KeyValuePair<Tilemap, Dictionary<Vector3Int, TileBase>> info in movedTiles)
        {
            Tilemap tilemap = info.Key;
            foreach (KeyValuePair<Vector3Int, TileBase> tile in info.Value)
            {
                tilemap.SetTile(tile.Key, tile.Value);
                tilemap.SetTransformMatrix(tile.Key, tileMatrices[tilemap][tile.Key]);
            }
        }
        movedTiles.Clear();
        tileMatrices.Clear();
    }

    public void AddMovedTile(Tilemap tilemap, TileBase tile, Vector3Int position, Matrix4x4 rotation)
    {
        if (!movedTiles.ContainsKey(tilemap))
        {
            // save the moved tile under it's position
            Dictionary<Vector3Int, TileBase> tilePositions = new Dictionary<Vector3Int, TileBase>();
            tilePositions.Add(position, tile);
            movedTiles.Add(tilemap, tilePositions);
            
            // save the matrix of the moved tile under it's position (to get the rotation of the tile)
            Dictionary<Vector3Int, Matrix4x4> tileRotations = new Dictionary<Vector3Int, Matrix4x4>();
            tileRotations.Add(position, rotation);
            tileMatrices.Add(tilemap, tileRotations);
        }
        else
        {
            movedTiles[tilemap].Add(position, tile);
            tileMatrices[tilemap].Add(position, rotation);
        }
    }
}
