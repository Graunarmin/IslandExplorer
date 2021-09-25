using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Soundeffects")] 
    public RandomSound footsteps;
    public RandomSound moveBoulders;
    public RandomSound pickAxe;
    public RandomSound pickUp;
    public RandomSound turnPage;
    public Sound walkiTalki;
    public Sound stoneBridge;
    public Sound openNotebook;
    public Sound buttonClick;
    public Sound buttonHover;

    [Header("Music")] 
    public Sound oceanTheme;
    public Sound caveTheme;
    public Sound forestTheme;
    public Sound desertTheme;

    private bool _playLoop;
    
    private void OnEnable()
    {
        PlayerMovement.IsWalkingEvent += play => RepeatPlaying(play, footsteps);
        Move.MovedStoneEvent += _ => Play(moveBoulders);
        Interactable.InteractedEvent += ChooseInteraction;
        NotebookCanvas.PageTurnedEvent += _ => Play(turnPage);
        WalkiTalki.WalkiTalkiCallEvent += _ => Play(walkiTalki, true);
        Move.MovedStoneToWaterEvent += _ => Play(stoneBridge, true);
        Notebook.ReadingNotebookEvent += _ => Play(openNotebook, true);
        MenuButton.ButtonClickedEvent += _ => Play(buttonClick, true);
        MenuButton.ButtonSelectedEvent += _ => Play(buttonHover, true);
        Area.EnteredAreaEvent += Play;
    }
    
    private void ChooseInteraction(Interactable item, Interaction interaction)
    {
        if (interaction is Destroy)
        {
            Play(pickAxe);
        }

        if (interaction is Collect)
        {
            Play(pickUp);
        }
    }

    private void RepeatPlaying(bool play, RandomSound sound)
    {
        if (play)
        {
            _playLoop = true;
            StartCoroutine(LoopPlayer(sound));
        }
        else
        {
            _playLoop = false;
            StopCoroutine(LoopPlayer(sound));
        }
    }

    IEnumerator LoopPlayer(RandomSound sound)
    {
        while (_playLoop)
        {
            Play(sound);
            yield return new WaitForSeconds(.5f);
        }
    }

    public void Play(Sound sound, bool play)
    {
        if (sound != null && play)
        {
            sound.Play();
        }else if (!play)
        {
            sound.Stop();
        }
    }

    public void Play(RandomSound sound)
    {
        sound.Play();
    }
}
