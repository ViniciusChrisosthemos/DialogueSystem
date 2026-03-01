using UnityEngine;

namespace DialogueSystem
{
    public readonly struct ChoiceOptionData
    {
        public string Description { get; }
        public int Index { get; }

        public ChoiceOptionData(string description, int index)
        {
            Description = description;
            Index = index;
        }
    }
}
