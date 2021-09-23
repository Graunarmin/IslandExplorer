using System;
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
    public RandomSound addSticker;
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

    private bool walking;

    private void OnEnable()
    {
        Notebook.ReadingNotebookEvent += _ => Play(openNotebook);
        NotebookCanvas.PageTurnedEvent += _ => Play(turnPage);
        Move.MovedStoneEvent += _ => Play(moveBoulders);
        Move.MovedStoneToWaterEvent += _ => Play(stoneBridge);
    }

    private void SetWalking(bool status)
    {
        walking = status;
    }

    public void Play(Sound sound)
    {
        if (sound != null)
        {
            sound.Play();
        }
    }

    public void Play(RandomSound sound)
    {
        sound.Play();
    }

    public void KeepPlaying(RandomSound sound, bool prerequisite)
    {
        while (prerequisite)
        {
            sound.Play();
        }
    }

}
