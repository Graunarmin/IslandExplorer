using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    public float animationTime;
    public string loadScene;
    private void Awake()
    {
        StartCoroutine(LoadNextScene());
    }
    
    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(animationTime);
        LoadScene();
        
    }

    private void LoadScene()
    {
        if (loadScene == "next")
        {
            LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1));
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(loadScene));
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopAllCoroutines();
            LoadScene();
        }
    }
}
