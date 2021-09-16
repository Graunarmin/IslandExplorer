using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopUpWindow : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();
    public static event Action QuitGameEvent;
    public static event Action LoadMainMenuEvent;
    public bool IsActive
    {
        get { return gameObject.activeInHierarchy; }
    }
    
    public void ShowWindow()
    {
        gameObject.SetActive(true);
        buttons[0].Select();
    }

    public void HideWindow()
    {
        gameObject.SetActive(false);
    }

    public void LoadMainMenu()
    {
        LoadMainMenuEvent?.Invoke();
    }

    public void QuitGame()
    {
        QuitGameEvent?.Invoke();
    }
}
