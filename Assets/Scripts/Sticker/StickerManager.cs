using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerManager : MonoBehaviour
{
    public List<Sticker> stickers = new List<Sticker>();
    
    public static event Action<StickerItem> AddedStickerToLexiconEvent;
    
    private void OnEnable()
    {
        Interactable.InteractedEvent += AddSticker;
    }

    private void OnDisable()
    {
        Interactable.InteractedEvent -= AddSticker;
    }

    private void AddSticker(Interactable item, Interaction interaction)
    {
        if (item is StickerItem)
        {
            StickerItem stickerItem = item as StickerItem;
            if (!stickerItem.IsInLexicon())
            {
                foreach (Sticker sticker in stickers)
                {
                    if (!sticker.WasCollected)
                    {
                        sticker.AddSticker(stickerItem); 
                        AddedStickerToLexiconEvent?.Invoke(stickerItem);
                        return;
                    }
                }
            }
        }
    }
}
