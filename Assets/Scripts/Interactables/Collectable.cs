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
            //DisableMovement();
        }
        else
        {
            HideInfo();
            PickUpItem();
            //EnableMovement();
        }
        
    }

    private void PickUpItem()
    {
        item.CollectItem();
        item.location.RemoveItem(item);
        gameObject.SetActive(false);
        References.instance.activeItem = null;
    }
    
}