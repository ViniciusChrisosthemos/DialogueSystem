using UnityEngine;

namespace DialogueSystem
{
    public abstract class DialogueNodeSO : ScriptableObject
    {
        [SerializeField] private DialogueNodeSO m_nextNode;

        public DialogueNodeSO NextNode => m_nextNode;
    }

}