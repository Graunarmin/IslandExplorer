using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemAsset : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite icon = null;
}
