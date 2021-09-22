using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterAsset character;
    
    private void Start()
    {
        DialogManager.dialogManager.AddSpeaker(character);
    }
}
