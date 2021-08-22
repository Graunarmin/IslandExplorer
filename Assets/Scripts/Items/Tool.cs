using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : Item
{

    public bool isInInventory = false;


    public override void CollectItem()
    {
        base.CollectItem();
        location.RemoveItem(this);
        AddToInventory();
    }

    private void AddToInventory()
    {
        isInInventory = true;
    }
    
    public void RemoveFromInventory()
    {
        isInInventory = false;
    }
}
