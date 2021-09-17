using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuObject : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();
    public OptionsMenu optionsMenuUI;
    public PopUpWindow creditsPopUp;
    public PopUpWindow progressPopUp;
    public PopUpWindow controlsPopUp;

    public static event Action ResumeGameEvent;
    public static event Action PlayGame;
    public static event Action QuitGame;

    private Button currentButton;

    private void OnEnable()
    {
        PopUpWindow.ClosePopUp += PopUpWasClosed;
        progressPopUp?.Deactivate();
        controlsPopUp?.Deactivate();
        optionsMenuUI?.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        PopUpWindow.ClosePopUp -= PopUpWasClosed;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        currentButton = buttons[0];
        currentButton.Select();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void PlayButton()
    {
        PlayGame?.Invoke();
    }
    public void ContinueButton()
    {
        ResumeGameEvent?.Invoke();
    }

    public void OptionsButton(Button button)
    {
       Deactivate();
       optionsMenuUI.Activate(this);
       currentButton = button;
    }

    public void ControlsButton(Button button)
    {
        ShowPopUp(controlsPopUp, "Controls");
        currentButton = button;
    }

    public void MainMenuButton(Button button)
    {
        ShowPopUp(progressPopUp, "MainMenu");
        currentButton = button;
    }

    public void CreditsButton(Button button)
    {
        ShowPopUp(creditsPopUp, "Credits");
        currentButton = button;
    }

    public void QuitButton(Button button)
    {
        ShowPopUp(progressPopUp, "Quit");
        currentButton = button;
    }

    public void QuitFromMain()
    {
        QuitGame?.Invoke();
    }

    private void ShowPopUp(PopUpWindow popUp, string caller)
    {
        popUp.ShowWindow(caller);
        EnableButtons(false);
    }

    public void HidePopUp(PopUpWindow popUp)
    {
        popUp.HideWindow();
        PopUpWasClosed();
    }

    private void PopUpWasClosed()
    {
        EnableButtons(true);
    }
    
    public void EnableButtons(bool state)
    {
        foreach (Button button in buttons)
        {
            button.interactable = state;
        }

        if (state)
        {
            currentButton.Select();
        }
    }
}
