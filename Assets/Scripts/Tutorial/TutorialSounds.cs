using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TutorialSounds : MonoBehaviour
{
    
    public Sound buttonClick;
    public Sound buttonHover;
    private void OnEnable()
    {
        MenuButton.ButtonClickedEvent += _ => Play(buttonClick, true, 0f);
        MenuButton.ButtonSelectedEvent += _ => Play(buttonHover, true, 0f);
        Area.EnteredAreaEvent += Play;
    }

    private void OnDisable()
    {
        Area.EnteredAreaEvent -= Play;
        MenuButton.ButtonClickedEvent -= _ => Play(buttonClick, true, 0f);
        MenuButton.ButtonSelectedEvent -= _ => Play(buttonHover, true, 0f);
    }

    public void Play(Sound sound, bool play, float delayTime)
    {
        Area.EnteredAreaEvent -= Play;
        StartCoroutine(PlayDelayed(sound, play, delayTime));
    }

    IEnumerator PlayDelayed(Sound sound, bool play, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        if (sound != null && play)
        {
            sound.Play();
        }else if (!play)
        {
            sound.Stop();
        }
        
    }
}
