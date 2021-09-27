using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PuzzleArea : Area
{

    [SerializeField] private StonePuzzle stonePuzzle;
    public static event Action<bool> PuzzleEnteredEvent;
    public GameObject tutorialCanvas;

    protected void Awake()
    {
        stonePuzzle.enabled = false;
        tutorialCanvas.gameObject.SetActive(false);
    }

    protected override void EnterRegion(Collider2D other)
    {
        base.EnterRegion(other);
        if (other.CompareTag(References.Instance.player.tag))
        {
            StartCoroutine(ShowHints(2f));
            PuzzleEnteredEvent?.Invoke(true);
            StonePuzzle.ActiveStonePuzzle = stonePuzzle;
            stonePuzzle.enabled = true;
        }
    }

    IEnumerator ShowHints(float showtime)
    {
        tutorialCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(showtime);
        tutorialCanvas.gameObject.SetActive(false);
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
