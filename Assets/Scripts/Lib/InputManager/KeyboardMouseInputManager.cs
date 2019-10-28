using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Momo
{
    // DEPRECATED because Input Package is a thing now
    public class KeyboardMouseInputManager : PersistantMonoBehaviourSingleton<KeyboardMouseInputManager>
    {

        private Dictionary<KeyCode, string> keycodeMap = new Dictionary<KeyCode, string>();
        private Dictionary<string, Action> actionMap = new Dictionary<string, Action>();

        public delegate void MouseAction(float x, float y);
        private MouseAction mouseEvent = null;


        private void Update()
        {
            // Keycode
            foreach(KeyValuePair<KeyCode, string> e in keycodeMap)
            {
                if (Input.GetKey(e.Key))
                {
                    Action action;
                    if (actionMap.TryGetValue(e.Value, out action))
                    {
                        if (action != null)
                            action();
                    }
                }
            }

            // Mouse Movement
            if (mouseEvent != null)
            {
                float mouseXvalue = Input.GetAxis("Mouse X");
                float mouseYvalue = Input.GetAxis("Mouse Y");
            }
        }

        public bool ObserveKeycode(KeyCode code, string name)
        {
            if (keycodeMap.ContainsKey(code) || actionMap.ContainsKey(name))
                return false;

            keycodeMap[code] = name;
            actionMap[name] = null;

            return true;
        }

        public bool UnobserveKeycode(KeyCode code, string name)
        {
            return keycodeMap.Remove(code) && actionMap.Remove(name);
        }

        // For Keycode events
        public bool Register(string name, Action action)
        {
            if(actionMap.ContainsKey(name))
            {
                actionMap[name] += action;
                return true;
            }
            return false;
        }

        // For Keycode events
        public bool Unregister(string name, Action action)
        {
            if (actionMap.ContainsKey(name))
            {
                actionMap[name] -= action;
                return true;
            }
            return false;
        }

        // For Mouse movement events
        public void Register(MouseAction action)
        {
            mouseEvent += action;
        }

        public void Unregister(MouseAction action)
        {
            mouseEvent -= action;
        }
    }
}