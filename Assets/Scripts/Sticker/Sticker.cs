using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sticker : MonoBehaviour
{
   [SerializeField] private Image stickerBox;

   private bool isFull;
   private StickerItem collectedItem;
   
   public bool WasCollected
   {
      get { return isFull; }
   }

   public void AddSticker(StickerItem item)
   {
      stickerBox.sprite = item.itemInfo.sticker;
      stickerBox.color = new Color(stickerBox.color.r, stickerBox.color.g, stickerBox.color.b, 255);
      isFull = true;
      collectedItem = item;
   }
}
