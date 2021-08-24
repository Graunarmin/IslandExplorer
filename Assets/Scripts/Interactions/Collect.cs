using System.Runtime.CompilerServices;
using UnityEngine;

public class Collect : Inspect
{

    public override void Interact()
    {
        if (!References.instance.infoBoxCanvas.gameObject.activeInHierarchy)
        {
            ShowInfo();
        }
        else
        {
            HideInfo();
            CollectItem();
            interactable.InteractionHappened();
        }
    }

    private void CollectItem()
    {
        if (item is Tool)
        {
            GameManager.gameManager.InteractionEvent -= Interact;
        }
    }

    
}