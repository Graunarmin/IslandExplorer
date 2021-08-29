using System;
using UnityEngine;

public class Talk : Interaction
{
    public override void Interact()
    {
        if (Character.ActiveInteractable && !DialogManager.dialogManager.inDialog)
        {
            DialogManager.dialogManager.ActivateDialog();
        }
    }
}
