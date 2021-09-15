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
    [SerializeField] private TextMeshProUGUI textField;
    private Quest attachedQuest;

    private void Awake()
    {
        checkBox.sprite = box;
        gameObject.SetActive(false);
        textField.gameObject.SetActive(false);
    }

    public void SetQuest(Quest quest)
    {
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
