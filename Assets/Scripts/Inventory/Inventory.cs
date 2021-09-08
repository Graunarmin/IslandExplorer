using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Inventory : MonoBehaviour, IItemContainer
{
    [SerializeField] private int space = 6;
    private List<Interactable> items = new List<Interactable>();

    private static Inventory _instance;

    public static Inventory Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.Log("More than one instance of Inventory!");
        }
    }

    private void OnEnable()
    {
        Interactable.InteractedEvent += AddItem;
    }

    private void OnDisable()
    {
        Interactable.InteractedEvent -= AddItem;
    }

    public void AddItem(Interactable item)
    {
        if (item is Tool && !IsFull())
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
