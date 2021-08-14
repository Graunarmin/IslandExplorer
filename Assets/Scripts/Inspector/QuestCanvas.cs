using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestCanvas : MonoBehaviour
{
    public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questText;
    public Image questIcon;

    public void Activate(string title, string text, Sprite icon)
    {
        GameManager.gameManager.FreezeMovement();
        
        gameObject.SetActive(true);
        questTitle.text = title;
        questText.text = text;
        questIcon.sprite = icon;
    }

    public void Close()
    {
        GameManager.gameManager.UnfreezeMovement();
        
        gameObject.SetActive(false);
    }
}
