using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class ChoiceNode : DialogueNode
    {
        public IReadOnlyList<ChoiceOption> Options { get; }

        public ChoiceNode(IReadOnlyList<ChoiceOption> options)
        {
            Options = options;
        }

        public override DialogueNode GetNext()
        {
            return null;
        }
    }

}