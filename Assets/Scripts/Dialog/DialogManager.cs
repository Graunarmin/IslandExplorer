using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using TMPro;

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
    }

    #endregion
    
    
    public DialogCanvas dialogCanvas;
    public bool inDialog;
    
    private Dictionary<string, CharacterAsset> speakerDatabase = new Dictionary<string, CharacterAsset>();
    
    [SerializeField] private Image speakerPortrait;
    [SerializeField] private TextMeshProUGUI speakerName;

    public void ActivateDialog()
    {
        inDialog = true;
        dialogCanvas.Activate();
        dialogueRunner.StartDialogue(((Character)Character.ActiveInteractable).YarnStartNode);
    }

    public void DeactivateDialog()
    {
        inDialog = false;
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
        string speaker = info[0];

        if (speakerDatabase.TryGetValue(speaker, out CharacterAsset data))
        {
            speakerPortrait.sprite = data.characterPortrait;
            speakerName.text = data.characterName;
            return;
        }
        Debug.Log("Could not set speaker info for unknown speaker");
    }
}
