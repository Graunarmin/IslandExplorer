using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestEntry : MonoBehaviour
{
    [SerializeField] private Sprite box;
    [SerializeField] private Sprite checkMark;
    [SerializeField] private Image checkBox;
    public TextMeshProUGUI textField;
    private Quest attachedQuest;

    private void Awake()
    {
        checkBox.sprite = box;
    }

    public void SetQuest(Quest quest)
    {
        Debug.Log("Adding Quest to Notebook");
        attachedQuest = quest;
        gameObject.SetActive(true);
        textField.gameObject.SetActive(true);
        textField.text = quest.quest.questText;
    }

    public void CheckBox(Quest quest)
    {
        if (quest == attachedQuest)
        {
            checkBox.sprite = checkMark;
            Debug.Log("Checking of Box");
        }
    }
}
