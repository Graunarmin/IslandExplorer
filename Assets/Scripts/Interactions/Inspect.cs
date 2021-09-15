using UnityEngine;

public class Inspect : Interaction
{
    protected Item item;
    
    public string displayText;

    void Start()
    {
        item = Interactable.ActiveInteractable as Item;
        if (item != null)
        {
            icon = item.itemInfo.icon;
        }
    }
    public override void Interact()
    {
        if (!References.instance.infoBoxCanvas.gameObject.activeInHierarchy)
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
        References.instance.infoBoxCanvas.Activate(icon, displayText);
    }

    protected void HideInfo()
    {
        References.instance.infoBoxCanvas.Close();
    }
}