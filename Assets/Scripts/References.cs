using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class References : MonoBehaviour
{
    #region Singleton

    public static References instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #endregion
    
    #region references

    public Camera mainCamera;

    public Transform player;
    

    #endregion


}
