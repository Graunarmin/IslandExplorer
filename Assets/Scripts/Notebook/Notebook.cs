using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notebook : MonoBehaviour
{
    [Header("Quest Section")]
    public GameObject questSection;
    public Sprite emptyBox;
    public Sprite checkedBox;

    public Image checkImage;
    public TextMeshProUGUI textBox;
    
    [Header("Sticker Section")]
    public GameObject stickerSection;
    
    [Header("Map Section")]
    public GameObject mapSection;

    private void OnEnable()
    {
        QuestGiver.QuestWasGivenEvent += AddQuest;
    }

    private void OnDisable()
    {
        QuestGiver.QuestWasGivenEvent -= AddQuest;
    }

    private void AddQuest(Quest quest)
    {
        
    }
}
