using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogCanvas : InspectorCanvas
{
    [SerializeField] private Image speakerPortrait;
    public void SetSpeakerInfo(string[] info, Dictionary<string, CharacterAsset> speakerDatabase)
    {
        string speaker = info[0];

        if (speakerDatabase.TryGetValue(speaker, out CharacterAsset data))
        {
            speakerPortrait.sprite = data.characterPortrait;
            return;
        }
        Debug.Log("Could not set speaker info for unknown speaker");
    }
}
