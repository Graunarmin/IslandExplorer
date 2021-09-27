using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StickerItem : Item
{
    [SerializeField] bool isInLexicon;

    private void OnEnable()
    {
        StickerManager.AddedStickerToLexiconEvent += AddToLexicon;
    }

    private void AddToLexicon(StickerItem item)
    {
        if (item == this)
        {
            isInLexicon = true;
        }
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
