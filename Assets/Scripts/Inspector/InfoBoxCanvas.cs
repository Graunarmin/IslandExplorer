using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoBoxCanvas : MonoBehaviour
{

    public Image image;
    public TextMeshProUGUI textBox;
    
    public void Activate(Sprite pic, string text)
    {
        //So the player can't move in the background
        GameManager.gameManager.FreezeMovement();

        gameObject.SetActive(true);
        image.sprite = pic;
        textBox.text = text;

    }

    public void Close()
    {
        GameManager.gameManager.UnfreezeMovement();
        gameObject.SetActive(false);

    }
}