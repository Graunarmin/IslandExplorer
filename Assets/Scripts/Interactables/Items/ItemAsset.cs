using UnityEngine;

public enum ItemType
{
    Interactable,
    Item,
    Tool,
    StickerItem,
    BonusItem,
    QuestItem,
    PuzzleStone
}

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemAsset : ScriptableObject
{
    public ItemType itemType;
    public string itemName = "New Item";
    public Sprite icon = null;
    [TextArea(3,10)]
    public string infoText;
    public Sprite sticker;
    [TextArea(3,10)]
    public string lexiconText;
    public string questTitle;

}
