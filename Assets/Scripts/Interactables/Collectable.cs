public class Collectable : Interactable
{
    private void Awake()
    {
        item = GetComponent<Item>();
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
            PickUpItem();
        }
        
    }

    private void PickUpItem()
    {
        item.CollectItem();
        gameObject.SetActive(false);
    }
    
}