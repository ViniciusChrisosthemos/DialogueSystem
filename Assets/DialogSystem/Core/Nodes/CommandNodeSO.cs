using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{

    [CreateAssetMenu(fileName = "CommandNode_", menuName = "ScriptableObjects/Dialogue System/Command Node SO")]
    public class CommandNodeSO : DialogueNodeSO
    {
        [SerializeField] private string m_commandID;
        [SerializeField] private string m_payloadJson;

        public string CommandID => m_commandID;
        public string PayloadJson => m_payloadJson;

    }
}
