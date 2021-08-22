using UnityEngine;

// gives Information about a certain Type of Items, e.g. Rocks.
// All Rocks have the same name and properties regarding being a collectable.
//But they don't all have the same location, so this field is not in here

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemAsset : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite icon = null;

}
