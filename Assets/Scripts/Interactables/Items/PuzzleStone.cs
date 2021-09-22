using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PuzzleStone : Item
{
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    public void Reset()
    {
        gameObject.SetActive(true);
        transform.position = startPosition;
    }
}
