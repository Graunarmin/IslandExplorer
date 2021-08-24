using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character", order = 0)]
public class CharacterAsset : ScriptableObject
{
    public string characterName = "New Character";
    public Sprite characterPortrait = null;
}
