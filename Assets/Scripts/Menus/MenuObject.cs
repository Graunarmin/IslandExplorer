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

    private void OnEnable()
    {
        PopUpWindow.ClosePopUp += PopUpWasClosed;
        progressPopUp?.Deactivate();
        controlsPopUp?.Deactivate();
    }

    private void OnDisable()
    {
        PopUpWindow.ClosePopUp -= PopUpWasClosed;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        buttons[0].Select();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void PlayButton()
    {
        PlayGame();
    }
    public void ContinueButton()
    {
        ResumeGameEvent?.Invoke();
    }

    public void OptionsButton()
    {
       Deactivate();
       optionsMenuUI.Activate(this);
    }

    public void ControlsButton()
    {
        ShowPopUp(controlsPopUp, "Controls");
    }

    public void MainMenuButton()
    {
        ShowPopUp(progressPopUp, "MainMenu");
    }

    public void CreditsButton()
    {
        ShowPopUp(creditsPopUp, "Credits");
    }

    public void QuitButton()
    {
        ShowPopUp(progressPopUp, "Quit");
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
        Debug.Log("Enabeling Buttons: " + state);
        foreach (Button button in buttons)
        {
            button.interactable = state;
        }

        if (state)
        {
            buttons[0].Select();
        }
    }

    private void PlayGame()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1));
    }
}
