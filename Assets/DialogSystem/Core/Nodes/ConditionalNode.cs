using UnityEngine;

namespace DialogueSystem
{
    public class ConditionalNode : DialogueNode
    {
        public string ConditionID { get; }
        public string PayloadJson { get; }
        public DialogueNode TrueNode { get; }
        public DialogueNode FalseNode { get; }

        public ConditionalNode(string conditionID, string payloadJson, DialogueNode trueNode, DialogueNode falseNode)
        {
            ConditionID = conditionID;
            PayloadJson = payloadJson;
            TrueNode = trueNode;
            FalseNode = falseNode;
        }

        public override DialogueNode GetNext()
        {
            return null;
        }
    }
}
