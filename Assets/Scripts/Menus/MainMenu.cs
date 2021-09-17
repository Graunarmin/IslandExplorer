using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menuCanvas;
    public MenuObject mainMenuUI;
    public float fadeInTime;

    public List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>();

    private void Start()
    {
        menuCanvas.SetActive(true);
        mainMenuUI.Activate();
        StartCoroutine(ActivateButtons());

        foreach (TextMeshProUGUI text in texts)
        {
            StartCoroutine(FadeTextToFullAlpha(fadeInTime, text));
        }
    }

    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI textElement)
    {
        //first set alpha to zero
        textElement.color = new Color(textElement.color.r, textElement.color.g, textElement.color.b, 0);

        //wait until video is loaded
        //yield return new WaitForSecondsRealtime(2f);

        //the fade in text
        while (textElement.color.a < 1.0f)
        {
            textElement.color = new Color(textElement.color.r, textElement.color.g, textElement.color.b, textElement.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator ActivateButtons()
    {
        mainMenuUI.EnableButtons(false);

        //Wait until text is loaded
        yield return new WaitForSeconds(fadeInTime + 1f);

        mainMenuUI.EnableButtons(true);
    }
    
    
}
