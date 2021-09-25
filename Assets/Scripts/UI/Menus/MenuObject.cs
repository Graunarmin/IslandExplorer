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
    public static event Action PlayGameEvent;
    public static event Action QuitGameEvent;

    private Button currentButton;
    private bool optionsActive = false;

    private void OnEnable()
    {
        PopUpWindow.ClosePopUpEvent += PopUpWasClosed;
        progressPopUp?.Deactivate();
        controlsPopUp?.Deactivate();
        optionsMenuUI?.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        PopUpWindow.ClosePopUpEvent -= PopUpWasClosed;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        if (!optionsActive)
        {
            currentButton = buttons[0];
        }
        optionsActive = false;
        currentButton.Select();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void PlayButton()
    {
        PlayGameEvent?.Invoke();
    }
    public void ContinueButton()
    {
        ResumeGameEvent?.Invoke();
        if (gameObject.GetComponent<UITweener>() != null)
        {
            gameObject.GetComponent<UITweener>().Disable();
        }
    }

    public void OptionsButton(Button button)
    {
       Deactivate();
       optionsMenuUI.Activate(this);
       currentButton = button;
       optionsActive = true;
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
        QuitGameEvent?.Invoke();
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
