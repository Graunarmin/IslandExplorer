using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void OnEnable()
    {
        InspectorCanvas.Interacting += MovementFrozen;
        InspectorCanvas.Interacting += SetInteracting;
        DialogManager.DialogStarted += SetInDialog;
    }


    private KeyCode interact = KeyCode.Space;
    private KeyCode notebook = KeyCode.E;
    //private KeyCode walkiTalki = KeyCode.T;
    //private KeyCode pause = KeyCode.Escape;

    private bool currentlyInteracting;
    private bool inDialog;
    
    #region UserInput
    public static event Action InteractionEvent;
    
    // Update is called once per frame
    void Update()
    {
        if (!inDialog)
        {
            if (Input.GetKeyDown(interact))
            {
                //Broadcast that the interact Key was pressed
                InteractionEvent?.Invoke();
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
        }
    }
    #endregion

    
    public void MovementFrozen(bool status)
    {
        Debug.Log("Movement Frozen: " + status);
        References.instance.player.GetComponent<PlayerMovement>().enabled = !status;
    }

    private void SetInteracting(bool status)
    {
        currentlyInteracting = status;
    }

    private void SetInDialog(bool status)
    {
        inDialog = status;
        MovementFrozen(status);
    }
}
