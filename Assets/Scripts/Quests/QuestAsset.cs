using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class QuestAsset : ScriptableObject
{
    public string title;
    public Sprite icon;
    public string questText;
    public bool triggersCall;
}
