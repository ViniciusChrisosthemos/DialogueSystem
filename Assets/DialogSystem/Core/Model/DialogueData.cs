using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(fileName = "Dialogue_", menuName = "DialogueSystem/Dialogue Data")]
    public class DialogueData : ScriptableObject
    {
        [SerializeField] private string m_speakerID;
        [SerializeField] private DialogueNode m_startNode;
        [SerializeField] private List<DialogueNode> m_allNodes;

        public string SpeakerID => m_speakerID;

        public DialogueNode StartNode => m_startNode;

        public List<DialogueNode> AllNodes => m_allNodes;
    }
}
