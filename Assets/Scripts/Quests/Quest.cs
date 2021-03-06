using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    private bool isActive;
    private bool isComplete;
    public QuestAsset quest;
    public Interactable goalItem;
    [SerializeField] private QuestEntry questEntry;

    public static Quest ActiveQuest { get; private set; }
    public static event Action<Quest> CompletedQuestEvent;

    private void Awake()
    {
        questEntry.gameObject.SetActive(false);
        questEntry.textField.gameObject.SetActive(false);
    }

    private void Start()
    {
        Interactable.InteractedEvent += CompleteQuest;
    }

    private void CompleteQuest(Interactable item, Interaction interaction)
    {
        if (isActive)
        {
            /*if (item is QuestItem)
            {*/
                if (item == goalItem)
                {
                    Interactable.InteractedEvent -= CompleteQuest;
        
                    //Broadcast that this quest is completed
                    CompletedQuestEvent?.Invoke(this);
                    SetQuestVariable();
                    questEntry.CheckBox(this);
                
                    SetCompleted(true);
                    SetActive(false);
                    Debug.Log("You completed the quest " + quest.title);
                }
            //}
        }
    }

    public void SetQuestVariable()
    {
        //Debug.Log("QuestProgress: " + DialogManager.dialogVariables.GetValue("$questprogress"));
        DialogManager.dialogVariables.SetValue("$questprogress",
            DialogManager.dialogVariables.GetValue("$questprogress").AsNumber + 1);
        //Debug.Log("QuestProgress: " + DialogManager.dialogVariables.GetValue("$questprogress"));
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
