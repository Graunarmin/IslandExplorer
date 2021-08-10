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

    //private KeyCode interact = KeyCode.E;
    //private KeyCode inspect = KeyCode.Q;
    //private KeyCode journal = KeyCode.Tab;
    //private KeyCode inventory = KeyCode.I;
    
    #region UserInput
    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
}
