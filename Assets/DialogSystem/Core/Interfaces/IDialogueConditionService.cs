using UnityEngine;

namespace DialogueSystem
{
    public interface IDialogueConditionService
    {
        bool Evaluate(string conditionID, string payloadJson);
    }
}
