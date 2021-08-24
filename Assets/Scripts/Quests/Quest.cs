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

    public delegate void QuestCompletedDelegate();

    public event QuestCompletedDelegate completedQuestEvent;
    

    private void Start()
    {
        goalItem.interactedEvent += CompleteQuest;
    }

    private void CompleteQuest(Interactable item)
    {
        goalItem.interactedEvent -= CompleteQuest;
        
        //Broadcast that this quest is completed
        if (completedQuestEvent != null)
        {
            completedQuestEvent();
        }
        SetCompleted(true);
        SetActive(false);
        Debug.Log("You completed the quest " + quest.title);
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
