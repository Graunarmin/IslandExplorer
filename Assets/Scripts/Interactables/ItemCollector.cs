using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : Interactable
{
    [HideInInspector] public Collectable collectableItem;
    [SerializeField] private bool inspectItem;

    private void Awake()
    {
        collectableItem = GetComponent<Collectable>();
    }
    
    public override void Interact()
    {
        PickUpItem();
    }

    public virtual void PickUpItem()
    {
        if (inspectItem)
        {
            InspectItem();
        }

        //bool wasPickedUp = InventoryManager.invManager.AddItem(gameObject.GetComponent<Collectable>());

        //if (wasPickedUp)
        //{
            collectableItem.location.RemoveItem(collectableItem);
            gameObject.SetActive(false);
        //}
    }

    public void InspectItem()
    {
        Debug.Log("Do we need object inspection?");
    }
}
