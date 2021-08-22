using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{   
    [HideInInspector] public Item item;
    public string displayText;
    
    private Sprite icon;
    
    
    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
        item = GetComponent<Item>();
        icon = item.itemInfo.icon;
    }

    public virtual void Interact()
    {
        if (!References.instance.infoBoxCanvas.gameObject.activeInHierarchy)
        {
            ShowInfo();
        }
        else
        {
            HideInfo();
            Collect();
        }
    }

    protected virtual void Collect()
    {
        item.CollectItem();
    }

    public void ShowInfo()
    {
        References.instance.infoBoxCanvas.Activate(icon, displayText);
    }

    public void HideInfo()
    {
        References.instance.infoBoxCanvas.Close();
    }
}
