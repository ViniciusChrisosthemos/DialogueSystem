using UnityEngine;
using DialogueSystem;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private RootNodeSO m_dialogueRootSO;
    [SerializeField] private DialogueView m_dialogueView;

    private DialogueRunner m_dialogueRunner;

    private void Start()
    {
        m_dialogueRunner = new DialogueRunner(null);

        m_dialogueView.Setup(m_dialogueRunner);
        m_dialogueRunner.StartDialogue(m_dialogueRootSO);

        m_dialogueRunner.OnDialogueFinished += HandleDialogueFinished;
    }

    private void HandleDialogueFinished()
    {
        m_dialogueRunner.StartDialogue(m_dialogueRootSO);
    }
}
