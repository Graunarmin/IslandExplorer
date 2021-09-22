using UnityEngine;

public class Inspect : Interaction
{
    protected Item item;

    protected override void Start()
    {
        item = Interactable.ActiveInteractable as Item;
        if (item != null)
        {
            icon = item.itemInfo.icon;
        }
    }
    public override void Interact()
    {
        if (!References.Instance.infoBoxCanvas.gameObject.activeInHierarchy)
        {
            ShowInfo();
        }
        else
        {
            HideInfo();
            ReactToInteraction();
            OnInteract();
        }
    }
    
    protected void ShowInfo()
    {
        References.Instance.infoBoxCanvas.Activate(icon, item.itemInfo.infoText);
    }

    protected void HideInfo()
    {
        References.Instance.infoBoxCanvas.Close();
    }
}