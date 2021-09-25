using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PuzzleArea : Area
{

    [SerializeField] private StonePuzzle stonePuzzle;
    public static event Action<bool> PuzzleEnteredEvent;

    protected void Awake()
    {
        stonePuzzle.enabled = false;
    }

    protected override void EnterRegion(Collider2D other)
    {
        base.EnterRegion(other);
        if (other.CompareTag(References.Instance.player.tag))
        {
            PuzzleEnteredEvent?.Invoke(true);
            StonePuzzle.ActiveStonePuzzle = stonePuzzle;
            stonePuzzle.enabled = true;
        }
    }

    protected override void ExitRegion(Collider2D other)
    {
        base.ExitRegion(other);
        if (other.CompareTag(References.Instance.player.tag))
        {
            PuzzleEnteredEvent?.Invoke(false);
            StonePuzzle.ActiveStonePuzzle = null;
            stonePuzzle.enabled = false;
        }
    }
}
