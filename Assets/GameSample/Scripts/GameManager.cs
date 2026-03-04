using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string SOCIAL_STATS_COMMAND_ID = "social-stat";

    [SerializeField] private DialogueManager m_dialogueManager;
    [SerializeField] private SocialStatManager m_socialStatManager;

    private void Start()
    {
        m_dialogueManager.Setup();

        m_dialogueManager.RegisterCommandExectuor(SOCIAL_STATS_COMMAND_ID, new SocialStatsCommandExecutor(m_socialStatManager));
    }
}
