using UnityEngine;

namespace DialogueSystem
{
    public readonly struct DialogueLineData
    {
        public string SpeakerName { get; }
        public string[] Lines { get; }
        public string ExpressionID { get; }

        public DialogueLineData(string speakerName, string[] lines, string expressionID)
        {
            SpeakerName = speakerName;
            Lines = lines;
            ExpressionID = expressionID;
        }
    };
}
