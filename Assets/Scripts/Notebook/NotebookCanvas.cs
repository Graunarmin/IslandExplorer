using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NotebookCanvas : InspectorCanvas
{
    [SerializeField] private Image background;
    
    [Header("Quest Section")]
    [SerializeField] private Button questButton;
    [SerializeField] private GameObject questSection;
    [SerializeField] private Sprite questBackground;
    
    [Header("Sticker Section")]
    [SerializeField] private Button stickerButton;
    [SerializeField] private GameObject stickerSection;
    [SerializeField] private Sprite stickerBackground;
    
    [Header("Map Section")]
    [SerializeField] private Button mapButton;
    [SerializeField] private GameObject mapSection;
    [SerializeField] private Sprite mapBackground;
    
    public void OnEnable()
    {
        OnQuestButton();
        questButton.Select();
    }

    public void OnQuestButton()
    {
        background.sprite = questBackground;
        questSection.SetActive(true);
        stickerSection.SetActive(false);
        mapSection.SetActive(false);
        questButton.Select();
    }

    public void OnStickerButton()
    {
        OnQuestButton();
        background.sprite = stickerBackground;
        questSection.SetActive(false);
        stickerSection.SetActive(true);
        mapSection.SetActive(false);
        stickerButton.Select();
    }

    public void OnMapButton()
    {
        OnQuestButton();
        background.sprite = mapBackground;
        questSection.SetActive(false);
        stickerSection.SetActive(false);
        mapSection.SetActive(true);
        mapButton.Select();
    }
}
