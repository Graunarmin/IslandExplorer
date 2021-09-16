using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    [SerializeField] private List<Button> buttons = new List<Button>();
    private PauseMenu pauseMenu;
    
    public bool IsActive
    {
        get { return gameObject.activeInHierarchy; }
    }
    public void Activate(PauseMenu menu)
    {
        gameObject.SetActive(true);
        pauseMenu = menu;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        pauseMenu.Activate();
    }
}
