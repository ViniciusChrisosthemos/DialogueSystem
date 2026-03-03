using System.Collections.Generic;
using UnityEngine;


namespace DialogueSystem
{
    [CreateAssetMenu(fileName = "LineNode_", menuName = "ScriptableObjects/Dialogue System/Line Node SO")]
    public class LineNodeSO : DialogueNodeSO
    {
        [SerializeField] private string m_speackerID;
        [SerializeField] private List<string> m_lines;
        [SerializeField] private string m_expressionID;

        public string SpeakerID => m_speackerID;
        public List<string> Lines => m_lines;
        public string ExpressionID => m_expressionID;
    }
}
