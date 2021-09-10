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
        Reset();
        questButton.Select();
    }

    public void OnQuestButton()
    {
        Reset();
        background.sprite = questBackground;
        questSection.SetActive(true);
        questButton.Select();
    }

    public void OnStickerButton()
    {
        Reset();
        background.sprite = stickerBackground;
        stickerSection.SetActive(true);
        stickerButton.Select();
    }

    public void OnMapButton()
    {
        Reset();
        background.sprite = mapBackground;
        mapSection.SetActive(true);
        mapButton.Select();
    }
    private void Reset()
    {
        background.sprite = questBackground;
        questSection.SetActive(false);
        stickerSection.SetActive(false);
        mapSection.SetActive(false);
        questButton.Select();
    }
}
