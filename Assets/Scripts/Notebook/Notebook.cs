using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{

    [SerializeField] private NotebookCanvas notebookCanvas;
    public static event Action<bool> ReadingNotebookEvent;

    private void OnEnable()
    {
        GameManager.NotebookPressedEvent += HandleInput;
    }

    private void OnDisable()
    {
        GameManager.NotebookPressedEvent -= HandleInput;
    }

    private void HandleInput()
    {
        if (IsActive())
        {
            CloseNotebook();
            return;
        }
        OpenNotebook();
    }

    private void OpenNotebook()
    {
        ReadingNotebookEvent?.Invoke(true);
        notebookCanvas.Activate();
    }

    private void CloseNotebook()
    {
        ReadingNotebookEvent?.Invoke(false);
        notebookCanvas.Close();
    }

    private bool IsActive()
    {
        return notebookCanvas.gameObject.activeInHierarchy;
    }
    
}
