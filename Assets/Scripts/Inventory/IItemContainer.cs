using System.Collections.Generic;


public interface IItemContainer
{
    bool AddItem(Interactable item);
    bool RemoveItem(Interactable item);
    bool ContainsItem(Interactable item);
    bool IsFull();
    int Size();
    List<Interactable> GetContainer();
}
