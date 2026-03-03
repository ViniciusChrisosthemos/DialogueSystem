using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(fileName = "ConditionalNode_", menuName = "ScriptableObjects/Dialogue System/Conditional Node SO")]
    public class ConditionalNodeSO : DialogueNodeSO
    {
        [SerializeField] private string m_conditionID;
        [SerializeField] private string m_payloadJson;
        [SerializeField] private DialogueNodeSO m_trueNode;
        [SerializeField] private DialogueNodeSO m_falseNode;

        public string ConditionID => m_conditionID;
        public string PayloadJson => m_payloadJson;
        public DialogueNodeSO TrueNode => m_trueNode;
        public DialogueNodeSO FalseNode => m_falseNode;
    }
}
