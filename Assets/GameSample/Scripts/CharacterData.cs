using DialogueSystem;
using UnityEngine;

public class CharacterData : ScriptableObject, IDialogSpeaker
{
    [SerializeField] private string m_id;

    [Header("Images")]
    [SerializeField] private Sprite m_normalPortrait;

    public string GetID()
    {
        return m_id;
    }
}
