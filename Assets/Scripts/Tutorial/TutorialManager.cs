using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class TutorialManager : MonoBehaviour
{
    [Header("Yarn")]
    public DialogueRunner dialogueRunner;

    public string yarnStartNode;
    public YarnProgram yarnDialog;
    
    [Header("UI")]
    public DialogCanvas dialogCanvas;
    public List<CharacterAsset> characters = new List<CharacterAsset>();

    [Header("Player")] 
    public Transform player;

    public TimelineController timelineController;

    //public Transform playerTarget;
    
    private Dictionary<string, CharacterAsset> speakerDatabase = new Dictionary<string, CharacterAsset>();
    
    private void Awake()
    {
        dialogCanvas.gameObject.SetActive(false);
        dialogueRunner.AddCommandHandler("SetSpeaker", SetSpeakerInfo);
        dialogueRunner.AddCommandHandler("trigger_pause", PauseDialog);
        dialogueRunner.AddCommandHandler("trigger_animation", StartAnimation);
        dialogueRunner.Add(yarnDialog);
        foreach (CharacterAsset data in characters)
        {
            AddSpeaker(data);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(LoadNextScene(0.5f));
        }
    }

    private void Start()
    {
        StartCoroutine(StartDialog(3f));
    }

    IEnumerator StartDialog(float time)
    {
        yield return new WaitForSeconds(time);
        ActivateDialog();
    }
    
    void ActivateDialog()
    {
        //dialogCanvas.Activate();
        dialogueRunner.StartDialogue(yarnStartNode);
    }

    void PauseDialog(string[] time)
    {
        StartCoroutine(PauseDialog(float.Parse(time[0])));
    }

    IEnumerator PauseDialog(float time)
    {
        dialogCanvas.Close();
        yield return new WaitForSeconds(time);
        dialogCanvas.Activate();
    }
    
    public void DeactivateDialog()
    {
        dialogCanvas.Close();
        StartCoroutine(LoadNextScene(1f));
    }

    IEnumerator LoadNextScene(float time)
    {
        yield return new WaitForSeconds(time);
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1));
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    void AddSpeaker(CharacterAsset data)
    {
        if (speakerDatabase.ContainsKey(data.characterName))
        {
            Debug.Log("Speaker already in Database.");
            return;
        }
        speakerDatabase.Add(data.characterName, data);
    }
    
    void SetSpeakerInfo(string[] info)
    {
        dialogCanvas.SetSpeakerInfo(info, speakerDatabase);
    }

    void StartAnimation(string[] info)
    {
        Debug.Log("Walking Animation");
        timelineController.Play();
        
    }
}
