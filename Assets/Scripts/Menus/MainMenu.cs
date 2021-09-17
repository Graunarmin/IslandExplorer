using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menuCanvas;
    public MenuObject mainMenuUI;
    public float fadeInTime;

    public List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>();

    private void OnEnable()
    {
        MenuObject.PlayGame += PlayGame;
        MenuObject.QuitGame += QuitGame;
    }

    private void OnDisable()
    {
        MenuObject.PlayGame -= PlayGame;
        MenuObject.QuitGame -= QuitGame;
    }

    private void Start()
    {
        menuCanvas.SetActive(true);
        mainMenuUI.Activate();
        StartCoroutine(ActivateButtons());

        foreach (TextMeshProUGUI text in texts)
        {
            StartCoroutine(FadeTextToFullAlpha(fadeInTime, text));
        }
    }

    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI textElement)
    {
        //first set alpha to zero
        textElement.color = new Color(textElement.color.r, textElement.color.g, textElement.color.b, 0);

        //the fade in text
        while (textElement.color.a < 1.0f)
        {
            textElement.color = new Color(textElement.color.r, textElement.color.g, textElement.color.b, textElement.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator ActivateButtons()
    {
        mainMenuUI.EnableButtons(false);

        //Wait until text is loaded
        yield return new WaitForSeconds(fadeInTime + 1f);

        mainMenuUI.EnableButtons(true);
    }

    private KeyCode escape = KeyCode.Escape;

    void Update()
    {
        if (Input.GetKeyDown(escape))
        {
            EscapeInteraction();
        }
    }

    public void EscapeInteraction()
    {
        if (mainMenuUI.controlsPopUp.IsActive)
        {
            mainMenuUI.HidePopUp(mainMenuUI.controlsPopUp);
        }
        else if (mainMenuUI.creditsPopUp.IsActive)
        {
            mainMenuUI.HidePopUp(mainMenuUI.creditsPopUp);
        }
        else if (mainMenuUI.optionsMenuUI.IsActive)
        {
            mainMenuUI.optionsMenuUI.Deactivate();
        }
    }
    
    private void PlayGame()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1));
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
    
}
