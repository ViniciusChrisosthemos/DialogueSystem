using System;
using UnityEngine;

public class SocialStatManager : MonoBehaviour
{
    public void IncreaseStat(string statID, int amount)
    {
        Debug.Log($"[SocialStatManager] StatID:{statID}  Amount:{amount}");
    }
}
