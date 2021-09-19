using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : Interaction
{

    public override void Interact()
    {
        DestroyObstacle();
    }

    private void DestroyObstacle()
    {
        gameObject.SetActive(false);
    }
}
