using System.Collections.Generic;


namespace DialogueSystem
{
    public class LineNode : DialogueNode
    {
        public string SpeakerID { get; }
        public List<string> Lines { get; }
        public string ExpressionID { get; }

        public LineNode(string speakerID, List<string> lines, string expressionID)
        {
            SpeakerID = speakerID;
            Lines = lines;
            ExpressionID = expressionID;
        }
    }
}
