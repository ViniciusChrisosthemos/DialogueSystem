using UnityEngine;
using DialogueSystem;
using System;

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
        switch (commandID)
        {
            case INCREASE_STAT_EVENT: HandleSocialStatEvent(payloadJson); break;

            default: 
                Debug.Log($"[{GetType()}][Execute] Event {commandID} not found!"); 
                break;
        }
    }

    private void HandleSocialStatEvent(string payloadJson)
    {
        var increaseStatData = JsonUtility.FromJson<IncreaseStatData>(payloadJson);

        Debug.Log($"{m_socialStatManager} {increaseStatData} {payloadJson}");

        m_socialStatManager.IncreaseStat(increaseStatData.StatID, increaseStatData.Amount);
    }


    [Serializable]
    private class IncreaseStatData
    {
        public string StatID;
        public int Amount;
    }
}
