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
        //So we can't click on anything in the background
        //Time.timeScale = 0f;
        //Disable clicking on items behind canvas

        gameObject.SetActive(true);
        image.sprite = pic;
        textBox.text = text;

    }

    public void Close()
    {
        //Enable clicking on items again
        //Time.timeScale = 1f;
        gameObject.SetActive(false);

    }
}
