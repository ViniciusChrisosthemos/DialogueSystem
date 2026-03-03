using System;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueRunner
    {
        public event Action<DialogueLineData> OnLineReady;
        public event Action<IReadOnlyList<ChoiceOptionData>> OnChoice;
        public event Action OnDialogueFinished;

        private readonly IDialogueCommandExecutor m_commandExecutor;
        private readonly IDialogueConditionService m_conditionService;

        private DialogueNodeSO m_currentNode;

        public DialogueRunner(IDialogueCommandExecutor commandExecutor)
        {
            m_commandExecutor = commandExecutor;
        }

        public void StartDialogue(DialogueNodeSO root)
        {
            m_currentNode = root;

            ProcessCurrentNode();
        }

        private void ProcessCurrentNode()
        {
            switch(m_currentNode)
            {
                case RootNodeSO rootNode: ProcessRoot(rootNode); break;
                case LineNodeSO lineNode: ProcessLine(lineNode); break;
                case ChoiceNodeSO choiceNode: ProcessChoice(choiceNode); break;
                case CommandNodeSO commandNode: ProcessCommand(commandNode); break;
                case ConditionalNodeSO conditionalNode: ProcessConditional(conditionalNode); break;
                default: Debug.LogError($"[{GetType()}][ProcessNode] Dialogue Node of type '{m_currentNode.GetType()}' not handled."); break;
            }
        }

        public void Next()
        {
            if (m_currentNode.NextNode == null)
            {
                OnDialogueFinished?.Invoke();
            }
            else
            {
                m_currentNode = m_currentNode.NextNode;

                ProcessCurrentNode();
            }
        }

        private void ProcessRoot(RootNodeSO rootNode)
        {
            Next();
        }

        private void ProcessLine(LineNodeSO lineNode)
        {
            var lineData = new DialogueLineData(
                lineNode.SpeakerID,
                lineNode.Lines.ToArray(),
                lineNode.ExpressionID
            );

            OnLineReady?.Invoke(lineData);
        }

        private void ProcessChoice(ChoiceNodeSO choiceNode)
        {
            var choices = new List<ChoiceOptionData>();

            for (int i = 0; i< choiceNode.Options.Count; i++)
            {
                var choice = choiceNode.Options[i];

                choices.Add(new ChoiceOptionData(choice.Description, i));
            }

            OnChoice?.Invoke(choices);
        }

        public void SelectChoice(int index)
        {
            var choiceNode = m_currentNode as ChoiceNodeSO;
            var option = choiceNode.Options[index];

            if (!string.IsNullOrEmpty(option.CommandID))
            {
                m_commandExecutor.Execute(option.CommandID, option.PayloadJson);
            }

            m_currentNode = option.NextNode;

            ProcessCurrentNode();
        }

        private void ProcessCommand(CommandNodeSO commandNode)
        {
            if (!string.IsNullOrEmpty(commandNode.CommandID))
            {
                m_commandExecutor.Execute(commandNode.CommandID, commandNode.PayloadJson);
            }

            m_currentNode = commandNode.NextNode;

            ProcessCurrentNode();
        }

        private void ProcessConditional(ConditionalNodeSO conditionalNode)
        {
            var result = m_conditionService.Evaluate(conditionalNode.ConditionID, conditionalNode.PayloadJson);
            
            if (result)
            {
                m_currentNode = conditionalNode.TrueNode;
            }
            else
            {
                m_currentNode = conditionalNode.FalseNode;
            }

            ProcessCurrentNode();
        }
    }
}
