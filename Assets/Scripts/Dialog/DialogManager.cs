using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public DialogueRunner Runner { get; private set; }
    public DialogueRunner dialogueRunner;
    
    #region Singleton

    public static DialogManager dialogManager;
    private void Awake()
    {
        if (dialogManager == null)
        {
            dialogManager = this;
        }
        else
        {
            Debug.LogWarning("More than one instance of DialogManager!");
        }

        Runner = dialogueRunner;
        Runner.AddCommandHandler("SetSpeaker", SetSpeakerInfo);
        dialogCanvas.gameObject.SetActive(false);
    }

    #endregion
    
    
    public DialogCanvas dialogCanvas;
    public bool inDialog;
    
    private Dictionary<string, CharacterAsset> speakerDatabase = new Dictionary<string, CharacterAsset>();

    [SerializeField] private QuestGiver questGiver;

    public static event Action<bool> DialogStarted; 

    public void ActivateDialog()
    {
        dialogCanvas.Activate();
        inDialog = true;
        DialogStarted?.Invoke(true);
        dialogueRunner.StartDialogue(((Character)Character.ActiveInteractable).YarnStartNode);
    }

    public void DeactivateDialog()
    {
        inDialog = false;
        DialogStarted?.Invoke(false);
        dialogCanvas.Close();
    }
    
    public void AddSpeaker(CharacterAsset data)
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

    void GiveQuest(string[] questTitle)
    {
        questGiver.SetQuest(questTitle[0]);
    }
}
