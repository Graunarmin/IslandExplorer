using UnityEngine;

public class Talk : Interaction
{
    public override void Interact()
    {
        DialogManager.dialogManager.StartDialog();
    }
}
