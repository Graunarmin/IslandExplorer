using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class DialogManager : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public static VariableStorage dialogVariables;
    
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
        
        dialogueRunner.AddCommandHandler("SetSpeaker", SetSpeakerInfo);
        dialogCanvas.gameObject.SetActive(false);
        dialogVariables = dialogueRunner.variableStorage;
    }

    #endregion
    
    
    public DialogCanvas dialogCanvas;
    public bool inDialog;
    
    private Dictionary<string, CharacterAsset> speakerDatabase = new Dictionary<string, CharacterAsset>();
    
    public static event Action<bool> DialogStartedEvent;

    public void ActivateDialog(Character character)
    {
        Debug.Log("Quest Progress: " + dialogVariables.GetValue("$questprogress"));
        dialogCanvas.Activate();
        inDialog = true;
        DialogStartedEvent?.Invoke(true);
        dialogueRunner.StartDialogue(character.YarnStartNode);
    }

    public void DeactivateDialog()
    {
        inDialog = false;
        DialogStartedEvent?.Invoke(false);
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
    
}
