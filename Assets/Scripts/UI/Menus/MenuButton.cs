using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    
    public static event Action<bool> ButtonSelectedEvent;
    public static event Action<bool> ButtonClickedEvent;
    
    public bool playHoverSound;
    public bool changeColor;
    public TextMeshProUGUI text;
    public Color hoverColor;

    private Color originColor;
    public void OnSelect(BaseEventData eventData)
    {
        if (playHoverSound)
        {
            ButtonSelectedEvent?.Invoke(true);
        }

        if (changeColor)
        {
            ChangeColor();
        }
    }

    private void ChangeColor()
    {
        originColor = text.color;
        text.color = hoverColor;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (changeColor)
        {
            text.color = originColor;
        }
    }

    public void OnClick()
    {
        if (changeColor)
        {
            text.color = originColor;
        }
        ButtonClickedEvent?.Invoke(true);
    }
}
