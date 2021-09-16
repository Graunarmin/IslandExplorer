using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public List<Button> buttons = new List<Button>();
    public PopUpWindow progressPopUp;
    public PopUpWindow controlsPopUp;

    public static event Action<bool> GamePausedEvent;

    private void OnEnable()
    {
        GameManager.PausePressedEvent += PauseInteraction;
    }

    private void OnDisable()
    {
        GameManager.PausePressedEvent -= PauseInteraction;
    }

    public void PauseInteraction()
    {
        if (progressPopUp.IsActive)
        {
            HidePopUp(progressPopUp);
        }
        else if (controlsPopUp.IsActive)
        {
            HidePopUp(controlsPopUp);
        }
        else if (gameObject.activeInHierarchy)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void ContinueButton()
    {
        ResumeGame();
    }

    public void OptionsButton()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    public void ControlsButton()
    {
        ShowPopUp(controlsPopUp);
    }

    public void MainMenuButton()
    {
        ShowPopUp(progressPopUp);
    }

    public void QuitButton()
    {
        ShowPopUp(progressPopUp);
    }

    private void ShowPopUp(PopUpWindow popUp)
    {
        popUp.ShowWindow();
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
    }

    private void HidePopUp(PopUpWindow popUp)
    {
        popUp.HideWindow();
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
        buttons[0].Select();
    }
    
    private void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        buttons[0].Select();
        GamePausedEvent?.Invoke(true);
        
        Debug.Log("Pause Game");
    }

    private void ResumeGame()
    {
        GamePausedEvent?.Invoke(false);
        pauseMenuUI.SetActive(false);
        
        Debug.Log("Resume Game");
    }

}
