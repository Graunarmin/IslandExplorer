using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OptionsMenu : MonoBehaviour
{

    [SerializeField] private List<Button> buttons = new List<Button>();
    private MenuObject originMenu;

    public bool IsActive
    {
        get { return gameObject.activeInHierarchy; }
    }

    public void Activate(MenuObject menu)
    {
        gameObject.SetActive(true);
        originMenu = menu;
        buttons[0].Select();
    }

    public void Deactivate()
    {
        originMenu.Activate();
        gameObject.SetActive(false);
        
    }
}
