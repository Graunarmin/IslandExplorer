using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : Item
{

    [SerializeField] bool isInInventory = false;


    public override void WasInteractedWith()
    {
        AddToInventory();
        
        base.WasInteractedWith();
        
        location.RemoveItem(this);
        gameObject.SetActive(false);
    }

    private void AddToInventory()
    {
        isInInventory = true;
    }
    
    public void RemoveFromInventory()
    {
        isInInventory = false;
    }

    public bool IsInInventory()
    {
        return isInInventory;
    }
}
