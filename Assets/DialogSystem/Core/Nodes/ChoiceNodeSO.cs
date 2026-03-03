using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(fileName = "ChoiceNode_", menuName = "ScriptableObjects/Dialogue System/Choice Node SO")]
    public class ChoiceNodeSO : DialogueNodeSO
    {
        [SerializeField] private List<ChoiceOption> m_options;

        public List<ChoiceOption> Options => m_options;
    }

}