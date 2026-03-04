using DialogueSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Dynamic;

public class MainCommandExecutor : IDialogueCommandExecutor
{
    private Dictionary<string, IDialogueCommandExecutor> m_executorDict;

    public MainCommandExecutor()
    {
        m_executorDict = new Dictionary<string, IDialogueCommandExecutor>();
    }

    public void Execute(string commandID, string payloadJson)
    {
        if (m_executorDict.ContainsKey(commandID))
        {
            m_executorDict[commandID].Execute(commandID, payloadJson);
        }
    }

    public void RegisterExecutor(string commandID, IDialogueCommandExecutor executor)
    {
        m_executorDict.Add(commandID, executor);
    }
}
