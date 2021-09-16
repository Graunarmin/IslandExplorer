using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    #region Singleton

    public static GameManager gameManager;
    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Debug.LogWarning("More than one instance of GameManager!");
        }
    }

    #endregion

    #region Event subscriptions
    private void OnEnable()
    {
        InspectorCanvas.Interacting += FreezeMovement;
        InspectorCanvas.Interacting += SetInteracting;
        DialogManager.DialogStarted += SetInDialog;
        MenuManager.GamePausedEvent += FreezeMovement;
        PopUpWindow.QuitGameEvent += QuitGame;
        PopUpWindow.LoadMainMenuEvent += LoadMainMenu;
    }

    private void OnDisable()
    {
        InspectorCanvas.Interacting -= FreezeMovement;
        InspectorCanvas.Interacting -= SetInteracting;
        DialogManager.DialogStarted -= SetInDialog;
        MenuManager.GamePausedEvent -= FreezeMovement;
        PopUpWindow.QuitGameEvent -= QuitGame;
        PopUpWindow.LoadMainMenuEvent -= LoadMainMenu;
    }
    #endregion
    
    #region States
    
    private bool currentlyInteracting;
    private bool inDialog;
    
    private void SetInteracting(bool status)
    {
        currentlyInteracting = status;
    }

    private void SetInDialog(bool status)
    {
        inDialog = status;
        FreezeMovement(status);
    }
    
    #endregion
    
    #region UserInput
    
    private KeyCode interact = KeyCode.Space;
    private KeyCode notebook = KeyCode.E;
    private KeyCode pause = KeyCode.Escape;
    //private KeyCode walkiTalki = KeyCode.T;
    
    #region Input Events
    public static event Action InteractionPressedEvent;
    public static event Action PausePressedEvent;
    
    #endregion
    void Update()
    {
        if (!inDialog)
        {
            if (Input.GetKeyDown(interact))
            {
                InteractionPressedEvent?.Invoke();
            }
            
            if (!currentlyInteracting) //meaning no Canvases open
            {
                if (Input.GetKeyDown(notebook))
                {
                    References.instance.notebookCanvas.Activate();
                }
            }
            else
            {
                if(Input.GetKeyDown(notebook) && InspectorCanvas.ActiveCanvas is NotebookCanvas)
                {
                    References.instance.notebookCanvas.Close();
                }
            }

            if (Input.GetKeyDown(pause))
            {
                PausePressedEvent?.Invoke();
            }
        }
    }
    #endregion

    
    private void FreezeMovement(bool status)
    {
        References.instance.player.GetComponent<PlayerMovement>().enabled = !status;
    }

    private void LoadMainMenu()
    {
        Debug.Log("Loading Main Menu");
        SceneManager.LoadScene("01_MainMenu");
    }

    private void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
