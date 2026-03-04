using UnityEngine;
using DialogueSystem;
using System;
using Newtonsoft.Json;

public class SocialStatsCommandExecutor : IDialogueCommandExecutor
{
    private const string INCREASE_STAT_EVENT = "increase-stat";

    private SocialStatManager m_socialStatManager;

    public SocialStatsCommandExecutor(SocialStatManager socialStatManager)
    {
        m_socialStatManager = socialStatManager;
    }

    public void Execute(string commandID, string payloadJson)
    {
        dynamic jsonData = JsonConvert.DeserializeObject<dynamic>(payloadJson);

        string eventID = jsonData.EventID;

        switch (eventID)
        {
            case INCREASE_STAT_EVENT:
                string statID = jsonData.StatID;
                int amount = jsonData.Amount;

                m_socialStatManager.IncreaseStat(statID, amount);

                break;

            default: 
                Debug.Log($"[{GetType()}][Execute] Event {commandID} not found!"); 
                break;
        }
    }
}
