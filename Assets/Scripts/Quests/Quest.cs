using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public QuestAsset quest;
    public QuestItem goalItem;
    private bool isActive;
    private bool isComplete;

    public static event Action<Quest> completedQuestEvent;

    private void Start()
    {
        Interactable.InteractedEvent += CompleteQuest;
    }

    private void CompleteQuest(Interactable item)
    {
        if (item is QuestItem)
        {
            if (item == goalItem)
            {
                Interactable.InteractedEvent -= CompleteQuest;
        
                //Broadcast that this quest is completed
                completedQuestEvent?.Invoke(this);
                
                SetCompleted(true);
                SetActive(false);
                Debug.Log("You completed the quest " + quest.title);
            }
        }
        
    }
    
    private void SetActive(bool status)
    {
        isActive = true;
    }

    private void SetCompleted(bool status)
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

    
    
    
}
