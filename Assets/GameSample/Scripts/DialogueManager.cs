using UnityEngine;
using DialogueSystem;
using System;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private RootNodeSO m_dialogueRootSO;
    [SerializeField] private DialogueView m_dialogueView;

    private MainCommandExecutor m_mainCommandExecutor;
    private DialogueRunner m_dialogueRunner;

    public void Setup()
    {
        m_mainCommandExecutor = new MainCommandExecutor();
        m_dialogueRunner = new DialogueRunner(m_mainCommandExecutor);

        m_dialogueView.Setup(m_dialogueRunner);
        m_dialogueRunner.StartDialogue(m_dialogueRootSO);

        m_dialogueRunner.OnDialogueFinished += HandleDialogueFinished;
    }


    private void HandleDialogueFinished()
    {
        m_dialogueRunner.StartDialogue(m_dialogueRootSO);
    }

    public void RegisterCommandExectuor(string commandID, IDialogueCommandExecutor executor)
    {
        m_mainCommandExecutor.RegisterExecutor(commandID, executor);
    }
}
