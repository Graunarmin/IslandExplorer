using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [HideInInspector] public Collider col;

    [HideInInspector] public Interactable interactable;

    public Area location;
    
    void Awake()
    {
        //as long as an item has a collider, it is going to put it in here, otherwise = null
        if (GetComponent<Collider>() != null)
        {
            col = GetComponent<Collider>();
            Debug.Log("Item has collider");
            //all colliders are disabled in the beginning
            //SetItemStatus(false);
        }
        else
        {
            col = null;
        }
    }
        
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    public void SetItemStatus(bool status)
    {
        col.enabled = status;
    }

    private void OnMouseDown()
    {
        interactable.enabled = true;
        interactable.Interact();
    }
}
