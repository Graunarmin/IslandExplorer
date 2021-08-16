using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Collectable))]
public class StickerItem : Item
{

    public Image sticker;
    public TextMeshProUGUI infoText;
    
    public delegate void ItemCollectedDelegate();
    public event ItemCollectedDelegate collectedEvent;
    
    public override void CollectItem()
    {
        base.CollectItem();
        location.RemoveItem(this);
        
        //Broadcast that this item was collected
        if (collectedEvent != null)
        {
            collectedEvent();
        }

        Debug.Log("Item " + itemInfo.itemName + " was collected");
    }
}
