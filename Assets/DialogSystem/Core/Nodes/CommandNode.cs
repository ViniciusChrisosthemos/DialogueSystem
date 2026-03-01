using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class CommandNode : DialogueNode
    {
        public string CommandID { get; }
        public string PayloadJson { get; }

        public CommandNode(string commandID, string payloadJson)
        {
            CommandID = commandID;
            PayloadJson = payloadJson;
        }
    }
}
