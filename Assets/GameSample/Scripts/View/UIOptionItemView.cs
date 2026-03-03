using TMPro;
using UnityEngine;

using DialogueSystem;
using UnityEngine.UI;

public class UIOptionItemView : UIItemController
{
    [SerializeField] private TextMeshProUGUI m_txtOptionDescription;
    [SerializeField] private Button m_btnButton;

    protected override void HandleInit(object obj)
    {
        var optionData = (ChoiceOptionData)obj;

        m_txtOptionDescription.text = optionData.Description;

        m_btnButton.onClick.AddListener(SelectItem);
    }
}
