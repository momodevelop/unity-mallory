using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Momo
{
    public class EventManager<Key, EventParam>
    {
        private Dictionary<Key, Action<EventParam>> eventDictionary;

        public EventManager()
        {
            eventDictionary = new Dictionary<Key, Action<EventParam>>();
        }

        public void StartListening(Key eventName, Action<EventParam> listener)
        {
            Action<EventParam> thisEvent;
            if (eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                //Add more event to the existing one
                thisEvent += listener;

                //Update the Dictionary
                eventDictionary[eventName] = thisEvent;
            }
            else
            {
                //Add event to the Dictionary for the first time
                thisEvent += listener;
                eventDictionary.Add(eventName, thisEvent);
            }
        }

        public void StopListening(Key eventName, Action<EventParam> listener)
        {
            Action<EventParam> thisEvent;
            if (eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                //Remove event from the existing one
                thisEvent -= listener;

                //Update the Dictionary
                eventDictionary[eventName] = thisEvent;
            }
        }

        public void TriggerEvent(Key eventName, EventParam eventParam)
        {
            Action<EventParam> thisEvent = null;
            if (eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Invoke(eventParam);
                // OR USE  instance.eventDictionary[eventName](eventParam);
            }
        }
    }
}
