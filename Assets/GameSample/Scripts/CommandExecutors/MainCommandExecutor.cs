using DialogueSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

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
            var eventData = JsonUtility.FromJson<EventData>(payloadJson);

            Debug.Log($"{commandID} {payloadJson} {eventData} {eventData.EventID} {eventData.Args}");

            m_executorDict[commandID].Execute(eventData.EventID, eventData.Args);
        }
    }

    public void RegisterExecutor(string commandID, IDialogueCommandExecutor executor)
    {
        m_executorDict.Add(commandID, executor);
    }


    [Serializable]
    private class EventData
    {
        public string EventID;
        public string Args;
    }
}
