using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractedPrereq : Prerequisite
{
    public Interactable targetInteractable;

    public override bool Complete
    {
        get
        {
            return targetInteractable.HasBeenVisited;
        }
    }
}
