using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StickerItem : Item
{

    public Image sticker;
    public TextMeshProUGUI infoText;

    [SerializeField] bool isInLexicon;
    
    
    public override void InteractionHappened()
    {
        base.InteractionHappened();
        
        //Maybe with event?
        AddToLexicon();
    }

    private void AddToLexicon()
    {
        isInLexicon = true;
    }
    
    private void RemoveFromLexicon()
    {
        isInLexicon = false;
    }

    public bool IsInLexicon()
    {
        return isInLexicon;
    }
}
