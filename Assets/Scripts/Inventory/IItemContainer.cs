using System.Collections.Generic;


public interface IItemContainer
{
    bool AddItem(Item item, int index = 0);
    bool RemoveItem(Item item);
    bool RemoveItem(ItemAsset item);
    Item GetItemAtIndex(int index);
    bool ContainsItem(Item item);
    bool ContainsItem(ItemAsset item);
    void IncreaseItemCount(Item item);
    void IncreaseItemCount(ItemAsset item);
    bool IsFull();
    int Size();
    void SetSpace(int space);
    List<Item> GetContainer();

}
