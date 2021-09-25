    using System;
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Area : MonoBehaviour
{
    [SerializeField]
    private bool activeRegion;

    public List<Item> containedItems = new List<Item>();

    public Sound areaSound;

    public static event Action<Sound, bool> EnteredAreaEvent;

    [SerializeField]
    private Vector2 bottomLeft;
    
    [SerializeField]
    private Vector2 topRight;
    
    protected void OnTriggerEnter2D(Collider2D other)
    {
        EnterRegion(other);
    }

    protected virtual void EnterRegion(Collider2D other)
    {

        activeRegion = true;
        
        SetContainedItems(true);
        
        //Camera Follow
        CameraController cam = Camera.main.gameObject.GetComponent<CameraController>();
            
        if (other.CompareTag(References.Instance.player.tag))
        {
            cam.minPos = bottomLeft;
            cam.maxPos = topRight;
            EnteredAreaEvent?.Invoke(areaSound, true);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        ExitRegion(other);
    }
    
    //Set colliders of all contained items
    protected virtual void ExitRegion(Collider2D other)
    { 
        activeRegion = false;
        SetContainedItems(false);
        EnteredAreaEvent?.Invoke(areaSound, false);
        
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
