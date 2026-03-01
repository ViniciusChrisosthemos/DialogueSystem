using System;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueRunner
    {
        public event Action<DialogueLineData> OnLineReady;
        public event Action<IReadOnlyList<ChoiceOptionData>> OnChoice;

        private readonly IDialogueCommandExecutor m_commandExecutor;
        private readonly IDialogueConditionService m_conditionService;

        private DialogueNode m_currentNode;

        public DialogueRunner(IDialogueCommandExecutor commandExecutor)
        {
            m_commandExecutor = commandExecutor;
        }

        public void StartDialogue(DialogueData dialogueData)
        {
            m_currentNode = dialogueData.StartNode;

            ProcessCurrentNode();
        }

        private void ProcessCurrentNode()
        {
            switch(m_currentNode)
            {
                case LineNode lineNode: ProcessLine(lineNode); break;
                case ChoiceNode choiceNode: ProcessChoice(choiceNode); break;
                case CommandNode commandNode: ProcessCommand(commandNode); break;
                case ConditionalNode conditionalNode: ProcessConditional(conditionalNode); break;
                default: Debug.LogError($"[{GetType()}][ProcessNode] Dialogue Node of type '{m_currentNode.GetType()}' not handled."); break;
            }
        }

        private void ProcessLine(LineNode lineNode)
        {
            var lineData = new DialogueLineData(
                lineNode.SpeakerID,
                lineNode.Lines.ToArray(),
                lineNode.ExpressionID
            );

            OnLineReady?.Invoke(lineData);
        }

        private void ProcessChoice(ChoiceNode choiceNode)
        {
            var choices = new List<ChoiceOptionData>();

            for (int i = 0; i<choices.Count; i++)
            {
                var choice = choices[i];

                choices.Add(new ChoiceOptionData(choice.Description, choice.Index));
            }

            OnChoice?.Invoke(choices);
        }

        public void SelectChoice(int index)
        {
            var choiceNode = m_currentNode as ChoiceNode;
            var option = choiceNode.Options[index];

            if (!string.IsNullOrEmpty(option.CommandID))
            {
                m_commandExecutor.Execute(option.CommandID, option.PayloadJson);
            }

            m_currentNode = option.NextNode;

            ProcessCurrentNode();
        }

        private void ProcessCommand(CommandNode commandNode)
        {
            if (!string.IsNullOrEmpty(commandNode.CommandID))
            {
                m_commandExecutor.Execute(commandNode.CommandID, commandNode.PayloadJson);
            }

            m_currentNode = commandNode.NextNode;

            ProcessCurrentNode();
        }

        private void ProcessConditional(ConditionalNode conditionalNode)
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
