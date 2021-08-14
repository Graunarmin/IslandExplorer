using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : StickerItem
{

    public bool isCollected;
    public override void CollectItem()
    {
        base.CollectItem();
        CheckQuest();
    }

    private void CheckQuest()
    {
        //mark quest as checked
        //initiate call from Prof
    }
}
