using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IItemContainer
{

    [SerializeField] private int space;

    private List<Item> items = new List<Item>();

    public bool AddItem(Item item, int index = 0)
    {
        //Fall 1: Inventar ist voll, nichts passt mehr rein
        if (IsFull())
        {
            Debug.Log("Not enough room!");
            return false;
        }

        //Fall 2: Item ist bereits im Inventar
        if (ContainsItem(item.itemInfo))
        {
            //Wenn es stapelbar ist: aufnehemen
            if (item.itemInfo.isStackable)
            {
                IncreaseItemCount(item);
                return true;
            }
            //Wenn es nicht stapelbar ist: Nicht aufnehemen
            Debug.Log("Item already in Inventory");
            return false;
        }
        //Fall 3: Platz im Inventar und Item noch nicht drin
        items.Add(item);
        return true;
    }

    public bool RemoveItem(Item item)
    {
        return items.Remove(item);
    }

    public bool RemoveItem(ItemAsset item)
    {
        foreach (Item containedItem in items)
        {
            if (containedItem.itemInfo == item)
            {
                return RemoveItem(containedItem);
            }
        }
        return false;
    }

    public Item GetItemAtIndex(int index)
    {
        return items[index];
    }

    public bool ContainsItem(Item item)
    {
        if (items.Contains(item))
        {
            Debug.Log("Inventory contains " + item.name);
        }
        else
        {
            Debug.Log("Inventory does not contain " + item.name);
            
        }
        return items.Contains(item);
    }

    public bool ContainsItem(ItemAsset item)
    {
        foreach (Item containedItem in items)
        {
            if (containedItem.itemInfo == item)
            {
                Debug.Log("Inventory contains " + item.name);
                return true;
            }
        }
        Debug.Log("Inventory does not contain " + item.name);
        return false;
    }

    public void IncreaseItemCount(Item item)
    {
        throw new System.NotImplementedException();
    }

    public void IncreaseItemCount(ItemAsset item)
    {
        throw new System.NotImplementedException();
    }

    public bool IsFull()
    {
        throw new System.NotImplementedException();
    }

    public int Size()
    {
        throw new System.NotImplementedException();
    }

    public void SetSpace(int newSpace)
    {
        space = newSpace;
    }

    public List<Item> GetContainer()
    {
        return items;
    }
}
