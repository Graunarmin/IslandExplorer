using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : Interaction
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
