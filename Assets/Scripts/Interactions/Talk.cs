using System;
using UnityEngine;

public class Talk : Interaction
{

    private Character character;

    private void Start()
    {
        character = Interactable.ActiveInteractable as Character;
    }

    public override void Interact()
    {
        if (Character.ActiveInteractable && !DialogManager.dialogManager.inDialog)
        {
            DialogManager.dialogManager.ActivateDialog(character);
        }
    }
}
