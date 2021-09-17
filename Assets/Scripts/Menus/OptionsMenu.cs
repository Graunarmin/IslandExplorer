using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    [SerializeField] private List<Button> buttons = new List<Button>();
    private MenuObject originMenu;
    
    public bool IsActive
    {
        get { return gameObject.activeInHierarchy; }
    }

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Activate(MenuObject menu)
    {
        gameObject.SetActive(true);
        originMenu = menu;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        originMenu.Activate();
    }
}
