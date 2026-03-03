using UnityEngine;
using DialogueSystem;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System.Collections;

public class DialogueView : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI m_txtLine;
    [SerializeField] private Button m_btnNext;

    [Header("Choice References")]
    [SerializeField] private GameObject m_choiceView;
    [SerializeField] private UIListDisplay m_choiceListDisplay;

    [Header("Parameters")]
    [SerializeField] private float m_delayBetweenCharacters = 0;

    private DialogueRunner m_dialogueRunner;

    private List<string> m_lines;
    private int m_currentIndex;

    private Coroutine m_textAnimationCorotuine;

    private void Awake()
    {
        m_choiceView.SetActive(false);
    }

    public void Setup(DialogueRunner dialogueRunner)
    {
        m_dialogueRunner = dialogueRunner;

        m_btnNext.onClick.AddListener(NextLine);

        m_dialogueRunner.OnLineReady += HandleLineReady;
        m_dialogueRunner.OnChoice += HandleChoice;
    }

    private void HandleChoice(IReadOnlyList<ChoiceOptionData> choices)
    {
        m_choiceView.SetActive(true);

        Debug.Log(choices.Count);
        m_choiceListDisplay.SetItems(choices.ToList(), HandleChoiceSelected);
    }

    private void HandleChoiceSelected(UIItemController controller)
    {
        var choice = controller.GetItem<ChoiceOptionData>();

        m_dialogueRunner.SelectChoice(choice.Index);

        m_choiceView.SetActive(false);
    }

    private void HandleLineReady(DialogueLineData dialogueLineData)
    {
        m_lines = dialogueLineData.Lines.ToList();
        m_currentIndex = 0;

        NextLine();
    }

    private void NextLine()
    {
        if (m_textAnimationCorotuine != null)
        {
            StopCoroutine(m_textAnimationCorotuine);

            m_textAnimationCorotuine = null;
            m_txtLine.text = m_lines[m_currentIndex - 1];
        }
        else
        {
            if (m_currentIndex == m_lines.Count)
            {
                m_dialogueRunner.Next();
            }
            else
            {
                m_textAnimationCorotuine = StartCoroutine(AnimateCoroutine(m_lines[m_currentIndex]));
                m_currentIndex++;
            }
        }

        
    }

    private IEnumerator AnimateCoroutine(string text)
    {
        int currentCharIndex = 0;
        var currentText = string.Empty;

        m_txtLine.text = currentText;

        while (currentCharIndex < text.Length)
        {
            currentText += text[currentCharIndex++];
            m_txtLine.text = currentText;

            if (m_delayBetweenCharacters == 0f)
            {
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(m_delayBetweenCharacters);
            }
        }

        m_txtLine.text = text;

        m_textAnimationCorotuine = null;
    }
}
