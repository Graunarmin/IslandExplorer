using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
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

    public void SetQuest(string questTitle)
    {
        Quest activeQuest;
        if (!questsDict.TryGetValue(questTitle, out activeQuest))
        {
            Debug.Log("Quest " + questTitle + " is not in Catalogue!");
            return;
        }
        activeQuest.SetActive(true);
        QuestWasGivenEvent?.Invoke(activeQuest);
    }
}
