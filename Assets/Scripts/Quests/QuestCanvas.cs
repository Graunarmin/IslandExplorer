using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestCanvas : InspectorCanvas
{
    public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questText;
    public Image questIcon;

    public void Activate(string title, string text, Sprite icon)
    {
        base.Activate();
        
        questTitle.text = title;
        questText.text = text;
        questIcon.sprite = icon;
    }
    
}
