public class Collectable : Interactable
{

    protected override void Collect()
    {
        base.Collect();
        PickUpItem();
    }

    private void PickUpItem()
    {
        item.location.RemoveItem(item);
        References.instance.activeItem = null;
        gameObject.SetActive(false);
    }
    
}