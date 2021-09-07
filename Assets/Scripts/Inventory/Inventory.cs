using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Inventory : MonoBehaviour, IItemContainer
{
    [SerializeField] private int space;
    private List<Interactable> items = new List<Interactable>();
    private void Awake()
    {
        Interactable.interactedEvent += AddItem;
    }

    public void AddItem(Interactable item)
    {
        if (!IsFull())
        {
            items.Add(item);
            Debug.Log((item as Item).itemInfo.itemName + " was added to Inventory.");
        }
    }

    public bool RemoveItem(Interactable item)
    {
        items.Remove(item);
        return true;
    }

    public bool ContainsItem(Interactable item)
    {
        if (items.Contains(item))
        {
            return true;
        }

        return false;
    }

    public bool ContainsItem(Tool tool)
    {
        if (items.Contains(tool))
        {
            return true;
        }

        return false;
    }

    public bool IsFull()
    {
        if (items.Count >= space)
        {
            return true;
        }

        return false;
    }

    public int Size()
    {
        return items.Count;
    }

    public List<Interactable> GetContainer()
    {
        return items;
    }
    
}
