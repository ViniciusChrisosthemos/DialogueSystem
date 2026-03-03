using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExpressionMap", menuName = "ScriptableObjects/Game/Expression Map")]
public class ExpressionMap : ScriptableObject
{
    [SerializeField] private List<ExpressionEntry> m_entries;

    private Dictionary<string, string> m_entriesDict;

    private void Setup()
    {
        m_entriesDict = new Dictionary<string, string>();

        foreach (var entry in m_entries)
        {
            m_entriesDict.Add(entry.Key, entry.Value);
        }
    }

    public string GetExpressionID(string expressionKey)
    {
        if (m_entriesDict == null)
        {
            Setup();
        }

        if (m_entriesDict.ContainsKey(expressionKey)) return m_entriesDict[expressionKey];

        return string.Empty;
    }
}
