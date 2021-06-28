    using System;
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    [SerializeField]
    private bool activeRegion;

    public List<Item> containedItems = new List<Item>();

    [SerializeField]
    private Vector2 bottomLeft;
    
    [SerializeField]
    private Vector2 topRight;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        EnterRegion(other);
    }

    private void EnterRegion(Collider2D other)
    {

        activeRegion = true;
        
        SetContainedItems(true);
        
        //Camera Follow
        CameraController cam = References.instance.mainCamera.GetComponent<CameraController>();
            
        if (other.CompareTag(References.instance.player.tag))
        {
            cam.minPos = bottomLeft;
            cam.maxPos = topRight;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        ExitRegion(other);
    }
    
    //Set colliders of all contained items
    private void ExitRegion(Collider2D other)
    { 
        activeRegion = false;
        SetContainedItems(false);
        
    }
    
    private void SetContainedItems(bool itemStatus)
    {
        if (containedItems.Count > 0)
        {
            foreach (Item item in containedItems)
            {
                //item.SetItemStatus(itemStatus);
            }
        }
    }

    public bool IsCurrentRegion()
    {
        return activeRegion;
    }

    public void RemoveItem(Item item)
    {
        containedItems.Remove(item);
    }
}
