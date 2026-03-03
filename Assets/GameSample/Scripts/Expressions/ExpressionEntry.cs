
using System;
using UnityEngine;

[Serializable]
public class ExpressionEntry
{
    [SerializeField] private string m_key;
    [SerializeField] private string m_value;

    public string Key => m_key;

    public string Value => m_value;
}
