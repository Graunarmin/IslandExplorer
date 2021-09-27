using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStone : Interaction
{
    public override void Interact()
    {
        OnInteract();
        DestroyObstacle();
    }

    private void DestroyObstacle()
    {
        gameObject.SetActive(false);
    }
}
