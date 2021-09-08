using System.Runtime.CompilerServices;
using UnityEngine;

public class Collect : Inspect
{
    protected override void ReactToInteraction()
    {
        if (item is Tool)
        {
            GameManager.InteractionEvent -= Interact;
        }
    }
}