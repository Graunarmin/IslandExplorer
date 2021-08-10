using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactable
{
    private void Awake()
    {
        item = GetComponent<Item>();
    }
    public override void Interact()
    {
        PickUpItem();
    }

    private void PickUpItem()
    {
        item.CollectItem();
        item.location.RemoveItem(item);
        gameObject.SetActive(false);
    }
    
}
