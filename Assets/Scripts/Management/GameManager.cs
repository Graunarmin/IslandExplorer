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
    
    
    private KeyCode interact = KeyCode.Space;
    //private KeyCode notebook = KeyCode.E;
    //private KeyCode walkiTalki = KeyCode.T;
    //private KeyCode pause = KeyCode.Escape;
    
    #region UserInput
    public static event Action InteractionEvent;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interact) && !DialogManager.dialogManager.inDialog)
        {
            //Broadcast that the interact Key was pressed
            InteractionEvent?.Invoke();
        }
    }
    #endregion

    public void FreezeMovement()
    {
        References.instance.player.GetComponent<PlayerMovement>().enabled = false;
    }

    public void UnfreezeMovement()
    {
        References.instance.player.GetComponent<PlayerMovement>().enabled = true;
    }
}
