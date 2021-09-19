using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpWindow : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();
    public static event Action QuitGameEvent;
    public static event Action LoadMainMenuEvent;

    public static event Action ClosePopUpEvent;

    private string calledBy;
    public bool IsActive
    {
        get { return gameObject.activeInHierarchy; }
    }
    
    public void ShowWindow(string caller)
    {   
        gameObject.SetActive(true);
        if (gameObject.GetComponent<UITweener>() != null)
        {
            Debug.Log("Has Tweener Component");
            gameObject.GetComponent<UITweener>().Show();
        }
        calledBy = caller;
        buttons[0].Select();
    }

    public void HideWindow()
    {
        if (gameObject.GetComponent<UITweener>() != null)
        {
            Debug.Log("Has Tweener Component");
            gameObject.GetComponent<UITweener>().Disable();
        }
        else
        {
            Deactivate();
        }
        ClosePopUpEvent?.Invoke();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void DoClosingAction()
    {
        switch (calledBy)
        {
            case "MainMenu":
                LoadMainMenu();
                break;
            case "Quit":
                QuitGame();
                break;
        }
    }

    private void LoadMainMenu()
    {
        LoadMainMenuEvent?.Invoke();
    }

    private void QuitGame()
    {
        QuitGameEvent?.Invoke();
    }
}
