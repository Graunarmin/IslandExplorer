using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public QuestAsset quest;

    private bool isActive;
    private bool isComplete;

    public void SetActive(bool status)
    {
        isActive = true;
    }

    public void SetCompleted(bool status)
    {
        isComplete = status;
    }

    public bool IsActive()
    {
        return isActive;
    }

    public bool IsCompleted()
    {
        return isComplete;
    }

    public void CheckStatus()
    {
        if (quest.goalItem.isCollected)
        {
            SetCompleted(true);
            SetActive(false);
        }
    }
    
    
}
