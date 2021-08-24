using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoBoxCanvas : InspectorCanvas
{

    public Image image;
    public TextMeshProUGUI textBox;
    
    public void Activate(Sprite pic, string text)
    {
        Activate();
        gameObject.SetActive(true);
        image.sprite = pic;
        textBox.text = text;
    }
    
}
