using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    public ItemAsset itemInfo;
    public Area location;
    
    public override void WasInteractedWith()
    {
        Debug.Log(itemInfo.itemName + " has been interacted with.");
    }
    
}
