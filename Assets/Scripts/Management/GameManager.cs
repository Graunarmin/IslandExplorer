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
        InspectorCanvas.InteractingEvent += SetInteracting;
        DialogManager.DialogStartedEvent += SetInDialog;
        PauseMenu.GamePausedEvent += SetGamePaused;
        Notebook.ReadingNotebookEvent += SetReadingNotebook;
        PuzzleArea.PuzzleEnteredEvent += SetInPuzzle;
        PopUpWindow.QuitGameEvent += QuitGame;
        PopUpWindow.LoadMainMenuEvent += LoadMainMenu;
        WalkiTalki.WalkiTalkiCallEvent += SetWalkieTalkie;
    }

    private void OnDisable()
    {
        InspectorCanvas.InteractingEvent -= SetInteracting;
        DialogManager.DialogStartedEvent -= SetInDialog;
        PauseMenu.GamePausedEvent -= SetGamePaused;
        Notebook.ReadingNotebookEvent -= SetReadingNotebook;
        PuzzleArea.PuzzleEnteredEvent -= SetInPuzzle;
        PopUpWindow.QuitGameEvent -= QuitGame;
        PopUpWindow.LoadMainMenuEvent -= LoadMainMenu;
        WalkiTalki.WalkiTalkiCallEvent -= SetWalkieTalkie;
    }
    #endregion
    
    #region States
    
    private bool currentlyInteracting;
    private bool inDialog;
    private bool readingNotebook;
    private bool gamePaused;
    private bool inPuzzle;
    private bool walkietalkie;
    
    private void SetInteracting(bool status)
    {
        currentlyInteracting = status;
        FreezeMovement(status);
    }

    private void SetInDialog(bool status)
    {
        inDialog = status;
        if (!status)
        {
            walkietalkie = status;
        }
        FreezeMovement(status);
    }

    private void SetReadingNotebook(bool status)
    {
        readingNotebook = status;
        if (!currentlyInteracting)
        {
            FreezeMovement(status);
        }
    }

    private void SetGamePaused(bool status)
    {
        gamePaused = status;
        Debug.Log("Game Paused: " + status);
        if (!currentlyInteracting && !readingNotebook)
        {
            FreezeMovement(status);
        }
    }

    private void SetInPuzzle(bool status)
    {
        inPuzzle = status;
    }

    private void SetWalkieTalkie(bool status)
    {
        walkietalkie = status;
    }
    
    #endregion
    
    #region UserInput
    
    private KeyCode interact = KeyCode.E;
    private KeyCode notebook = KeyCode.Tab;
    private KeyCode pause = KeyCode.Escape;
    private KeyCode reset = KeyCode.R;
    //private KeyCode walkiTalki = KeyCode.T;
    
    #region Input Events
    public static event Action InteractionPressedEvent;
    public static event Action PausePressedEvent;
    public static event Action NotebookPressedEvent;
    public static event Action ResetEvent;
    
    #endregion
    void Update()
    {
        if (!inDialog && !walkietalkie)
        {
            if (Input.GetKeyDown(pause))
            {
                PausePressedEvent?.Invoke();
                return;
            }
            if (!gamePaused)
            {
                if (Input.GetKeyDown(notebook))
                {
                    NotebookPressedEvent?.Invoke();
                    return;
                }
                if (!readingNotebook)
                {
                    if (Input.GetKeyDown(interact))
                    {
                        InteractionPressedEvent?.Invoke();
                        return;
                    }
                    if (inPuzzle)
                    {
                        if (Input.GetKeyDown(reset))
                        {
                            ResetEvent?.Invoke();
                            return;
                        }
                    }
                }
            }
        }
    }
    #endregion

    
    private void FreezeMovement(bool status)
    {
        References.Instance.player.GetComponent<PlayerMovement>().enabled = !status;
    }

    private void LoadMainMenu()
    {
        Debug.Log("Loading Main Menu");
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync("01_MainMenu"));
    }

    private void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
