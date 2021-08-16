using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [HideInInspector] public Collider col;

    [HideInInspector] public Interactable interactable;

    public ItemAsset itemInfo;

    public Area location;

    void Awake()
    {
        //as long as an item has a collider, it is going to put it in here, otherwise = null
        if (GetComponent<Collider>() != null)
        {
            col = GetComponent<Collider>();
            Debug.Log("Item has collider");
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactable.enabled = true;
            References.instance.activeItem = this;
            Debug.Log("activated item.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactable.enabled = false;
            References.instance.activeItem = null;
            Debug.Log("deactivated Item.");
        }
    }
    
    //Is called by Collectable
    public virtual void CollectItem()
    {
        References.instance.activeItem = null;
    }
}
