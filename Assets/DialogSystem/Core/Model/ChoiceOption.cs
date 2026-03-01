using System;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    [Serializable]
    public class ChoiceOption
    {
        public string Description { get; }
        public string CommandID { get; }
        public string PayloadJson { get; }
        public DialogueNode NextNode { get; }

        public ChoiceOption(string description, DialogueNode nextNode, string commandID=null, string payloadJson = null)
        {
            Description = description;
            CommandID = commandID;
            PayloadJson = payloadJson;
            NextNode = nextNode;
        }
    }
}
