using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : Item
{
    
    public override void WasInteractedWith(Interaction interaction)
    {
        base.WasInteractedWith(interaction);
        
        location.RemoveItem(this);
        gameObject.SetActive(false);
    }
    
}
