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
        foreach (PuzzleStone stone in stones)
        {
            stone.Reset();
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
            }
        }
        movedTiles.Clear();
    }

    public void AddMovedTile(Tilemap tilemap, TileBase tile, Vector3Int position)
    {
        if (!movedTiles.ContainsKey(tilemap))
        {
            Dictionary<Vector3Int, TileBase> tilePositions = new Dictionary<Vector3Int, TileBase>();
            tilePositions.Add(position, tile);
            movedTiles.Add(tilemap, tilePositions);
        }
        else
        {
            movedTiles[tilemap].Add(position, tile);
        }
    }
}
