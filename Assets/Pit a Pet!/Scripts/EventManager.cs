using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    private static Dictionary<string, Action> eventDictionary = new Dictionary<string, Action>();

    // 이벤트 등록
    public static void StartListening(string eventName, Action listener)
    {
        if (eventDictionary.TryGetValue(eventName, out Action thisEvent))
        {
            thisEvent += listener;
            eventDictionary[eventName] = thisEvent;
        }
        else
        {
            thisEvent += listener;
            eventDictionary.Add(eventName, thisEvent);
        }
    }

    // 이벤트 등록 해제
    public static void StopListening(string eventName, Action listener)
    {
        if (eventDictionary.TryGetValue(eventName, out Action thisEvent))
        {
            thisEvent -= listener;
            eventDictionary[eventName] = thisEvent;
        }
    }

    // 이벤트 트리거
    public static void TriggerEvent(string eventName)
    {
        if (eventDictionary.TryGetValue(eventName, out Action thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
