using UnityEngine;

namespace DialogueSystem
{
    public abstract class DialogueNode
    {
        public DialogueNode NextNode { get; set; }

        public virtual DialogueNode GetNext()
        {
            return NextNode;
        }
    }

}