using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerManager : MonoBehaviour
{
    public List<Sticker> stickers = new List<Sticker>();
    
    private void OnEnable()
    {
        Interactable.InteractedEvent += AddSticker;
    }

    private void OnDisable()
    {
        Interactable.InteractedEvent -= AddSticker;
    }
    
       public static event Action<StickerItem> AddedStickerToLexiconEvent;

    private void AddSticker(Interactable item)
    {
        if (item is StickerItem)
        {
            StickerItem stickerItem = item as StickerItem;
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
