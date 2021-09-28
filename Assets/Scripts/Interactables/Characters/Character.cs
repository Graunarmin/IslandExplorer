using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Interactable
{
    public CharacterAsset character;
    public string YarnStartNode { get { return yarnStartNode;} }
    
    [SerializeField] private string yarnStartNode = "Start";
    [SerializeField] private YarnProgram yarnDialog;

    private void Start()
    {
        Debug.Log("Adding Speaker & Dialog: " + character.characterName);
        DialogManager.dialogManager.dialogueRunner.Add(yarnDialog);
        DialogManager.dialogManager.AddSpeaker(character);
    }
  
}
