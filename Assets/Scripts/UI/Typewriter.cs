using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Typewriter : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float speed;
    private string story;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        story = text.text;
        text.text = "";

        StartCoroutine(PlayText());
    }

    IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            text.text += c;
            yield return new WaitForSeconds(speed);
        }
    }
}
