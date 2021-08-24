using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    #region Singleton

    public static DialogManager dialogManager;
    private void Awake()
    {
        if (dialogManager == null)
        {
            dialogManager = this;
        }
        else
        {
            Debug.LogWarning("More than one instance of DialogManager!");
        }
    }

    #endregion
    
    public DialogCanvas dialogCanvas;
    public void StartDialog()
    {
        dialogCanvas.Activate();
    }

    public void StopDialog()
    {
        dialogCanvas.Close();
    }
}
