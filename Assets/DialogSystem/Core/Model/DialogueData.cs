using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueData
    {
        public DialogueNodeSO StartNode { get; }

        public DialogueData(DialogueNodeSO node)
        {
            StartNode = node;
        }
    }
}
