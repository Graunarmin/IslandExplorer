using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class QuestGiver : MonoBehaviour
{
    public Quest startQuest;
    [SerializeField] private List<Quest> quests = new List<Quest>();
    private Dictionary<string, Quest> questsDict = new Dictionary<string, Quest>();

    public static event Action<Quest> QuestWasGivenEvent;

    private void Awake()
    {
        foreach (Quest quest in quests)
        {
            questsDict.Add(quest.quest.title, quest);
        }
    }

    private void Start()
    {
        SetQuest(startQuest);
    }

    [YarnCommand("GiveQuest")]
    public void SetQuest(string questTitle)
    {
        Quest activeQuest;
        if (!questsDict.TryGetValue(questTitle, out activeQuest))
        {
            Debug.Log("Quest " + questTitle + " is not in Catalogue!");
            return;
        }
        SetQuest(activeQuest);
        
    }
    private void SetQuest(Quest quest)
    {
        Debug.Log("Give quest " + quest.quest.title );
        quest.SetActive(true);
        QuestWasGivenEvent?.Invoke(quest);
    }
}
