using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{   
    [HideInInspector] public Item item;
    public Image icon;
    public TextMeshProUGUI displayText;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
    }

    public virtual void Interact()
    {
        //wird überschrieben
    }

    public void ShowInfo()
    {
        //Code to show the Canvas with Pic and Info Text about this Item
    }

    public void HideInfo()
    {
        //Code to close the Info Canvas
    }
}
