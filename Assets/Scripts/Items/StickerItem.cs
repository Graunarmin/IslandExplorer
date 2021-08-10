using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StickerItem : Item
{

    public Image sticker;
    public TextMeshProUGUI infoText;
    public override void CollectItem()
    {
        AddToWiki();
    }

    private void AddToWiki()
    {
        //Add Info + Sticker to the Journal
    }
}
