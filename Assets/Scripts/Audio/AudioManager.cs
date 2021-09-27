using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.Playables;

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

    private Action<bool> walking;
    private Action<bool> movedStone;
    private Action<bool> pageTurned;
    private Action<bool> walkiTalkiCall;
    private Action<bool> movedStoneToWater;
    private Action<bool> openedNotebook;
    private Action<bool> buttonClicked;
    private Action<bool> buttonHovered;

    private void OnEnable()
    {
        walking = (play) => RepeatPlaying(play, footsteps);
        PlayerMovement.IsWalkingEvent += walking;
        
        movedStone = move => Play(moveBoulders);
        Move.MovedStoneEvent += movedStone;
        
        Interactable.InteractedEvent += ChooseInteraction;
        
        pageTurned = b => Play(turnPage);
        NotebookCanvas.PageTurnedEvent += pageTurned;
        
        walkiTalkiCall = b => Play(walkiTalki, true, 0.5f);
        WalkiTalki.WalkiTalkiCallEvent += walkiTalkiCall;
        
        movedStoneToWater = b => Play(stoneBridge, true, 0f);
        Move.MovedStoneToWaterEvent += movedStoneToWater;
        
        openedNotebook = b => Play(openNotebook, true, 0f);
        Notebook.ReadingNotebookEvent += openedNotebook;
        
        buttonClicked = b => Play(buttonClick, true, 0f);
        MenuButton.ButtonClickedEvent += buttonClicked;
        
        buttonHovered = b => Play(buttonHover, true, 0f);
        MenuButton.ButtonSelectedEvent += buttonHovered;
        
        Area.EnteredAreaEvent += Play;
 
    }
    
    private void OnDisable()
    {
        PlayerMovement.IsWalkingEvent -= walking;
        Move.MovedStoneEvent -= movedStone;
        Interactable.InteractedEvent -= ChooseInteraction;
        NotebookCanvas.PageTurnedEvent -= pageTurned;
        WalkiTalki.WalkiTalkiCallEvent -= walkiTalkiCall;
        Move.MovedStoneToWaterEvent -= movedStoneToWater;
        Notebook.ReadingNotebookEvent -= openedNotebook;
        MenuButton.ButtonClickedEvent -= buttonClicked;
        MenuButton.ButtonSelectedEvent -= buttonHovered;
        Area.EnteredAreaEvent -= Play;
    }
    
    private void ChooseInteraction(Interactable item, Interaction interaction)
    {
        if (interaction is DestroyStone)
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

    public void Play(Sound sound, bool play, float delayTime)
    {
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

    public void Play(RandomSound sound)
    {
        sound.Play();
    }
    
}
