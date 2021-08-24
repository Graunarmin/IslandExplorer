using UnityEngine;

public class Inspect : Interaction
{
    protected Item item;
    
    protected Sprite icon;
    public string displayText;

    void Start()
    {
        item = interactable as Item;
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
        }
        base.Interact();
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