using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    private bool isActive;
    private bool isComplete;
    public QuestAsset quest;
    public QuestItem goalItem;
    [SerializeField] private QuestEntry questEntry;

    public static Quest ActiveQuest { get; private set; }
    public static event Action<Quest> completedQuestEvent;

    private void Start()
    {
        Interactable.InteractedEvent += CompleteQuest;
    }

    private void CompleteQuest(Interactable item)
    {
        if (isActive)
        {
            if (item is QuestItem)
            {
                if (item == goalItem)
                {
                    Interactable.InteractedEvent -= CompleteQuest;
        
                    //Broadcast that this quest is completed
                    completedQuestEvent?.Invoke(this);
                    questEntry.CheckBox(this);
                
                    SetCompleted(true);
                    SetActive(false);
                    Debug.Log("You completed the quest " + quest.title);
                }
            }
        }
    }
    
    public void SetActive(bool status)
    {
        isActive = status;
        if (isActive)
        {
            SetActiveQuest(true);
            questEntry.enabled = true;
            questEntry.SetQuest(this);
        }
        else
        {
            SetActiveQuest(false);
        }
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
    
    void SetActiveQuest(bool set)
    {
        if (set)
        {
            ActiveQuest = this;
        }
        else
        {
            ActiveQuest = null;
        }
    }
}
