using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    public Sound buttonClick;
    public Sound buttonHover;
    
    private void OnEnable()
    {
        MenuButton.ButtonClickedEvent += _ => Play(buttonClick);
        MenuButton.ButtonSelectedEvent += _ => Play(buttonHover);
    }
    
    public void Play(Sound sound)
    {
        if (sound != null)
        {
            sound.Play();
        }
    }
}
