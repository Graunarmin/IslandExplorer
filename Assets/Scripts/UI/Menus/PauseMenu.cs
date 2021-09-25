using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuCanvas;
    public MenuObject pauseMenuUI;

    private Interactable currentInteractable;

    public static event Action<bool> GamePausedEvent;
    private void Awake()
    {
        menuCanvas.SetActive(false);
    }
    
    private void OnEnable()
    {
        GameManager.PausePressedEvent += PauseInteraction;
        MenuObject.ResumeGameEvent += ResumeGame;
    }

    private void OnDisable()
    {
        GameManager.PausePressedEvent -= PauseInteraction;
        MenuObject.ResumeGameEvent -= ResumeGame;
    }

    void PauseInteraction()
    {
        if (menuCanvas.gameObject.activeInHierarchy)
        {
            if (pauseMenuUI.progressPopUp.IsActive)
            {
                pauseMenuUI.HidePopUp(pauseMenuUI.progressPopUp);
            }
            else if (pauseMenuUI.controlsPopUp.IsActive)
            {
                pauseMenuUI.HidePopUp(pauseMenuUI.controlsPopUp);
            }
            else if (pauseMenuUI.optionsMenuUI.IsActive)
            {
                pauseMenuUI.optionsMenuUI.Deactivate();
            }
            else
            {
                ResumeGame();
            }
        }
        else
        {
            PauseGame();
        }
    }
    
    private void PauseGame()
    {
        menuCanvas.SetActive(true);
        pauseMenuUI.Activate();
        GamePausedEvent?.Invoke(true);
    }

    private void ResumeGame()
    {
        pauseMenuUI.Deactivate();
        menuCanvas.SetActive(false);
        GamePausedEvent?.Invoke(false);
    }
}
