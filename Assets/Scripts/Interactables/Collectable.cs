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
        gameObject.SetActive(false);
    }
    
}