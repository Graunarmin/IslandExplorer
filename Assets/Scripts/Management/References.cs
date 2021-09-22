using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class References : MonoBehaviour
{
    #region Singleton

    private static References _instance;
    public static References Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        
        infoBoxCanvas.gameObject.SetActive(false);
    }

    #endregion
    
    #region references
    
    public Camera mainCamera;

    public Transform player;
    public Transform playerFeet;
    public InfoBoxCanvas infoBoxCanvas;
    public Tilemap waterTilemap;
    public Tilemap pathTilemap;

    #endregion


}
