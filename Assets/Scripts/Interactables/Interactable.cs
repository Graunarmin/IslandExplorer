using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{   
    
    // hat vielleicht Interaction Icons, Text o.ä. 
    
    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
    }

    public virtual void Interact()
    {
        //wird überschrieben
    }
    
    
}
