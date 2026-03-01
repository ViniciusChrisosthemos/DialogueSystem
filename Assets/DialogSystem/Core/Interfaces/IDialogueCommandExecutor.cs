using UnityEngine;

namespace DialogueSystem
{
    public interface IDialogueCommandExecutor
    {
        void Execute(string commandID, string payloadJson);
    }
}
