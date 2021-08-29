using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class CharacterAsset : ScriptableObject
{
    public string characterName = "New Character";
    public Sprite characterPortrait = null;
}
